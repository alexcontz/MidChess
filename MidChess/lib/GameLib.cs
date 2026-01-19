using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MidChess.board;
using MidChess.game;

namespace MidChess.lib
{
    public class GameLib
    {
        private Dictionary<string, Image> pieceImages;
        private Image lightSquareImage;
        private Image darkSquareImage;

        #region Image Loading

        /// <summary>
        /// Loads all piece images from the assets folder
        /// </summary>
        public Dictionary<string, Image> LoadPieceImages()
        {
            pieceImages = new Dictionary<string, Image>();
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "images", "pieces");
            
            try
            {
                string[] pieceTypes = { "pawn", "rook", "knight", "bishop", "queen", "king" };
                char[] colors = { 'w', 'b' };
                
                foreach (char color in colors)
                {
                    foreach (string pieceType in pieceTypes)
                    {
                        string key = $"{color}_{pieceType}";
                        string imagePath = Path.Combine(basePath, $"{key}.png");
                        
                        if (File.Exists(imagePath))
                            pieceImages[key] = Image.FromFile(imagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading piece images: {ex.Message}", "Image Load Error");
            }

            return pieceImages;
        }

        /// <summary>
        /// Loads board square images
        /// </summary>
        public void LoadSquareImages(out Image light, out Image dark)
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "images");
            light = null;
            dark = null;
            
            try
            {
                string lightPath = Path.Combine(basePath, "square_brown_light.png");
                string darkPath = Path.Combine(basePath, "square_brown_dark.png");
                
                if (File.Exists(lightPath)) light = Image.FromFile(lightPath);
                if (File.Exists(darkPath)) dark = Image.FromFile(darkPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading square images: {ex.Message}", "Image Load Error");
            }

            lightSquareImage = light;
            darkSquareImage = dark;
        }

        #endregion

        #region Move History and Notation

        /// <summary>
        /// Updates the ListView with current move history
        /// </summary>
        public void UpdateMoveHistory(ListView listView, List<Move> moves)
        {
            listView.BeginUpdate();
            listView.Items.Clear();
            
            for (int i = 0; i < moves.Count; i += 2)
            {
                int moveNumber = (i / 2) + 1;
                string whiteMove = ConvertMoveToAlgebraic(moves[i]);
                string blackMove = i + 1 < moves.Count ? ConvertMoveToAlgebraic(moves[i + 1]) : "";
                
                ListViewItem item = new ListViewItem(moveNumber.ToString());
                item.SubItems.Add(whiteMove);
                item.SubItems.Add(blackMove);
                listView.Items.Add(item);
            }
            
            if (listView.Items.Count > 0)
                listView.EnsureVisible(listView.Items.Count - 1);
            
            listView.EndUpdate();
        }

        /// <summary>
        /// Converts a move to algebraic chess notation
        /// </summary>
        public string ConvertMoveToAlgebraic(Move move)
        {
            if (move == null) return "";
            
            Piece piece = move.MovedPiece;
            
            // Check for castling
            if (piece is King && Math.Abs(move.ToX - move.FromX) == 2)
                return move.ToX > move.FromX ? "O-O" : "O-O-O";
            
            string notation = "";
            
            // Check if this was a pawn that got promoted
            bool wasPromoted = !(piece is Pawn) && (move.ToY == 7 || move.ToY == 0) && 
                               (move.FromY == 6 || move.FromY == 1);
            
            // For promoted pawns, use empty symbol initially
            string pieceSymbol = wasPromoted ? "" : GetPieceSymbol(piece);
            notation += pieceSymbol;
            
            // Add disambiguation for non-pawn pieces (but not for promoted pawns)
            if (!(piece is Pawn) && !wasPromoted && !string.IsNullOrEmpty(move.Disambiguation))
                notation += move.Disambiguation;
            
            // For captures, add the from file (column) for pawns or promoted pawns
            if (move.CapturedPiece != null && (piece is Pawn || wasPromoted))
                notation += GetFileNotation(move.FromX);
            
            // Add capture symbol if applicable
            if (move.CapturedPiece != null)
                notation += "x";
            
            // Add destination square
            notation += GetSquareNotation(move.ToX, move.ToY);
            
            // Add promotion notation
            if (wasPromoted)
                notation += "=" + GetPieceSymbol(piece);
            
            return notation;
        }

        #endregion

        #region Notation Helper Methods

        public string GetPieceSymbol(Piece piece)
        {
            if (piece is King) return "K";
            if (piece is Queen) return "Q";
            if (piece is Rook) return "R";
            if (piece is Bishop) return "B";
            if (piece is Knight) return "N";
            return "";
        }

        public string GetFileNotation(int x) => ((char)('a' + x)).ToString();

        public string GetRankNotation(int y) => (y + 1).ToString();

        public string GetSquareNotation(int x, int y) => GetFileNotation(x) + GetRankNotation(y);

        public string GetPieceImageKey(Piece piece) => $"{piece.Color}_{piece.GetType().Name.ToLower()}";

        #endregion

        #region Board Rendering

        /// <summary>
        /// Renders the complete chess board with pieces and highlights
        /// </summary>
        public void RenderBoard(Graphics g, Panel panel, Game game, 
            Dictionary<string, Image> images, Image lightSquare, Image darkSquare,
            int selectedX, int selectedY, bool isPieceSelected,
            List<(int x, int y)> legalMoves,
            Color highlightColor, Color captureColor, Color selectionColor,
            bool flipBoard = false)
        {
            if (panel.Width <= 0 || panel.Height <= 0) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            
            int panelSize = Math.Min(panel.Width, panel.Height);
            int squareSize = panelSize / 8;
            
            if (squareSize <= 0) return;
            
            int offsetX = (panel.Width - (squareSize * 8)) / 2;
            int offsetY = (panel.Height - (squareSize * 8)) / 2;
            
            // Draw board squares
            DrawBoardSquares(g, offsetX, offsetY, squareSize, lightSquare, darkSquare, flipBoard);
            
            // Draw legal move highlights
            DrawLegalMoveHighlights(g, game.GameState.Board, legalMoves, offsetX, offsetY, squareSize, highlightColor, flipBoard);
            
            // Draw pieces
            DrawPieces(g, game.GameState.Board, images, offsetX, offsetY, squareSize,
                selectedX, selectedY, isPieceSelected, legalMoves, captureColor, selectionColor, flipBoard);
        }

        private void DrawBoardSquares(Graphics g, int offsetX, int offsetY, int squareSize, Image lightSquare, Image darkSquare, bool flipBoard)
        {
            for (int row = 0; row < 8; row++)
                for (int col = 0; col < 8; col++)
                {
                    int displayCol = flipBoard ? 7 - col : col;
                    int displayRow = flipBoard ? row : 7 - row;
                    
                    bool isLightSquare = (row + col) % 2 == 0;
                    Rectangle rect = new Rectangle(offsetX + displayCol * squareSize, offsetY + displayRow * squareSize, squareSize, squareSize);
                    
                    if (isLightSquare && lightSquare != null)
                        g.DrawImage(lightSquare, rect);
                    else if (!isLightSquare && darkSquare != null)
                        g.DrawImage(darkSquare, rect);
                    else
                    {
                        Color color = isLightSquare ? Color.FromArgb(240, 217, 181) : Color.FromArgb(181, 136, 99);
                        using (SolidBrush brush = new SolidBrush(color))
                            g.FillRectangle(brush, rect);
                    }
                }
        }

        private void DrawLegalMoveHighlights(Graphics g, Board board, List<(int x, int y)> legalMoves, 
            int offsetX, int offsetY, int squareSize, Color highlightColor, bool flipBoard)
        {
            foreach (var move in legalMoves)
            {
                int displayCol = flipBoard ? 7 - move.x : move.x;
                int displayRow = flipBoard ? move.y : 7 - move.y;
                
                Rectangle moveRect = new Rectangle(offsetX + displayCol * squareSize, offsetY + displayRow * squareSize, squareSize, squareSize);
                
                if (board.GetPiece(move.x, move.y) == null)
                    using (SolidBrush brush = new SolidBrush(highlightColor))
                    {
                        int circleSize = squareSize / 3;
                        int circlePadding = (squareSize - circleSize) / 2;
                        Rectangle circleRect = new Rectangle(moveRect.X + circlePadding, moveRect.Y + circlePadding, circleSize, circleSize);
                        g.FillEllipse(brush, circleRect);
                    }
            }
        }

        private void DrawPieces(Graphics g, Board board, Dictionary<string, Image> images, 
            int offsetX, int offsetY, int squareSize,
            int selectedX, int selectedY, bool isPieceSelected,
            List<(int x, int y)> legalMoves, Color captureColor, Color selectionColor, bool flipBoard)
        {
            for (int row = 0; row < 8; row++)
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = board.GetPiece(col, row);
                    if (piece != null)
                    {
                        string pieceKey = GetPieceImageKey(piece);
                        
                        if (images.ContainsKey(pieceKey))
                        {
                            int displayCol = flipBoard ? 7 - col : col;
                            int displayRow = flipBoard ? row : 7 - row;
                            
                            Rectangle pieceRect = new Rectangle(offsetX + displayCol * squareSize, offsetY + displayRow * squareSize, squareSize, squareSize);
                            
                            int padding = squareSize / 10;
                            Rectangle drawRect = new Rectangle(pieceRect.X + padding, pieceRect.Y + padding, 
                                pieceRect.Width - (padding * 2), pieceRect.Height - (padding * 2));
                            
                            g.DrawImage(images[pieceKey], drawRect);
                            
                            // Draw selection border
                            if (isPieceSelected && col == selectedX && row == selectedY)
                                using (Pen pen = new Pen(selectionColor, 3))
                                    g.DrawRectangle(pen, pieceRect);
                            
                            // Draw capture border
                            if (isPieceSelected)
                            {
                                bool canCapture = false;
                                for (int i = 0; i < legalMoves.Count; i++)
                                    if (legalMoves[i].x == col && legalMoves[i].y == row)
                                    {
                                        canCapture = true;
                                        break;
                                    }
                                
                                if (canCapture)
                                    using (Pen pen = new Pen(captureColor, 3))
                                        g.DrawRectangle(pen, pieceRect);
                            }
                        }
                    }
                }
        }

        #endregion

        #region Board Interaction

        /// <summary>
        /// Converts mouse coordinates to board coordinates
        /// </summary>
        public (int col, int row) GetBoardCoordinates(int mouseX, int mouseY, Panel panel, bool flipBoard = false)
        {
            int panelSize = Math.Min(panel.Width, panel.Height);
            int squareSize = panelSize / 8;
            int offsetX = (panel.Width - (squareSize * 8)) / 2;
            int offsetY = (panel.Height - (squareSize * 8)) / 2;
            
            int displayCol = (mouseX - offsetX) / squareSize;
            int displayRow = (mouseY - offsetY) / squareSize;
            
            int col = flipBoard ? 7 - displayCol : displayCol;
            int row = flipBoard ? displayRow : 7 - displayRow;
            
            return (col, row);
        }

        /// <summary>
        /// Checks if coordinates are within board bounds
        /// </summary>
        public bool IsWithinBounds(int col, int row) 
        {
            return (col >= 0 && col < 8 && row >= 0 && row < 8);
        }

        #endregion

        #region Pawn Promotion Dialog

        /// <summary>
        /// Shows promotion dialog and returns selected piece
        /// </summary>
        public char ShowPromotionDialog(Form parent)
        {
            using (Form promotionForm = new Form())
            {
                promotionForm.Text = "Pawn Promotion";
                promotionForm.Size = new Size(300, 150);
                promotionForm.StartPosition = FormStartPosition.CenterParent;
                promotionForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                promotionForm.MaximizeBox = false;
                promotionForm.MinimizeBox = false;

                Label label = new Label { Text = "Choose piece to promote to:", Location = new Point(20, 20), Size = new Size(250, 20) };
                promotionForm.Controls.Add(label);

                char selectedPiece = 'Q';

                Button queenBtn = new Button { Text = "Queen", Location = new Point(20, 50), Size = new Size(55, 30), DialogResult = DialogResult.OK };
                Button rookBtn = new Button { Text = "Rook", Location = new Point(80, 50), Size = new Size(55, 30), DialogResult = DialogResult.OK };
                Button bishopBtn = new Button { Text = "Bishop", Location = new Point(140, 50), Size = new Size(55, 30), DialogResult = DialogResult.OK };
                Button knightBtn = new Button { Text = "Knight", Location = new Point(200, 50), Size = new Size(55, 30), DialogResult = DialogResult.OK };

                queenBtn.Click += (s, e) => { selectedPiece = 'Q'; };
                rookBtn.Click += (s, e) => { selectedPiece = 'R'; };
                bishopBtn.Click += (s, e) => { selectedPiece = 'B'; };
                knightBtn.Click += (s, e) => { selectedPiece = 'N'; };

                promotionForm.Controls.Add(queenBtn);
                promotionForm.Controls.Add(rookBtn);
                promotionForm.Controls.Add(bishopBtn);
                promotionForm.Controls.Add(knightBtn);

                promotionForm.AcceptButton = queenBtn;
                promotionForm.ShowDialog(parent);
                
                return selectedPiece;
            }
        }

        #endregion

        #region Game State Messages

        /// <summary>
        /// Shows appropriate message for game status
        /// </summary>
        public void ShowGameStatusMessage(GameState.GameStatus status, char currentTurn)
        {
            switch (status)
            {
                case GameState.GameStatus.Checkmate:
                    char winner = currentTurn == 'w' ? 'b' : 'w';
                    MessageBox.Show($"Checkmate! {(winner == 'w' ? "White" : "Black")} wins!", "Game Over");
                    break;
                case GameState.GameStatus.Stalemate:
                    MessageBox.Show("Stalemate! The game is a draw.", "Game Over");
                    break;
                case GameState.GameStatus.Check:
                    MessageBox.Show($"{(currentTurn == 'w' ? "White" : "Black")} is in check!", "Check");
                    break;
            }
        }

        #endregion

        #region Game Export

        /// <summary>
        /// Exports game to file with algebraic and detailed notation
        /// </summary>
        public void ExportGameToFile(string filePath, Game game)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MidChess Game Export");
            sb.AppendLine($"Date: {DateTime.Now:dd--MM--yyyy HH:mm:ss}");
            sb.AppendLine($"Total Moves: {game.GameState.MoveCount}");
            sb.AppendLine($"Game Status: {game.GameState.Status}");
            sb.AppendLine();
            sb.AppendLine("Move History:");
            sb.AppendLine("-------------");

            List<Move> moves = game.GameState.MoveHistory;

            // Algebraic notation
            sb.AppendLine();
            sb.AppendLine("Algebraic Notation:");
            for (int i = 0; i < moves.Count; i += 2)
            {
                int moveNumber = (i / 2) + 1;
                string whiteMove = ConvertMoveToAlgebraic(moves[i]);
                string blackMove = i + 1 < moves.Count ? ConvertMoveToAlgebraic(moves[i + 1]) : "";
                sb.AppendLine($"{moveNumber}. {whiteMove} {blackMove}");
            }

            // Detailed format
            sb.AppendLine();
            sb.AppendLine("Detailed Format:");
            foreach (Move move in moves)
            {
                Piece piece = move.MovedPiece;
                string pieceSymbol = GetPieceSymbol(piece);
                if (string.IsNullOrEmpty(pieceSymbol)) pieceSymbol = "P";
                    
                sb.AppendLine($"{piece.Color}|{pieceSymbol}|" +
                    $"{GetSquareNotation(move.FromX, move.FromY)}|{GetSquareNotation(move.ToX, move.ToY)}|" +
                    $"{(move.CapturedPiece != null ? "capture" : "move")}");
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        /// <summary>
        /// Shows export dialog and exports if user confirms
        /// </summary>
        public void ShowExportDialog(Game game)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    saveDialog.Title = "Export Game Moves";
                    saveDialog.FileName = $"ChessGame_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportGameToFile(saveDialog.FileName, game);
                        MessageBox.Show($"Game exported successfully to:\n{saveDialog.FileName}",
                            "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting game: {ex.Message}",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}