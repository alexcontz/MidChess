using System;
using System.Collections.Generic;
using MidChess.board;

namespace MidChess.game
{
    public class Game
    {
        public GameState GameState { get; private set; }

        #region Constructor and Initialization

        public Game()
        {
            GameState = new GameState();
            InitializeBoard(GameState.Board);
        }

        private void InitializeBoard(Board board)
        {
            // Initialize pawns
            for (int x = 0; x < 8; x++)
            {
                board.PlacePiece(new Pawn('w'), x, 1);
                board.PlacePiece(new Pawn('b'), x, 6);
            }

            // Initialize rooks
            board.PlacePiece(new Rook('w'), 0, 0);
            board.PlacePiece(new Rook('w'), 7, 0);
            board.PlacePiece(new Rook('b'), 0, 7);
            board.PlacePiece(new Rook('b'), 7, 7);

            // Initialize knights
            board.PlacePiece(new Knight('w'), 1, 0);
            board.PlacePiece(new Knight('w'), 6, 0);
            board.PlacePiece(new Knight('b'), 1, 7);
            board.PlacePiece(new Knight('b'), 6, 7);

            // Initialize bishops
            board.PlacePiece(new Bishop('w'), 2, 0);
            board.PlacePiece(new Bishop('w'), 5, 0);
            board.PlacePiece(new Bishop('b'), 2, 7);
            board.PlacePiece(new Bishop('b'), 5, 7);

            // Initialize queens
            board.PlacePiece(new Queen('w'), 3, 0);
            board.PlacePiece(new Queen('b'), 3, 7);

            // Initialize kings
            board.PlacePiece(new King('w'), 4, 0);
            board.PlacePiece(new King('b'), 4, 7);
        }

        #endregion

        #region Move Methods

        /// <summary>
        /// Attempts to move a piece from one position to another with full validation.
        /// </summary>
        public bool TryMovePiece(int fromX, int fromY, int toX, int toY, char promotionPiece = 'Q')
        {
            Board board = GameState.Board;

            if (GameState.IsGameOver())
                return false;

            // Validate coordinates are on the board
            if (!board.IsOnBoard(fromX, fromY) || !board.IsOnBoard(toX, toY))
                return false;

            // Check if there's a piece at the source position
            if (board.IsEmpty(fromX, fromY))
                return false;

            Piece piece = board.GetPiece(fromX, fromY);

            // Validate it's this piece's color's turn
            if (!GameState.IsValidTurn(piece.Color))
                return false;

            // Check if the move is legal for this piece
            List<(int x, int y)> legalMoves;
            
            if (piece is Pawn pawn)
                legalMoves = pawn.GetLegalMoves(board, fromX, fromY, GameState.GetLastMove());
            else
                legalMoves = piece.GetLegalMoves(board, fromX, fromY);

            // Check if the desired move is in the list of legal moves
            bool isLegalMove = false;
            for (int i = 0; i < legalMoves.Count; i++)
                if (legalMoves[i].x == toX && legalMoves[i].y == toY)
                {
                    isLegalMove = true;
                    break;
                }

            if (!isLegalMove)
                return false;

            // Detect special moves
            bool isCastling = IsCastlingMove(fromX, fromY, toX, toY);
            bool isEnPassant = IsEnPassantMove(fromX, fromY, toX, toY);
            bool isPromotion = IsPromotionMove(fromX, fromY, toX, toY);
            
            // Calculate disambiguation before move is executed
            string disambiguation = GetDisambiguation(fromX, fromY, toX, toY);

            if (isCastling)
                // Special validation for castling
                if (WouldCastlingMoveThroughCheck(fromX, fromY, toX, toY))
                    return false;
            else
                // Normal move - check if it would leave king in check
                if (WouldMoveCauseCheck(fromX, fromY, toX, toY))
                    return false;

            // Execute the move
            Piece capturedPiece = null;

            if (isCastling)
                ExecuteCastling(fromX, fromY, toX, toY);
            else if (isEnPassant)
                capturedPiece = ExecuteEnPassant(fromX, fromY, toX, toY);
            else
            {
                capturedPiece = board.GetPiece(toX, toY);
                board.MovePiece(fromX, fromY, toX, toY);
            }

            // Mark piece as moved (for castling/pawn double-move tracking)
            piece.HasMoved = true;

            // Handle pawn promotion
            if (isPromotion)
            {
                PromotePawn(toX, toY, piece.Color, promotionPiece);
                piece = board.GetPiece(toX, toY); // Update piece reference to promoted piece
            }

            // Record the move in history
            Move move = new Move(fromX, fromY, toX, toY, piece, capturedPiece);
            move.Disambiguation = disambiguation;
            GameState.RecordMove(move);

            // Switch turns
            GameState.SwitchTurn();

            // Check for game-ending conditions for the new current player
            GameState.Status = GetGameStatus(GameState.CurrentTurn);

            return true;
        }

        /// <summary>
        /// Undoes the last move in the game. Returns true if successful, false if no moves to undo.
        /// </summary>
        public bool UndoLastMove()
        {
            if (GameState.MoveHistory.Count == 0)
                return false;

            Move lastMove = GameState.MoveHistory[GameState.MoveHistory.Count - 1];
            Board board = GameState.Board;

            // Get the piece at destination (might be promoted)
            Piece movedPiece = board.GetPiece(lastMove.ToX, lastMove.ToY);
            
            // Determine if this was en passant by checking the move record
            // En passant is the ONLY case where a pawn captures diagonally AND the captured piece is recorded
            // but wasn't actually at the destination square
            bool wasEnPassant = false;
            if (lastMove.MovedPiece is Pawn && lastMove.CapturedPiece != null && lastMove.ToX != lastMove.FromX)
            {
                // This was a diagonal pawn move with a capture
                // Check if it was en passant by seeing if there was a recent two-square pawn move
                // For now, we can detect it by checking: was the captured piece a pawn on the same file as destination?
                // In en passant, the captured pawn is at (toX, fromY), not at (toX, toY)
                
                // If the last move before this one was a two-square pawn advance to the square beside us, it's en passant
                if (GameState.MoveHistory.Count >= 2)
                {
                    Move previousMove = GameState.MoveHistory[GameState.MoveHistory.Count - 2];
                    if (previousMove.MovedPiece is Pawn && 
                        Math.Abs(previousMove.ToY - previousMove.FromY) == 2 && 
                        previousMove.ToX == lastMove.ToX &&
                        previousMove.ToY == lastMove.FromY)
                    {
                        wasEnPassant = true;
                    }
                }
            }
            
            // Move piece back to original position
            board.MovePiece(lastMove.ToX, lastMove.ToY, lastMove.FromX, lastMove.FromY);
            
            // Restore the original piece if it was promoted
            if (movedPiece != null && lastMove.MovedPiece.GetType() != movedPiece.GetType())
            {
                board.BoardMatrix[lastMove.FromX, lastMove.FromY] = lastMove.MovedPiece;
            }
            
            // Restore captured piece if any
            if (lastMove.CapturedPiece != null)
            {
                if (wasEnPassant)
                {
                    // En passant - restore captured pawn to its original position (same column as destination, same rank as origin)
                    int capturedPawnY = lastMove.FromY;
                    board.PlacePiece(lastMove.CapturedPiece, lastMove.ToX, capturedPawnY);
                }
                else
                {
                    // Normal capture (including normal pawn captures) - restore captured piece to destination
                    board.PlacePiece(lastMove.CapturedPiece, lastMove.ToX, lastMove.ToY);
                }
            }
            
            // Handle castling undo
            if (lastMove.MovedPiece is King && Math.Abs(lastMove.ToX - lastMove.FromX) == 2)
            {
                int backRank = lastMove.FromY;
                if (lastMove.ToX == 6) // King-side castling
                {
                    // Move rook back from f-file (5) to h-file (7)
                    board.MovePiece(5, backRank, 7, backRank);
                    Piece rook = board.GetPiece(7, backRank);
                    if (rook != null)
                        rook.HasMoved = false;
                }
                else if (lastMove.ToX == 2) // Queen-side castling
                {
                    // Move rook back from d-file (3) to a-file (0)
                    board.MovePiece(3, backRank, 0, backRank);
                    Piece rook = board.GetPiece(0, backRank);
                    if (rook != null)
                        rook.HasMoved = false;
                }
            }
            
            // Restore HasMoved flag if this was the piece's first move
            Piece restoredPiece = board.GetPiece(lastMove.FromX, lastMove.FromY);
            if (restoredPiece != null && (GameState.MoveHistory.Count == 1 || !WasPieceMovedBefore(lastMove.FromX, lastMove.FromY, GameState.MoveHistory.Count - 1)))
            {
                restoredPiece.HasMoved = false;
            }
            
            // Remove move from history
            GameState.MoveHistory.RemoveAt(GameState.MoveHistory.Count - 1);
            GameState.MoveCount--;
            
            // Switch turn back
            GameState.SwitchTurn();
            
            // Recalculate game status
            GameState.Status = GetGameStatus(GameState.CurrentTurn);
            
            return true;
        }
        
        /// <summary>
        /// Checks if a piece at given position was moved in any previous move.
        /// </summary>
        private bool WasPieceMovedBefore(int x, int y, int beforeMoveIndex)
        {
            for (int i = 0; i < beforeMoveIndex; i++)
            {
                Move move = GameState.MoveHistory[i];
                if ((move.FromX == x && move.FromY == y) || (move.ToX == x && move.ToY == y))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a move is valid without executing it.
        /// </summary>
        public bool IsValidMove(int fromX, int fromY, int toX, int toY)
        {
            Board board = GameState.Board;

            if (!board.IsOnBoard(fromX, fromY) || !board.IsOnBoard(toX, toY))
                return false;

            if (board.IsEmpty(fromX, fromY))
                return false;

            Piece piece = board.GetPiece(fromX, fromY);

            if (!GameState.IsValidTurn(piece.Color))
                return false;

            List<(int x, int y)> legalMoves = piece.GetLegalMoves(board, fromX, fromY);

            // Check if the desired move is in the list of legal moves
            for (int i = 0; i < legalMoves.Count; i++)
            {
                if (legalMoves[i].x == toX && legalMoves[i].y == toY)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets all legal moves for the piece at the specified position.
        /// Returns an empty list if there's no piece or it's not that piece's turn.
        /// This includes filtering out moves that would leave the king in check.
        /// </summary>
        public List<(int x, int y)> GetLegalMovesForPiece(int x, int y)
        {
            Board board = GameState.Board;

            if (!board.IsOnBoard(x, y) || board.IsEmpty(x, y))
                return new List<(int x, int y)>();

            Piece piece = board.GetPiece(x, y);

            if (!GameState.IsValidTurn(piece.Color))
                return new List<(int x, int y)>();

            return GetTrulyLegalMoves(x, y);
        }

        #endregion

        #region Board Query Methods

        /// <summary>
        /// Gets all pieces of the specified color on the board with their positions.
        /// </summary>
        public List<(Piece piece, int x, int y)> GetAllPiecesOfColor(char color)
        {
            List<(Piece piece, int x, int y)> pieces = new List<(Piece, int, int)>();
            Board board = GameState.Board;

            for (int x = 0; x < board.Size; x++)
            {
                for (int y = 0; y < board.Size; y++)
                {
                    if (!board.IsEmpty(x, y))
                    {
                        Piece piece = board.GetPiece(x, y);
                        if (piece.Color == color)
                        {
                            pieces.Add((piece, x, y));
                        }
                    }
                }
            }

            return pieces;
        }

        /// <summary>
        /// Finds the king of the specified color on the board.
        /// </summary>
        private (int x, int y) FindKing(char color)
        {
            Board board = GameState.Board;

            for (int x = 0; x < board.Size; x++)
            {
                for (int y = 0; y < board.Size; y++)
                {
                    if (!board.IsEmpty(x, y))
                    {
                        Piece piece = board.GetPiece(x, y);
                        if (piece is King && piece.Color == color)
                        {
                            return (x, y);
                        }
                    }
                }
            }

            throw new Exception($"King of color '{color}' not found on the board!");
        }

        #endregion

        #region Check and Game Status Methods

        /// <summary>
        /// Checks if the specified color's king is currently in check.
        /// </summary>
        public bool IsKingInCheck(char color)
        {
            (int kingX, int kingY) = FindKing(color);
            char opponentColor = color == 'w' ? 'b' : 'w';
            return IsSquareUnderAttack(kingX, kingY, opponentColor);
        }

        /// <summary>
        /// Checks if a square is under attack by the specified color.
        /// </summary>
        private bool IsSquareUnderAttack(int targetX, int targetY, char attackingColor)
        {
            Board board = GameState.Board;

            for (int x = 0; x < board.Size; x++)
                for (int y = 0; y < board.Size; y++)
                    if (!board.IsEmpty(x, y))
                    {
                        Piece piece = board.GetPiece(x, y);
                        if (piece.Color == attackingColor)
                        {
                            List<(int x, int y)> moves;
                            
                            if (piece is Pawn pawn)
                                moves = pawn.GetLegalMoves(board, x, y, GameState.GetLastMove());
                            else
                                moves = piece.GetLegalMoves(board, x, y);

                            // Check if any move targets the specified square
                            for (int i = 0; i < moves.Count; i++)
                                if (moves[i].x == targetX && moves[i].y == targetY)
                                    return true;
                        }
                    }

            return false;
        }

        /// <summary>
        /// Simulates a move and checks if it would leave the current player's king in check.
        /// This simulates the move temporarily to test for check.
        /// </summary>
        private bool WouldMoveCauseCheck(int fromX, int fromY, int toX, int toY)
        {
            Board board = GameState.Board;
            Piece movingPiece = board.GetPiece(fromX, fromY);
            Piece capturedPiece = board.GetPiece(toX, toY);

            // Simulate the move
            board.MovePiece(fromX, fromY, toX, toY);

            // Check if king is in check after the move
            bool inCheck = IsKingInCheck(movingPiece.Color);

            // Undo the move
            board.MovePiece(toX, toY, fromX, fromY);
            if (capturedPiece != null)
                board.PlacePiece(capturedPiece, toX, toY);

            return inCheck;
        }

        /// <summary>
        /// Gets all truly legal moves for a piece (excluding moves that would leave king in check).
        /// </summary>
        public List<(int x, int y)> GetTrulyLegalMoves(int x, int y)
        {
            Board board = GameState.Board;

            if (!board.IsOnBoard(x, y) || board.IsEmpty(x, y))
                return new List<(int x, int y)>();

            Piece piece = board.GetPiece(x, y);
            List<(int x, int y)> legalMoves;
            
            if (piece is Pawn pawn)
                // Pass last move for en passant detection
                legalMoves = pawn.GetLegalMoves(board, x, y, GameState.GetLastMove());
            else
                legalMoves = piece.GetLegalMoves(board, x, y);

            List<(int x, int y)> trulyLegalMoves = new List<(int x, int y)>();

            // Filter out moves that would leave king in check
            foreach (var move in legalMoves)
                if (!WouldMoveCauseCheck(x, y, move.x, move.y))
                    trulyLegalMoves.Add(move);

            return trulyLegalMoves;
        }

        /// <summary>
        /// Checks if the specified color has any legal moves available.
        /// </summary>
        public bool HasAnyLegalMoves(char color)
        {
            Board board = GameState.Board;

            // Check all pieces of the specified color
            for (int x = 0; x < board.Size; x++)
                for (int y = 0; y < board.Size; y++)
                    if (!board.IsEmpty(x, y))
                    {
                        Piece piece = board.GetPiece(x, y);
                        if (piece.Color == color)
                        {
                            List<(int x, int y)> legalMoves = GetTrulyLegalMoves(x, y);

                            if (legalMoves.Count > 0)
                                return true;
                        }
                    }

            return false;
        }

        /// <summary>
        /// Checks if the specified color is in checkmate.
        /// </summary>
        public bool IsCheckmate(char color)
        {
            return IsKingInCheck(color) && !HasAnyLegalMoves(color);
        }

        /// <summary>
        /// Checks if the specified color is in stalemate.
        /// </summary>
        public bool IsStalemate(char color)
        {
            return !IsKingInCheck(color) && !HasAnyLegalMoves(color);
        }

        /// <summary>
        /// Gets the current game status for the specified color.
        /// </summary>
        public GameState.GameStatus GetGameStatus(char color)
        {
            if (IsCheckmate(color))
                return GameState.GameStatus.Checkmate;

            if (IsStalemate(color))
                return GameState.GameStatus.Stalemate;

            if (IsKingInCheck(color))
                return GameState.GameStatus.Check;

            return GameState.GameStatus.InProgress;
        }

        #endregion

        #region Special Move Detection Methods

        /// <summary>
        /// Detects if a move is a castling move.
        /// </summary>
        private bool IsCastlingMove(int fromX, int fromY, int toX, int toY)
        {
            Board board = GameState.Board;
            Piece piece = board.GetPiece(fromX, fromY);

            // Must be a king moving 2 squares horizontally
            if (!(piece is King))
                return false;

            int deltaX = Math.Abs(toX - fromX);
            int deltaY = Math.Abs(toY - fromY);

            return deltaX == 2 && deltaY == 0;
        }

        /// <summary>
        /// Detects if a move is an en passant capture.
        /// </summary>
        private bool IsEnPassantMove(int fromX, int fromY, int toX, int toY)
        {
            Board board = GameState.Board;
            Piece piece = board.GetPiece(fromX, fromY);

            if (!(piece is Pawn))
                return false;

            // En passant: diagonal move to empty square
            bool isDiagonal = Math.Abs(toX - fromX) == 1 && Math.Abs(toY - fromY) == 1;
            bool toSquareEmpty = board.IsEmpty(toX, toY);

            return isDiagonal && toSquareEmpty;
        }

        /// <summary>
        /// Checks if a pawn move would result in promotion.
        /// </summary>
        public bool IsPromotionMove(int fromX, int fromY, int toX, int toY)
        {
            Board board = GameState.Board;
            Piece piece = board.GetPiece(fromX, fromY);

            if (!(piece is Pawn))
                return false;

            // White pawns promote on rank 7, black pawns on rank 0
            int promotionRank = piece.Color == 'w' ? 7 : 0;
            return toY == promotionRank;
        }

        #endregion

        #region Special Move Execution Methods

        /// <summary>
        /// Executes an en passant capture by removing the captured pawn.
        /// </summary>
        private Piece ExecuteEnPassant(int fromX, int fromY, int toX, int toY)
        {
            Board board = GameState.Board;
            Piece pawn = board.GetPiece(fromX, fromY);

            // Move the pawn diagonally
            board.MovePiece(fromX, fromY, toX, toY);

            // Remove the captured pawn (which is on the same rank as the moving pawn)
            int capturedPawnY = fromY;
            Piece capturedPawn = board.GetPiece(toX, capturedPawnY);
            board.BoardMatrix[toX, capturedPawnY] = null;

            return capturedPawn;
        }

        /// <summary>
        /// Promotes a pawn to the specified piece type.
        /// </summary>
        public void PromotePawn(int x, int y, char color, char pieceType = 'Q')
        {
            Board board = GameState.Board;
            
            Piece promotedPiece;
            switch (pieceType)
            {
                case 'Q':
                    promotedPiece = new Queen(color);
                    break;
                case 'R':
                    promotedPiece = new Rook(color);
                    break;
                case 'B':
                    promotedPiece = new Bishop(color);
                    break;
                case 'N':
                    promotedPiece = new Knight(color);
                    break;
                default:
                    promotedPiece = new Queen(color);
                    break;
            }
            
            promotedPiece.HasMoved = true;
            board.BoardMatrix[x, y] = promotedPiece;
        }

        /// <summary>
        /// Executes a castling move by moving both the king and the rook.
        /// </summary>
        private void ExecuteCastling(int fromX, int fromY, int toX, int toY)
        {
            Board board = GameState.Board;
            int backRank = toY;

            // King moves 2 squares
            board.MovePiece(fromX, fromY, toX, toY);

            // Determine which side and move the rook
            if (toX == 6) // King-side castling
            {
                // Move rook from h-file (7) to f-file (5)
                board.MovePiece(7, backRank, 5, backRank);
                board.GetPiece(5, backRank).HasMoved = true;
            }
            else if (toX == 2) // Queen-side castling
            {
                // Move rook from a-file (0) to d-file (3)
                board.MovePiece(0, backRank, 3, backRank);
                board.GetPiece(3, backRank).HasMoved = true;
            }
        }

        /// <summary>
        /// Checks if castling would move through or into check.
        /// For castling to be legal, the king cannot be in check, move through check, or end in check.
        /// </summary>
        private bool WouldCastlingMoveThroughCheck(int fromX, int fromY, int toX, int toY)
        {
            Board board = GameState.Board;
            Piece king = board.GetPiece(fromX, fromY);
            char opponentColor = king.Color == 'w' ? 'b' : 'w';
            int backRank = fromY;

            // Check if king is currently in check
            if (IsKingInCheck(king.Color))
                return true;

            // Determine direction of castling
            int direction = toX > fromX ? 1 : -1;

            // Check each square the king moves through (not including start, including end)
            for (int x = fromX + direction; ; x += direction)
            {
                if (IsSquareUnderAttack(x, backRank, opponentColor))
                    return true;

                if (x == toX)
                    break;
            }

            return false;
        }

        #endregion

        #region Disambiguation for Algebraic Notation

        /// <summary>
        /// Calculates disambiguation string for algebraic notation when multiple pieces of same type can move to same square.
        /// </summary>
        public string GetDisambiguation(int fromX, int fromY, int toX, int toY)
        {
            Board board = GameState.Board;
            Piece piece = board.GetPiece(fromX, fromY);

            // Pawns and Kings don't need disambiguation
            if (piece == null || piece is Pawn || piece is King)
                return "";
            
            // Find all pieces of same type and color
            List<(int x, int y)> samePieces = new List<(int, int)>();
            for (int x = 0; x < board.Size; x++)
                for (int y = 0; y < board.Size; y++)
                {
                    if (x == fromX && y == fromY) continue;
                    
                    Piece otherPiece = board.GetPiece(x, y);
                    if (otherPiece != null && 
                        otherPiece.GetType() == piece.GetType() && 
                        otherPiece.Color == piece.Color)
                    {
                        // Check if this piece can also move to the destination
                        List<(int x, int y)> moves = GetTrulyLegalMoves(x, y);

                        // See if destination is in moves
                        bool canMoveToDestination = false;
                        for (int i = 0; i < moves.Count; i++)
                        {
                            if (moves[i].x == toX && moves[i].y == toY)
                            {
                                canMoveToDestination = true;
                                break;
                            }
                        }
                        
                        if (canMoveToDestination)
                            samePieces.Add((x, y));
                    }
                }

            // No ambiguity
            if (samePieces.Count == 0)
                return "";
            
            // Check if file (column) alone disambiguates
            bool fileUnique = true;
            foreach (var pos in samePieces)
            {
                if (pos.x == fromX)
                {
                    fileUnique = false;
                    break;
                }
            }
            
            if (fileUnique)
                return ((char)('a' + fromX)).ToString();
            
            // Check if rank (row) alone disambiguates
            bool rankUnique = true;
            foreach (var pos in samePieces)
            {
                if (pos.y == fromY)
                {
                    rankUnique = false;
                    break;
                }
            }
            
            if (rankUnique)
                return (fromY + 1).ToString();
            
            // Need both file and rank
            return ((char)('a' + fromX)).ToString() + (fromY + 1).ToString();
        }

        #endregion
    }
}