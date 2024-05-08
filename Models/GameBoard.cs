namespace tic_tac_toe.Models
{
	public class GameBoard
	{
		public char[,] Board { get; private set; }
		public bool IsGameOver { get; private set; }
		public int Winner { get; private set; }

		public GameBoard()
		{
			Board = new Char[3, 3];
			for (var i = 0; i < 3; i++)
			{
				for (var j = 0; j < 3; j++)
				{
					Board[i, j] = '*';
				}
			}
		}

		public void UpdateCell(int row, int col, PlayerSymbol symbol)
		{
			if (IsCellEmpty(row, col))
			{
				if (symbol == PlayerSymbol.X)
				{
					Board[row, col] = 'X';
				}
				else if (symbol == PlayerSymbol.O)
				{
					Board[row, col] = 'O';
				}
				else
				{
					Board[row, col] = 'E';
				}
				PrintBoard();

			}
		}
		
		public GameBoard Clone()
		{
			var clone = new GameBoard();
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					// Either PlayerSymbol.X, PlayerSymbol.O or \0 (if the cell is empty)
					char symbol = this.Board[i, j];
					clone.Board[i, j] = symbol;
				}
			}
			return clone;
		}

		private void PrintBoard()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Console.Write(Board[i, j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		public void ResetBoard()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Board[i, j] = '*'; // Empty cell
				}
			}
			IsGameOver = false;

			Winner = 0;
		}

		public bool IsCellEmpty(int row, int col)
		{
			return Board[row, col] == '*';
		}

	}
}