using System.Collections.Generic;

namespace MidChess.board
{
    public class Queen : Piece
    {
        public Queen(char color) : base(color) { }

        public override List<(int x, int y)> GetLegalMoves(Board board, int x, int y)
        {
            List<(int x, int y)> legalMoves = new List<(int x, int y)>();

            // Queen moves like rook + bishop: horizontal, vertical, and diagonal
            int[] dx = { 0, 0, -1, 1, 1, 1, -1, -1 };
            int[] dy = { 1, -1, 0, 0, 1, -1, 1, -1 };

            for (int dir = 0; dir < 8; dir++)
            {
                int currentX = x + dx[dir];
                int currentY = y + dy[dir];

                // Keep moving in this direction until we hit a piece or board edge
                while (board.IsOnBoard(currentX, currentY))
                {
                    if (board.IsEmpty(currentX, currentY))
                        legalMoves.Add((currentX, currentY));
                    else
                    {
                        // Hit a piece
                        Piece targetPiece = board.GetPiece(currentX, currentY);
                        if (targetPiece.Color != Color)
                            // Can capture enemy piece
                            legalMoves.Add((currentX, currentY));
                        // Can't move past any piece
                        break;
                    }

                    currentX += dx[dir];
                    currentY += dy[dir];
                }
            }

            return legalMoves;
        }
    }
}