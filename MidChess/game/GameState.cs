using System.Collections.Generic;
using MidChess.board;

namespace MidChess.game
{
    public class GameState
    {
        public enum GameStatus
        {
            InProgress,
            Check,
            Checkmate,
            Stalemate,
            Draw
        }

        public Board Board { get; private set; }
        public char CurrentTurn { get; private set; }
        public List<Move> MoveHistory { get; private set; }
        public int MoveCount { get; internal set; }
        public GameStatus Status { get; internal set; }

        public GameState()
        {
            Board = new Board();
            CurrentTurn = 'w';
            MoveHistory = new List<Move>();
            MoveCount = 0;
            Status = GameStatus.InProgress;
        }

        /// <summary>
        /// Switches the turn to the opposite player.
        /// </summary>
        internal void SwitchTurn()
        {
            CurrentTurn = (CurrentTurn == 'w') ? 'b' : 'w';
        }

        /// <summary>
        /// Checks if it's the specified color's turn.
        /// </summary>
        /// <param name="color">The color to check ('w' or 'b').</param>
        /// <returns>True if it's this color's turn, false otherwise.</returns>
        internal bool IsValidTurn(char color)
        {
            return CurrentTurn == color;
        }

        /// <summary>
        /// Adds a move to the move history and increments move count.
        /// </summary>
        /// <param name="move">The move to record.</param>
        internal void RecordMove(Move move)
        {
            MoveHistory.Add(move);
            MoveCount++;
        }

        /// <summary>
        /// Gets the last move made, or null if no moves have been made.
        /// </summary>
        /// <returns>The last move, or null.</returns>
        public Move GetLastMove()
        {
            return MoveHistory.Count > 0 ? MoveHistory[MoveHistory.Count - 1] : null;
        }

        /// <summary>
        /// Checks if the game is over (checkmate, stalemate, or draw).
        /// </summary>
        public bool IsGameOver()
        {
            return Status == GameStatus.Checkmate || 
                   Status == GameStatus.Stalemate || 
                   Status == GameStatus.Draw;
        }

        /// <summary>
        /// Gets a string representation of the current game state.
        /// </summary>
        public override string ToString()
        {
            string turn = CurrentTurn == 'w' ? "White" : "Black";
            return $"Turn: {turn}, Moves: {MoveCount}, Status: {Status}";
        }
    }
}