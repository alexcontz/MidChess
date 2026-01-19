using System;

namespace MidChess.board
{
    public class Board
    {
        public Piece[,] BoardMatrix { get; private set; }
        public int Size { get; private set; }

        public Board()
        {
            Size = 8;
            BoardMatrix = new Piece[Size, Size];
        }

        public Board(int size)
        {
            Size = size;
            BoardMatrix = new Piece[Size, Size];
        }

        public bool IsOnBoard(int x, int y)
        {
            return x >= 0 && x < Size && y >= 0 && y < Size;
        }

        public bool IsEmpty(int x, int y)
        {
            return BoardMatrix[x, y] == null;
        }

        public Piece GetPiece(int x, int y)
        {
            return BoardMatrix[x, y];
        }

        public void PlacePiece(Piece piece, int x, int y)
        {
            BoardMatrix[x, y] = piece;
        }

        public void MovePiece(int fromX, int fromY, int toX, int toY)
        {
            if (!IsOnBoard(fromX, fromY) || !IsOnBoard(toX, toY))
                throw new ArgumentException("Move coordinates out of bounds");
            if (IsEmpty(fromX, fromY))
                throw new InvalidOperationException("No piece at source position");
            
            Piece piece = BoardMatrix[fromX, fromY];
            BoardMatrix[fromX, fromY] = null;
            BoardMatrix[toX, toY] = piece;
        }
    }
}