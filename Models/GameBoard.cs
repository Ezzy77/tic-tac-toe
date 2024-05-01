using System;
namespace tic_tac_toe.Models
{
	public class GameBoard
	{
		public char[,] board { get; private set; }
		public bool IsGameOver { get; private set; }
		public int Winner { get; private set; }

		public GameBoard()
		{
			board = new Char[3, 3];
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					board[i, j] = '*';
				}
			}
		}

		public void UpdateCell(int row, int col, PlayerSymbol symbol)
		{
			if (IsCellEmpty(row, col))
			{
				if (symbol == PlayerSymbol.X)
				{
					board[row, col] = 'X';
				}
				else
				{
					board[row, col] = 'O';
				}

			}
		}

		public void ResetBoard()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					board[i, j] = '*'; // Empty cell
				}
			}
			IsGameOver = false;

			Winner = 0;
		}

		public bool IsCellEmpty(int row, int col)
		{
			return board[row, col] == '*';
		}

	}
}