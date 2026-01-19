using System;
using System.Collections.Generic;

namespace MidChess.board
{
    public class Pawn : Piece
    {
        public Pawn(char color) : base(color) { }

        public override List<(int x, int y)> GetLegalMoves(Board board, int x, int y)
        {
            return GetLegalMoves(board, x, y, null);
        }

        public List<(int x, int y)> GetLegalMoves(Board board, int x, int y, Move lastMove)
        {
            List<(int x, int y)> legalMoves = new List<(int x, int y)>();

            // Direction depends on color: white moves up (increasing y), black moves down (decreasing y)
            int direction = (Color == 'w') ? 1 : -1;
            int startRow = (Color == 'w') ? 1 : 6;

            // Forward move (one square)
            int forwardY = y + direction;
            if (board.IsOnBoard(x, forwardY) && board.IsEmpty(x, forwardY))
            {
                legalMoves.Add((x, forwardY));

                // Double move from starting position
                if (y == startRow)
                {
                    int doubleForwardY = y + (2 * direction);
                    if (board.IsOnBoard(x, doubleForwardY) && board.IsEmpty(x, forwardY) && board.IsEmpty(x, doubleForwardY))
                        legalMoves.Add((x, doubleForwardY));
                }
            }

            // Diagonal captures
            int[] captureOffsets = { -1, 1 };
            foreach (int offset in captureOffsets)
            {
                int captureX = x + offset;
                int captureY = y + direction;

                if (board.IsOnBoard(captureX, captureY) && !board.IsEmpty(captureX, captureY))
                {
                    Piece targetPiece = board.GetPiece(captureX, captureY);
                    if (targetPiece.Color != Color)
                        legalMoves.Add((captureX, captureY));
                }
            }

            // En passant
            if (lastMove != null)
                AddEnPassantMoves(board, x, y, lastMove, legalMoves, direction);

            return legalMoves;
        }

        private void AddEnPassantMoves(Board board, int x, int y, Move lastMove, List<(int x, int y)> legalMoves, int direction)
        {
            // En passant is only possible if the last move was a pawn double move
            if (!(lastMove.MovedPiece is Pawn))
                return;

            // Check if last move was a double move (moved 2 squares)
            int moveDistance = Math.Abs(lastMove.ToY - lastMove.FromY);
            if (moveDistance != 2)
                return;

            // The enemy pawn must be adjacent to our pawn
            if (lastMove.ToY != y)
                return;

            int enemyPawnX = lastMove.ToX;

            // Check if enemy pawn is directly adjacent (left or right)
            if (Math.Abs(enemyPawnX - x) != 1)
                return;

            // The enemy pawn must be opposite color
            Piece enemyPawn = board.GetPiece(enemyPawnX, lastMove.ToY);
            if (enemyPawn == null || enemyPawn.Color == Color)
                return;

            // Add en passant capture move (move diagonally to where enemy pawn was)
            int enPassantX = enemyPawnX;
            int enPassantY = y + direction;

            if (board.IsOnBoard(enPassantX, enPassantY) && board.IsEmpty(enPassantX, enPassantY))
                legalMoves.Add((enPassantX, enPassantY));
        }
    }
}