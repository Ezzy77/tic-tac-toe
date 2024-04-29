using System;
namespace tic_tac_toe.Models
{
	public class GameBoard
	{
		// represents the game board
		public char[,] Board { get; private set; }
		// indicates if the game is over
		public bool IsGameOver { get; private set; }
		// stores the winner
		public char Winner { get; private set; }

		public GameBoard()
		{
			// init the game board
			Board = new char[3, 3];
			// reset the board
			ResetBoard();
		}

		public void ResetBoard()
		{
			// Reset the game board
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Board[i, j] = ' '; // Empty cell
				}
			}
			// reset game over status
			IsGameOver = false;

			Winner = ' ';
		}


		// more games methods 
	}
}