
using tic_tac_toe.Models;
namespace tic_tac_toe.Views;

public partial class AiGameMode : ContentPage
{
    private GameLogic _gameLogic;
    public AiGameMode()
    {
        InitializeComponent();

        Player player1 = new Player("Player 1", PlayerSymbol.X, PlayerType.Human);
        Player player2 = new Player("AI", PlayerSymbol.O, PlayerType.Computer);

        _gameLogic = new GameLogic(player1, player2);
    }
    
    void OnButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        // Get the row and column of the clicked cell
        int row = Grid.GetRow(button);
        int col = Grid.GetColumn(button);

        if(!_gameLogic.MakeMove(row, col))
            return;
        button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "O" : "X";
        
    }
    
   



    // void OnButtonClicked(object sender, EventArgs e)
    // {
    //     Button button = (Button)sender;
    //         
    //     if (button == Cell00)
    //     {
    //         var row = 0;
    //         var col = 0;
    //         if (!_gameLogic.MakeMove(row, col)) return;
    //         // if the move is valid, change cell text according to currentPlayer symbol
    //         button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
    //         
    //         // check if the game ends and update UI accordingly
    //         if (_gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol)) 
    //         {
    //             // display the winner
    //             WinnerLabel.Text = $"{_gameLogic.CurrentPlayer.Name} has won the game!";
    //                 
    //             // update the score in your view
    //         }
    //         else if (_gameLogic.CheckForDraw()) 
    //         {
    //             // display draw message
    //             // (again, you could ask if they want to start a new game)
    //         }
    //         else if (_gameLogic.CurrentPlayer.Type == PlayerType.Computer) 
    //         {
    //             // AI to make a move
    //             // You need to implement AI logic which could just be random valid move
    //             // Update the board UI according to AI move
    //         }
    //     }
    //     else if (button == Cell01)
    //     {
    //         var row = 0;
    //         var col = 1;
    //         if(_gameLogic.MakeMove(row, col))
    //         {
    //             // if the move is valid, change cell text according to currentPlayer symbol
    //             button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
    //         
    //             // check if the game ends and update UI accordingly
    //             if (_gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol) )
    //             {
    //                 // display the winner
    //                 
    //                 // update the score in your view
    //             }
    //             else if (_gameLogic.CheckForDraw()) 
    //             {
    //                 // display draw message
    //                 // (again, you could ask if they want to start a new game)
    //             }
    //             else if (_gameLogic.CurrentPlayer.Type == PlayerType.Computer) 
    //             {
    //                 // AI to make a move
    //                 // You need to implement AI logic which could just be random valid move
    //                 // Update the board UI according to AI move
    //             }
    //        
    //         }
    //
    //     }else if (button == Cell02)
    //     {
    //         var row = 0;
    //         var col = 2;
    //         if(_gameLogic.MakeMove(row, col))
    //         {
    //             // if the move is valid, change cell text according to currentPlayer symbol
    //             button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
    //         
    //             // check if the game ends and update UI accordingly
    //             if (_gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol)) 
    //             {
    //                 // display the winner
    //                 
    //                 // update the score in your view
    //             }
    //             else if (_gameLogic.CheckForDraw()) 
    //             {
    //                 // display draw message
    //                 // (again, you could ask if they want to start a new game)
    //             }
    //             else if (_gameLogic.CurrentPlayer.Type == PlayerType.Computer) 
    //             {
    //                 // AI to make a move
    //                 // You need to implement AI logic which could just be random valid move
    //                 // Update the board UI according to AI move
    //             }
    //        
    //         }
    //
    //     }else if (button == Cell10)
    //     {
    //         var row = 1;
    //         var col = 0;
    //         if(_gameLogic.MakeMove(row, col))
    //         {
    //             // if the move is valid, change cell text according to currentPlayer symbol
    //             button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
    //         
    //             // check if the game ends and update UI accordingly
    //             if (_gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol)) 
    //             {
    //                 // display the winner
    //                 
    //                 // update the score in your view
    //             }
    //             else if (_gameLogic.CheckForDraw()) 
    //             {
    //                 // display draw message
    //                 // (again, you could ask if they want to start a new game)
    //             }
    //             else if (_gameLogic.CurrentPlayer.Type == PlayerType.Computer) 
    //             {
    //                 // AI to make a move
    //                 // You need to implement AI logic which could just be random valid move
    //                 // Update the board UI according to AI move
    //             }
    //        
    //         }
    //
    //     }else if (button == Cell11)
    //     {
    //         var row = 1;
    //         var col = 1;
    //         if(_gameLogic.MakeMove(row, col))
    //         {
    //             // if the move is valid, change cell text according to currentPlayer symbol
    //             button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
    //         
    //             // check if the game ends and update UI accordingly
    //             if (_gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol)) 
    //             {
    //                 // display the winner
    //                 
    //                 // update the score in your view
    //             }
    //             else if (_gameLogic.CheckForDraw()) 
    //             {
    //                 // display draw message
    //                 // (again, you could ask if they want to start a new game)
    //             }
    //             else if (_gameLogic.CurrentPlayer.Type == PlayerType.Computer) 
    //             {
    //                 // AI to make a move
    //                 // You need to implement AI logic which could just be random valid move
    //                 // Update the board UI according to AI move
    //             }
    //        
    //         }
    //
    //     }else if (button == Cell12)
    //     {
    //         var row = 1;
    //         var col = 2;
    //         if(_gameLogic.MakeMove(row, col))
    //         {
    //             // if the move is valid, change cell text according to currentPlayer symbol
    //             button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
    //         
    //             // check if the game ends and update UI accordingly
    //             if (_gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol)) 
    //             {
    //                 // display the winner
    //                 
    //                 // update the score in your view
    //             }
    //             else if (_gameLogic.CheckForDraw()) 
    //             {
    //                 // display draw message
    //                 // (again, you could ask if they want to start a new game)
    //             }
    //             else if (_gameLogic.CurrentPlayer.Type == PlayerType.Computer) 
    //             {
    //                 // AI to make a move
    //                 // You need to implement AI logic which could just be random valid move
    //                 // Update the board UI according to AI move
    //             }
    //        
    //         }
    //
    //     }else if (button == Cell20)
    //     {
    //         var row = 2;
    //         var col = 0;
    //         if(_gameLogic.MakeMove(row, col))
    //         {
    //             // if the move is valid, change cell text according to currentPlayer symbol
    //             button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
    //         
    //             // check if the game ends and update UI accordingly
    //             if (_gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol)) 
    //             {
    //                 // display the winner
    //                 
    //                 // update the score in your view
    //             }
    //             else if (_gameLogic.CheckForDraw()) 
    //             {
    //                 // display draw message
    //                 // (again, you could ask if they want to start a new game)
    //             }
    //             else if (_gameLogic.CurrentPlayer.Type == PlayerType.Computer) 
    //             {
    //                 // AI to make a move
    //                 // You need to implement AI logic which could just be random valid move
    //                 // Update the board UI according to AI move
    //             }
    //        
    //         }
    //
    //     }else if (button == Cell21)
    //     {
    //         var row = 2;
    //         var col = 1;
    //         if(_gameLogic.MakeMove(row, col))
    //         {
    //             // if the move is valid, change cell text according to currentPlayer symbol
    //             button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
    //         
    //             // check if the game ends and update UI accordingly
    //             if (_gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol)) 
    //             {
    //                 // display the winner
    //                 
    //                 // update the score in your view
    //             }
    //             else if (_gameLogic.CheckForDraw()) 
    //             {
    //                 // display draw message
    //                 // (again, you could ask if they want to start a new game)
    //             }
    //             else if (_gameLogic.CurrentPlayer.Type == PlayerType.Computer) 
    //             {
    //                 // AI to make a move
    //                 // You need to implement AI logic which could just be random valid move
    //                 // Update the board UI according to AI move
    //             }
    //        
    //         }
    //
    //     }else if (button == Cell22)
    //     {
    //         var row = 2;
    //         var col = 2;
    //         if(_gameLogic.MakeMove(row, col))
    //         {
    //             // if the move is valid, change cell text according to currentPlayer symbol
    //             button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
    //         
    //             // check if the game ends and update UI accordingly
    //             if (_gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol)) 
    //             {
    //                 // display the winner
    //                 
    //                 // update the score in your view
    //             }
    //             else if (_gameLogic.CheckForDraw()) 
    //             {
    //                 // display draw message
    //                 // (again, you could ask if they want to start a new game)
    //             }
    //             else if (_gameLogic.CurrentPlayer.Type == PlayerType.Computer) 
    //             {
    //                 // AI to make a move
    //                 // You need to implement AI logic which could just be random valid move
    //                 // Update the board UI according to AI move
    //             }
    //        
    //         }
    //
    //     }
    //     
    //     
    //     // Handle other buttons similarly...
    //
    //     
    //     
    // }
    
    private async void EndGameButton_Clicked(object sender, EventArgs e)
    {
        // Perform any necessary actions to end the game
        
        await Navigation.PopAsync(); // Navigate back to the previous page
    }

    public void OnGameReset_Clicked(object sender, EventArgs e)
    {
        _gameLogic.ResetGame();
    }
}