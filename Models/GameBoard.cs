using System;
namespace tic_tac_toe.Models
{
	public class GameBoard
	{
		public int[,] board { get; private set; }
		public bool IsGameOver { get; private set; }
		public int Winner { get; private set; }

		public GameBoard()
		{
			board = new int[3, 3];
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					// 0 represents empty cells
					board[i, j] = 0;
				}
			}
		}

		public void UpdateCell(int row, int col, PlayerSymbol symbol)
		{
			if (IsCellEmpty(row, col))
			{
				if (symbol == PlayerSymbol.X)
				{
					board[row, col] = 1;
				}
				else
				{
					board[row, col] = 2;
				}

			}
		}

		public void ResetBoard()
		{
			// Reset the game board
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					board[i, j] = 0; // Empty cell
				}
			}
			// reset game over status
			IsGameOver = false;

			Winner = 0;
		}

		public void ExitGame()
		{
			ResetBoard();
		}

		public bool IsCellEmpty(int row, int col)
		{
			return board[row, col] == 0;
		}

	}
}