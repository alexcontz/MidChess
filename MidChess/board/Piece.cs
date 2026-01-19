using System.Collections.Generic;

namespace MidChess.board
{
    public abstract class Piece
    {
        public char Color { get; private set; }
        public bool HasMoved { get; set; }  

        public Piece(char color)
        {
            this.Color = color;
            this.HasMoved = false;
        }

        public abstract List<(int x, int y)> GetLegalMoves(Board board, int x, int y);
    }
}