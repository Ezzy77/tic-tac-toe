using System;
namespace tic_tac_toe.Models
{
	public class GameLogic
	{
        // Reference to the game board
        private Player[] players;
        private Player currentPlayer;
        private GameBoard gameBoard;
		public GameLogic(Player player1, Player player2)
        {
            gameBoard = new GameBoard();
            players = new Player[] { player1, player2 };
            currentPlayer = player1;
        }

        private bool IsValidMove(int row, int col)
        {
            if (row < 0 || row >= 3)
                return false;
            if (col < 0 || col >= 3)
                return false;
            return gameBoard.IsCellEmpty(row, col);
        }

        public bool MakeMove(int row, int col)
        {
            if (!IsValidMove(row, col)) return false;
            gameBoard.UpdateCell(row, col, currentPlayer.Symbol);

            if (CheckForWin(currentPlayer.Symbol))
            {
                // Current player won the game
                currentPlayer.HasWon = true;
                currentPlayer.Score++;
                // Update the game's state and possibly announce the winner.
                return true;
            }
            else if (CheckForDraw())
            {
                // The game is a draw.
                // Update the game's state accordingly.
            }
            else
            {
                // Switch to the other player.
                currentPlayer = (currentPlayer == players[0]) ? players[1] : players[0];
            }

            return true;
        }

        private bool CheckForWin(PlayerSymbol playerSymbol)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if(gameBoard.board[i, 0] == (int)playerSymbol &&
                   gameBoard.board[i, 1] == (int)playerSymbol &&
                   gameBoard.board[i, 2] ==(int) playerSymbol)
                    return true;
            }
            
            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if(gameBoard.board[0, i] == (int)playerSymbol &&
                   gameBoard.board[1, i] == (int)playerSymbol &&
                   gameBoard.board[2, i] == (int)playerSymbol)
                    return true;
            }
            
            // Check diagonals
            if(gameBoard.board[0, 0] ==(int) playerSymbol &&
               gameBoard.board[1, 1] ==(int) playerSymbol &&
               gameBoard.board[2, 2] == (int)playerSymbol)
                return true;
            
            if(gameBoard.board[0, 2] ==(int) playerSymbol &&
               gameBoard.board[1, 1] == (int)playerSymbol &&
               gameBoard.board[2, 0] ==(int) playerSymbol)
                return true;
            
            return false;
        }

        private bool CheckForDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard.IsCellEmpty(i, j)) // a cell is still free, so no draw
                        return false;
                }
            }
            return true; // No cell is free, it's a draw
        }

    }
}

