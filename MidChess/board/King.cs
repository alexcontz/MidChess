using System.Collections.Generic;

namespace MidChess.board
{
    public class King : Piece
    {
        public King(char color) : base(color) { }

        public override List<(int x, int y)> GetLegalMoves(Board board, int x, int y)
        {
            List<(int x, int y)> legalMoves = new List<(int x, int y)>();

            // King moves one square in any direction
            int[] dx = { 0, 0, -1, 1, 1, 1, -1, -1 };
            int[] dy = { 1, -1, 0, 0, 1, -1, 1, -1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                if (board.IsOnBoard(newX, newY))
                {
                    if (board.IsEmpty(newX, newY))
                        legalMoves.Add((newX, newY));
                    else
                    {
                        Piece targetPiece = board.GetPiece(newX, newY);
                        if (targetPiece.Color != Color)
                            legalMoves.Add((newX, newY));
                    }
                }
            }

            // Add castling moves
            AddCastlingMoves(board, x, y, legalMoves);

            return legalMoves;
        }

        private void AddCastlingMoves(Board board, int kingX, int kingY, List<(int x, int y)> legalMoves)
        {
            // Castling is only possible if king hasn't moved
            if (HasMoved)
                return;

            int backRank = Color == 'w' ? 0 : 7;

            // King must be on its starting position
            if (kingY != backRank || kingX != 4)
                return;

            // King-side castling (short castling)
            TryAddKingSideCastling(board, kingX, kingY, backRank, legalMoves);

            // Queen-side castling (long castling)
            TryAddQueenSideCastling(board, kingX, kingY, backRank, legalMoves);
        }

        private void TryAddKingSideCastling(Board board, int kingX, int kingY, int backRank, List<(int x, int y)> legalMoves)
        {
            // Check if rook is at starting position (h-file, column 7)
            if (!board.IsEmpty(7, backRank))
            {
                Piece rook = board.GetPiece(7, backRank);
                
                // Rook must be the same color, be a Rook, and not have moved
                if (rook is Rook && rook.Color == Color && !rook.HasMoved)
                    // Check if squares between king and rook are empty (f and g files, columns 5 and 6)
                    if (board.IsEmpty(5, backRank) && board.IsEmpty(6, backRank))
                        // Add castling move (king moves to g-file, column 6)
                        legalMoves.Add((6, backRank));
            }
        }

        private void TryAddQueenSideCastling(Board board, int kingX, int kingY, int backRank, List<(int x, int y)> legalMoves)
        {
            // Check if rook is at starting position (a-file, column 0)
            if (!board.IsEmpty(0, backRank))
            {
                Piece rook = board.GetPiece(0, backRank);
                
                // Rook must be the same color, be a Rook, and not have moved
                if (rook is Rook && rook.Color == Color && !rook.HasMoved)
                    // Check if squares between king and rook are empty (b, c, and d files, columns 1, 2, and 3)
                    if (board.IsEmpty(1, backRank) && board.IsEmpty(2, backRank) && board.IsEmpty(3, backRank))
                        // Add castling move (king moves to c-file, column 2)
                        legalMoves.Add((2, backRank));
            }
        }
    }
}