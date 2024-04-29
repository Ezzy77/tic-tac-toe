using System;
namespace tic_tac_toe.Models
{
	public class GameLogic
	{
        // Reference to the game board
        private GameBoard _board;

		public GameLogic(GameBoard board)
		{
			_board = board;
		}


        public bool MakeMove(int row, int col, char player)
        {
            if (_board.Board[row, col] == ' ' && !_board.IsGameOver)
            {
                _board.Board[row, col] = player; // Set player's move on the board
                CheckForWin(player); // Check if the move resulted in a win
                CheckForDraw(); // Check if the game ended in a draw
                return true; // Move successful
            }
            return false; // Move unsuccessful
        }

        private void CheckForWin(char player)
        {
            // Check rows, columns, and diagonals for a win
            // Update _board.IsGameOver and _board.Winner accordingly
        }

        private void CheckForDraw()
        {
            // Check if the game ended in a draw
            // Update _board.IsGameOver accordingly
        }

    }
}

