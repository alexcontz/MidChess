namespace MidChess.board
{
    public class Move
    {
        public int FromX { get; private set; }
        public int FromY { get; private set; }
        public int ToX { get; private set; }
        public int ToY { get; private set; }
        public Piece MovedPiece { get; private set; }
        public Piece CapturedPiece { get; private set; }
        public string Disambiguation { get; set; } // For algebraic notation (ex: Ra1-a5 when two rooks can move to a5)

        public Move(int fromX, int fromY, int toX, int toY, Piece movedPiece, Piece capturedPiece = null)
        {
            FromX = fromX;
            FromY = fromY;
            ToX = toX;
            ToY = toY;
            MovedPiece = movedPiece;
            CapturedPiece = capturedPiece;
            Disambiguation = "";
        }

        /// <summary>
        /// Returns a simple string representation of the move.
        /// </summary>
        public override string ToString()
        {
            string capture = CapturedPiece != null ? "x" : "-";
            return $"{GetPieceName(MovedPiece)}({FromX},{FromY}){capture}({ToX},{ToY})";
        }

        private string GetPieceName(Piece piece)
        {
            if (piece == null) return "?";
            
            string colorPrefix = piece.Color == 'w' ? "W" : "B";
            string pieceName = piece.GetType().Name;
            
            return colorPrefix + pieceName[0];
        }
    }
}