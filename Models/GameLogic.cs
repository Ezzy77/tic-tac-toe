using System;
namespace tic_tac_toe.Models
{
    public class GameLogic
    {
        private GameBoard gameBoard;
        private Player[] players;
        public Player CurrentPlayer { get; private set; }
        
        public GameLogic(Player player1, Player player2)
        {
            gameBoard = new GameBoard();
            players = new Player[] { player1, player2 };
            CurrentPlayer = players[0];
        }
        
        public bool MakeMove(int row, int col)
        {
            if (!IsValidMove(row, col)) return false;
            
            gameBoard.UpdateCell(row, col, CurrentPlayer.Symbol);
            
            SwitchPlayer();

            if (CheckForWin(CurrentPlayer.Symbol))
            {
                CurrentPlayer.Score++;
                return true;
            }

            if (CheckForDraw()) return true;
            

            return true;
        }

        private bool IsValidMove(int row, int col)
        {
            return !(row < 0 || row >= 3 || col < 0 || col >= 3) && gameBoard.IsCellEmpty(row, col);
        }
        
        private void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == players[0]) ? players[1] : players[0];
        }

        public void ResetGame()
        {
            gameBoard.ResetBoard();
            CurrentPlayer = players[0];
        }

        private bool CheckForWin(PlayerSymbol playerSymbol)
        {
            return HasPlayerWonInRows(playerSymbol) || HasPlayerWonInColumns(playerSymbol) || HasPlayerWonInDiagonal(playerSymbol);
        }

        private bool HasPlayerWonInRows(PlayerSymbol playerSymbol)
        {
            char symbol = (char)playerSymbol;
            for (int row = 0; row < 3; row++)
            {
                if (gameBoard.board[row, 0] == symbol &&
                    gameBoard.board[row, 1] == symbol &&
                    gameBoard.board[row, 2] == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasPlayerWonInColumns(PlayerSymbol playerSymbol)
        {
            char symbol = (char)playerSymbol;
            for (int col = 0; col < 3; col++)
            {
                if (gameBoard.board[0, col] == symbol &&
                    gameBoard.board[1, col] == symbol &&
                    gameBoard.board[2, col] == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasPlayerWonInDiagonal(PlayerSymbol playerSymbol)
        {
            char symbol = (char)playerSymbol;
            bool hasWonInLeftRightDiagonal = gameBoard.board[0, 0] == symbol &&
                                             gameBoard.board[1, 1] == symbol &&
                                             gameBoard.board[2, 2] == symbol;

            bool hasWonInRightLeftDiagonal = gameBoard.board[0, 2] == symbol &&
                                             gameBoard.board[1, 1] == symbol &&
                                             gameBoard.board[2, 0] == symbol;

            return hasWonInLeftRightDiagonal || hasWonInRightLeftDiagonal;
        }
        
        public bool CheckForDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard.IsCellEmpty(i, j)) return false;
                }
            }
            return true;
        }
    }
}


// using System;
// namespace tic_tac_toe.Models
// {
// 	public class GameLogic
// 	{
//         // Reference to the game board
//         private Player[] players;
//         public Player CurrentPlayer;
//         private GameBoard gameBoard;
// 		public GameLogic(Player player1, Player player2)
//         {
//             gameBoard = new GameBoard();
//             players = new Player[] { player1, player2 };
//             CurrentPlayer = players[0];
//         }
//
//         private bool IsValidMove(int row, int col)
//         {
//             if (row < 0 || row >= 3)
//                 return false;
//             if (col < 0 || col >= 3)
//                 return false;
//             return gameBoard.IsCellEmpty(row, col);
//         }
//
//         public bool MakeMove(int row, int col)
//         {
//             if (!IsValidMove(row, col)) return false;
//             gameBoard.UpdateCell(row, col, CurrentPlayer.Symbol);
//
//             if (CheckForWin(CurrentPlayer.Symbol))
//             {
//                 // Current player won the game
//                 CurrentPlayer.Score++;
//                 // Update the game's state and possibly announce the winner.
//                 return true;
//             }
//             else if (CheckForDraw())
//             {
//                 // The game is a draw.
//                 // Update the game's state accordingly.
//             }
//             else
//             {
//                 // Switch to the other player.
//                 CurrentPlayer = (CurrentPlayer == players[0]) ? players[1] : players[0];
//             }
//
//             return true;
//         }
//
//         public bool CheckForWin(PlayerSymbol playerSymbol)
//         {
//             // Check rows
//             for (int i = 0; i < 3; i++)
//             {
//                 if(gameBoard.board[i, 0] == (char)playerSymbol &&
//                    gameBoard.board[i, 1] == (char)playerSymbol &&
//                    gameBoard.board[i, 2] ==(char) playerSymbol)
//                     return true;
//             }
//             
//             // Check columns
//             for (int i = 0; i < 3; i++)
//             {
//                 if(gameBoard.board[0, i] == (char)playerSymbol &&
//                    gameBoard.board[1, i] == (char)playerSymbol &&
//                    gameBoard.board[2, i] == (char)playerSymbol)
//                     return true;
//             }
//             
//             // Check diagonals
//             if(gameBoard.board[0, 0] ==(char) playerSymbol &&
//                gameBoard.board[1, 1] ==(char) playerSymbol &&
//                gameBoard.board[2, 2] == (char)playerSymbol)
//                 return true;
//             
//             if(gameBoard.board[0, 2] ==(char) playerSymbol &&
//                gameBoard.board[1, 1] == (char)playerSymbol &&
//                gameBoard.board[2, 0] ==(char) playerSymbol)
//                 return true;
//             
//             return false;
//         }
//
//         public bool CheckForDraw()
//         {
//             for (int i = 0; i < 3; i++)
//             {
//                 for (int j = 0; j < 3; j++)
//                 {
//                     if (gameBoard.IsCellEmpty(i, j)) // a cell is still free, so no draw
//                         return false;
//                 }
//             }
//             return true; // No cell is free, it's a draw
//         }
//
//         public void SwitchPlayer()
//         {
//             CurrentPlayer = (CurrentPlayer.Type == PlayerType.Human) ? players[1]  : players[0];
//         }
//         
//         public void ResetGame()
//         {
//             gameBoard.ResetBoard();
//         }
//
//     }
// }
//
