using System.Collections.Generic;

namespace MidChess.board
{
    public class Knight : Piece
    {
        public Knight(char color) : base(color) { }

        public override List<(int x, int y)> GetLegalMoves(Board board, int x, int y)
        {
            List<(int x, int y)> legalMoves = new List<(int x, int y)>();

            // Knight moves in L-shape
            int[] dx = { 2, 2, -2, -2, 1, 1, -1, -1 };
            int[] dy = { 1, -1, 1, -1, 2, -2, 2, -2 };

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

            return legalMoves;
        }
    }
}