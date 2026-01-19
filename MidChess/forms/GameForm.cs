using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MidChess.board;
using MidChess.game;
using MidChess.lib;

namespace MidChess
{
    public partial class GameForm : Form
    {
        #region Constants

        private const int BOARD_SIZE = 8;
        private const int MIN_BOARD_INDEX = 0;
        private const int MAX_BOARD_INDEX = 7;
        private const int NO_SELECTION = -1;
        
        // Promotion dialog constants
        private const int PROMOTION_DIALOG_WIDTH = 256;
        private const int PROMOTION_DIALOG_HEIGHT = 128;
        private const int PROMOTION_BUTTON_SPACING = 70;
        private const int PROMOTION_BUTTON_WIDTH = 65;
        private const int PROMOTION_BUTTON_HEIGHT = 30;
        private const int PROMOTION_BUTTON_Y = 20;
        private const int PROMOTION_BUTTON_START_X = 10;
        
        // Takeback move count thresholds
        private const int TAKEBACK_BOTH_MOVES = 2;
        private const int TAKEBACK_SINGLE_MOVE = 1;

        #endregion

        #region Fields

        public bool isFullscreen;

        private bool toSplash;
        private bool isBoardFlipped;
        private bool gameEndedNaturally; // Track if game ended via resign/draw/checkmate

        private FormLib formLib;
        private GameLib gameLib;
        private LANLib lanLib;
        private GameDialog gameDialog;

        private SplashScreenForm splashScreen;
        private LANHandler lanHandler;
        private Game game;

        // Board interaction
        private int selectedX = NO_SELECTION;
        private int selectedY = NO_SELECTION;
        private bool isPieceSelected;
        private List<(int x, int y)> legalMoves = new List<(int, int)>();

        // Rendering resources
        private Dictionary<string, Image> pieceImages;
        private Image lightSquareImage;
        private Image darkSquareImage;

        // Colors for highlighting
        private readonly Color highlightColor = Color.White;
        private readonly Color captureColor = Color.Red;
        private readonly Color selectionColor = Color.Black;

        #endregion

        #region Initialization

        public GameForm(SplashScreenForm parentForm, LANHandler lanHandler = null)
        {
            // Initialize libraries before component due to its use at OnResize at form initialization
            InitializeLibraries();
            InitializeComponent();
            InitializeVariables(parentForm, lanHandler);
            InitializeGame(lanHandler);

            LoadImages();
            Show();
        }

        private void InitializeLibraries()
        {
            formLib = new FormLib();
            lanLib = new LANLib();
            gameLib = new GameLib();
            gameDialog = new GameDialog();
        }

        private void InitializeVariables(SplashScreenForm parentForm, LANHandler lanHandler)
        {
            splashScreen = parentForm;
            this.lanHandler = lanHandler;

            if (splashScreen.isFullscreen)
                formLib.ToggleFullscreen(this, ref isFullscreen);

            toSplash = true;
            gameEndedNaturally = false;
        }

        private void InitializeGame(LANHandler lanHandler)
        {
            game = new Game();

            // Flip board for black player in LAN games
            if (lanHandler != null)
            {
                isBoardFlipped = lanHandler.LocalPlayerColor == 'b';
                SetupLANEvents();
            }
            else
                isBoardFlipped = false;
        }

        private void LoadImages()
        {
            pieceImages = gameLib.LoadPieceImages();
            gameLib.LoadSquareImages(out lightSquareImage, out darkSquareImage);
        }

        private void SetupLANEvents()
        {
            if (lanHandler == null)
                return;

            lanHandler.OnMoveReceived += LANHandler_OnMoveReceived;
            lanHandler.OnDrawOffered += LANHandler_OnDrawOffered;
            lanHandler.OnDrawAccepted += LANHandler_OnDrawAccepted;
            lanHandler.OnDrawDeclined += LANHandler_OnDrawDeclined;
            lanHandler.OnTakebackOffered += LANHandler_OnTakebackOffered;
            lanHandler.OnTakebackAccepted += LANHandler_OnTakebackAccepted;
            lanHandler.OnTakebackDeclined += LANHandler_OnTakebackDeclined;
            lanHandler.OnOpponentResigned += LANHandler_OnOpponentResigned;
            lanHandler.OnOpponentDisconnected += LANHandler_OnOpponentDisconnected;
        }

        #endregion

        #region LAN Events

        private void LANHandler_OnMoveReceived(object sender, MoveReceivedEventArgs e)
        {
            InvokeOnUI(new Action(delegate { HandleMoveReceived(e); }));
        }

        private void HandleMoveReceived(MoveReceivedEventArgs e)
        {
            if (game.TryMovePiece(e.FromX, e.FromY, e.ToX, e.ToY, e.Promotion))
            {
                UpdateBoard();
                CheckGameStatus();
            }
        }

        private void LANHandler_OnDrawOffered(object sender, EventArgs e)
        {
            InvokeOnUI(new Action(HandleDrawOfferReceived));
        }

        private void HandleDrawOfferReceived()
        {
            if (gameDialog.ShowDrawOfferReceivedDialog())
            {
                lanHandler.SendDrawAcceptAsync();
                EndGameAsDraw();
                gameDialog.ShowDrawAcceptedMessage();
                gameEndedNaturally = true;
                TryNewGame();
            }
            else
                lanHandler.SendDrawDeclineAsync();
        }

        private void LANHandler_OnDrawAccepted(object sender, EventArgs e)
        {
            InvokeOnUI(new Action(HandleDrawAccepted));
        }

        private void HandleDrawAccepted()
        {
            EndGameAsDraw();
            gameDialog.ShowOpponentAcceptedDrawMessage();
            gameEndedNaturally = true;
            TryNewGame();
        }

        private void LANHandler_OnDrawDeclined(object sender, EventArgs e)
        {
            InvokeOnUI(new Action(gameDialog.ShowDrawDeclinedMessage));
        }

        private void LANHandler_OnTakebackOffered(object sender, EventArgs e)
        {
            InvokeOnUI(new Action(HandleTakebackOfferReceived));
        }

        private void HandleTakebackOfferReceived()
        {
            if (game == null || game.GameState == null)
                return;

            if (gameDialog.ShowTakebackOfferReceivedDialog())
            {
                lanHandler.SendTakebackAcceptAsync();
                PerformTakeback();
                
                // Only show success message if takeback completed without error
                if (game.GameState != null)
                    gameDialog.ShowTakebackAcceptedMessage();
            }
            else
                lanHandler.SendTakebackDeclineAsync();
        }

        private void LANHandler_OnTakebackAccepted(object sender, EventArgs e)
        {
            InvokeOnUI(new Action(HandleTakebackAccepted));
        }

        private void HandleTakebackAccepted()
        {
            if (game == null || game.GameState == null)
                return;

            PerformTakeback();
            
            // Only show success message if takeback completed without error
            if (game.GameState != null)
                gameDialog.ShowOpponentAcceptedTakebackMessage();
        }

        private void LANHandler_OnTakebackDeclined(object sender, EventArgs e)
        {
            InvokeOnUI(new Action(gameDialog.ShowTakebackDeclinedMessage));
        }

        private void LANHandler_OnOpponentResigned(object sender, EventArgs e)
        {
            InvokeOnUI(new Action(HandleOpponentResigned));
        }

        private void HandleOpponentResigned()
        {
            game.GameState.Status = GameState.GameStatus.Checkmate;
            Deselect();
            gameDialog.ShowOpponentResignedMessage();
            gameEndedNaturally = true;
            TryNewGame();
        }

        private void LANHandler_OnOpponentDisconnected(object sender, EventArgs e)
        {
            InvokeOnUI(new Action(HandleOpponentDisconnected));
        }

        private void HandleOpponentDisconnected()
        {
            gameDialog.ShowOpponentDisconnectedMessage();
            gameEndedNaturally = true; // Don't ask for confirmation since opponent already left
            
            if (lanHandler != null)
            {
                lanHandler.Dispose();
                lanHandler = null;
            }
            
            // Return to splash screen
            toSplash = true;
            Close();
        }

        #endregion

        #region LAN Helpers

        private void InvokeOnUI(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void EndGameAsDraw()
        {
            game.GameState.Status = GameState.GameStatus.Draw;
            Deselect();
        }

        private void PerformTakeback()
        {
            if (game == null || game.GameState == null)
                return;

            try
            {
                if (game.GameState.MoveHistory.Count >= TAKEBACK_BOTH_MOVES)
                {
                    game.UndoLastMove();
                    game.UndoLastMove();
                }
                else if (game.GameState.MoveHistory.Count == TAKEBACK_SINGLE_MOVE)
                {
                    game.UndoLastMove();
                }
                UpdateBoard();
            }
            catch (Exception ex)
            {
                // Log the error and show user-friendly message
                formLib.ShowInfoMessage($"Unable to undo move: {ex.Message}");
                
                // Attempt to refresh the board state
                try
                {
                    UpdateBoard();
                }
                catch
                {
                    // If even update fails, just invalidate
                    BoardPanel.Invalidate();
                }
            }
        }

        private bool IsLocalPlayerTurn()
        {
            return lanHandler == null || lanHandler.IsLocalPlayerTurn(game.GameState.CurrentTurn);
        }

        private bool CanSelectPieceInLAN(char pieceColor)
        {
            return lanHandler == null || lanHandler.CanSelectPiece(pieceColor, game.GameState.CurrentTurn);
        }

        #endregion

        #region Board Rendering and Interaction

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            if (game == null)
                return;

            gameLib.RenderBoard(e.Graphics, BoardPanel, game, pieceImages, lightSquareImage, darkSquareImage,
                selectedX, selectedY, isPieceSelected, legalMoves, highlightColor, captureColor, selectionColor, isBoardFlipped);
        }

        private void BoardPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (game == null || game.GameState.IsGameOver()) 
                return;

            // In LAN mode, only allow moves on your turn
            if (lanHandler != null && !lanHandler.IsLocalPlayerTurn(game.GameState.CurrentTurn))
                return;

            // Calculate square size
            int panelSize = Math.Min(BoardPanel.Width, BoardPanel.Height);
            int squareSize = panelSize / BOARD_SIZE;
            if (squareSize <= 0) return;

            // Calculate offsets to center the board
            int offsetX = (BoardPanel.Width - (squareSize * BOARD_SIZE)) / 2;
            int offsetY = (BoardPanel.Height - (squareSize * BOARD_SIZE)) / 2;

            // Determine clicked square
            int clickedCol = (e.X - offsetX) / squareSize;
            int clickedRow = (e.Y - offsetY) / squareSize;

            // Convert display coordinates to board coordinates
            int boardX = isBoardFlipped ? MAX_BOARD_INDEX - clickedCol : clickedCol;
            int boardY = isBoardFlipped ? clickedRow : MAX_BOARD_INDEX - clickedRow;

            // Validate click is on board
            if (boardX < MIN_BOARD_INDEX || boardX > MAX_BOARD_INDEX || boardY < MIN_BOARD_INDEX || boardY > MAX_BOARD_INDEX)
                return;

            HandleSquareClick(boardX, boardY);
        }

        private void HandleSquareClick(int x, int y)
        {
            Piece clickedPiece = game.GameState.Board.GetPiece(x, y);

            if (isPieceSelected)
            {
                // Deselect if clicking the same square
                if (x == selectedX && y == selectedY)
                {
                    Deselect();
                    return;
                }

                // Check if clicking on a legal move
                if (legalMoves.Exists(move => move.x == x && move.y == y))
                    ExecuteMove(selectedX, selectedY, x, y);
                else if (clickedPiece != null && clickedPiece.Color == game.GameState.CurrentTurn)
                {
                    // Select different piece of same color
                    if (lanHandler == null || lanHandler.IsLocalPlayerPiece(clickedPiece.Color))
                        SelectPiece(x, y);
                    else
                        Deselect();
                }
                else
                    // Clicked on empty square or opponent piece (not a legal move)
                    Deselect();
            }
            else
            {
                // No piece selected - try to select one
                if (clickedPiece != null && clickedPiece.Color == game.GameState.CurrentTurn)
                    if (lanHandler == null || lanHandler.IsLocalPlayerPiece(clickedPiece.Color))
                        SelectPiece(x, y);
            }

            BoardPanel.Invalidate();
        }

        private void SelectPiece(int col, int row)
        {
            if (game.GameState.IsGameOver() || !IsLocalPlayerTurn())
                return;

            Piece piece = game.GameState.Board.GetPiece(col, row);
            if (piece != null && game.GameState.IsValidTurn(piece.Color) && CanSelectPieceInLAN(piece.Color))
            {
                selectedX = col;
                selectedY = row;
                isPieceSelected = true;
                legalMoves = game.GetLegalMovesForPiece(col, row);
                BoardPanel.Invalidate();
            }
        }

        private void Deselect()
        {
            isPieceSelected = false;
            selectedX = NO_SELECTION;
            selectedY = NO_SELECTION;
            legalMoves.Clear();
            BoardPanel.Invalidate();
        }

        private void ExecuteMove(int fromX, int fromY, int toX, int toY)
        {
            char promotionPiece = 'Q';

            // Check for pawn promotion using the Game's method
            if (game.IsPromotionMove(fromX, fromY, toX, toY))
                promotionPiece = ShowPromotionDialog();

            if (game.TryMovePiece(fromX, fromY, toX, toY, promotionPiece))
            {
                // Send move to opponent in LAN mode
                if (lanHandler != null)
                    lanHandler.SendMoveAsync(fromX, fromY, toX, toY, promotionPiece);

                UpdateBoard();
                CheckGameStatus();
            }
            else
                Deselect();
        }

        private char ShowPromotionDialog()
        {
            using (Form promotionForm = new Form())
            {
                // Configure form
                promotionForm.Text = "Choose Promotion";
                promotionForm.Size = new Size(PROMOTION_DIALOG_WIDTH, PROMOTION_DIALOG_HEIGHT);
                promotionForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                promotionForm.StartPosition = FormStartPosition.CenterParent;
                promotionForm.MaximizeBox = false;
                promotionForm.MaximizeBox = false;
                promotionForm.MinimizeBox = false;

                char result = 'Q';
                string[] pieces = { "Queen", "Rook", "Bishop", "Knight" };
                char[] pieceChars = { 'Q', 'R', 'B', 'N' };

                // Create buttons for each piece
                for (int i = 0; i < pieces.Length; i++)
                {
                    Button button = new Button
                    {
                        Text = pieces[i],
                        Location = new Point(PROMOTION_BUTTON_START_X + i * PROMOTION_BUTTON_SPACING, PROMOTION_BUTTON_Y),
                        Size = new Size(PROMOTION_BUTTON_WIDTH, PROMOTION_BUTTON_HEIGHT),
                        Tag = pieceChars[i]
                    };
                    button.Click += (sender, e) =>
                    {
                        result = (char)((Button)sender).Tag;
                        promotionForm.DialogResult = DialogResult.OK;
                        promotionForm.Close();
                    };
                    promotionForm.Controls.Add(button);
                }

                promotionForm.ShowDialog(this);
                return result;
            }
        }

        private void UpdateBoard()
        {
            Deselect();
            gameLib.UpdateMoveHistory(MovesListView, game.GameState.MoveHistory);
            BoardPanel.Invalidate();
        }

        private void CheckGameStatus()
        {
            gameLib.ShowGameStatusMessage(game.GameState.Status, game.GameState.CurrentTurn);
            
            // If game ended via checkmate or stalemate (not resign/draw button), mark as naturally ended
            if (game.GameState.IsGameOver() && !gameEndedNaturally)
            {
                gameEndedNaturally = true;
                // Automatically trigger new game prompt after checkmate/stalemate
                TryNewGame();
            }
        }

        #endregion

        #region Form Events

        protected override void OnResize(EventArgs e)
        {
            formLib.ApplyAll(this);
            //BoardPanel.Invalidate();
            base.OnResize(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (formLib.ProcessFullscreenKeys(this, keyData, ref isFullscreen))
                formLib.ToggleFullscreen(this, ref isFullscreen);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (lanHandler != null) // LAN game
                {
                    if (toSplash) // User wants to return to splash screen
                    {
                        // Only show confirmation if game hasn't ended naturally
                        if (!gameEndedNaturally && !gameDialog.ShowLeaveGameConfirmation())
                        {
                            e.Cancel = true;
                            return;
                        }

                        // If game ended naturally, confirmation was already handled in TryNewGame
                        if (!gameEndedNaturally)
                            lanHandler.ResignAndDisconnectAsync();

                        splashScreen.Show();

                        // Synchronize fullscreen state with splash screen
                        if (isFullscreen != splashScreen.isFullscreen)
                            formLib.ToggleFullscreen(splashScreen, ref splashScreen.isFullscreen);
                    }
                    else // Opponent disconnected or other reason - just close
                    {
                        // Cleanup without going to splash
                        lanHandler?.DisconnectAsync();
                    }
                }
                else // Offline game
                {
                    if (toSplash) // User wants to return to menu
                    {
                        // Only show confirmation if game hasn't ended naturally
                        if (!gameEndedNaturally && !gameDialog.ShowReturnToMenuDialog())
                        {
                            e.Cancel = true;
                            return;
                        }

                        splashScreen.Show();

                        // Synchronize fullscreen state with splash screen
                        if (isFullscreen != splashScreen.isFullscreen)
                            formLib.ToggleFullscreen(splashScreen, ref splashScreen.isFullscreen);
                    }
                }
            }

            base.OnFormClosing(e);
        }

        #endregion

        #region Button Events

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            toSplash = true;
            Close();
        }

        private void FullscreenButton_Click(object sender, EventArgs e)
        {
            formLib.ToggleFullscreen(this, ref isFullscreen);
        }

        private void SwitchViewButton_Click(object sender, EventArgs e)
        {
            isBoardFlipped = !isBoardFlipped;
            UpdateBoard();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            if (game == null || game.GameState.IsGameOver()) 
                return;

            if (lanHandler != null) // LAN mode
            {
                // Send draw offer to opponent
                lanHandler.SendDrawOfferAsync();
                gameDialog.ShowDrawOfferSentMessage();
            }
            else
                // Offline: Just end in draw
                if (formLib.ShowConfirmDialog("Do both players agree to a draw?", "Draw"))
                {
                    EndGameAsDraw();
                    formLib.ShowInfoMessage("Draw offer accepted. The game is a draw.");
                    gameEndedNaturally = true;
                    TryNewGame();
                }
        }

        private void TakebackButton_Click(object sender, EventArgs e)
        {
            if (game == null || game.GameState.IsGameOver()) 
                return;

            if (game.GameState.MoveHistory.Count == 0) 
                return;

            if (lanHandler != null)
            {
                // Request takeback from opponent
                lanHandler.SendTakebackOfferAsync();
                gameDialog.ShowTakebackOfferSentMessage();
            }
            else // Offline mode - just undo the move
                PerformTakeback();
        }

        private void ResignButton_Click(object sender, EventArgs e)
        {
            if (game == null || game.GameState.IsGameOver()) 
                return;

            if (gameDialog.ShowResignConfirmation())
            {
                if (lanHandler != null)
                    lanHandler.SendResignAsync();

                game.GameState.Status = GameState.GameStatus.Checkmate;
                Deselect();
                gameDialog.ShowResignationMessage();
                gameEndedNaturally = true;
                TryNewGame();
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            gameLib.ShowExportDialog(game);
        }

        #endregion

        #region Other Methods
        private void TryNewGame()
        {
            if (lanHandler == null) // In offline mode only
            {
                
                if (formLib.ShowConfirmDialog("Do you want to play again?"))
                {
                    GameForm newGame = new GameForm(splashScreen);
                    toSplash = false;
                    Close();
                }
            }
        }

        #endregion

    }
}