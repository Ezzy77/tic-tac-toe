
using System.ComponentModel;
using System.Runtime.CompilerServices;
using tic_tac_toe.Models;
namespace tic_tac_toe.Views;

public partial class AiGameMode : ContentPage , INotifyPropertyChanged
{
   
    private readonly GameLogic _gameLogic;
    public AiGameMode()
    {
        InitializeComponent();

        var player1 = new Player("Player 1", PlayerSymbol.X, PlayerType.Human);
        var player2 = new Player("AI", PlayerSymbol.O, PlayerType.Computer);

        _gameLogic = new GameLogic(player1, player2);
        BindingContext = _gameLogic;
    }
    
    void OnButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        // Get the row and column of the clicked cell
        var row = Grid.GetRow(button);
        var col = Grid.GetColumn(button);


        if (!_gameLogic.MakeMove(row, col))
        {
            WinnerLabel.Text = "Invalid Move";
            return;
        }
        button.Text = _gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "O" : "X";

        WinnerLabel.Text = "Valid Move";
        

        var win = _gameLogic.CheckForWin(_gameLogic.CurrentPlayer.Symbol);
        Console.WriteLine(win);
        if (win)
        {
            WinnerLabel.Text = $"Player {_gameLogic.CurrentPlayer.Symbol} has Won!!!";
            DisableGameButtons();
            return;
        }
        
        if (_gameLogic.CheckForDraw())
        {
            WinnerLabel.Text = "Its a draw";
        }
        _gameLogic.SwitchPlayer();
        
    }

    private void DisableGameButtons()
    {
        // Disable all game buttons/cells after win detected
        Cell00.IsEnabled = false;
        Cell01.IsEnabled = false;
        Cell02.IsEnabled = false;
        Cell10.IsEnabled = false;
        Cell11.IsEnabled = false;
        Cell12.IsEnabled = false;
        Cell20.IsEnabled = false;
        Cell21.IsEnabled = false;
        Cell22.IsEnabled = false;
    }
    
    private async void EndGameButton_Clicked(object sender, EventArgs e)
    {
        // Perform any necessary actions to end the game
        
        await Navigation.PopAsync(); // Navigate back to the previous page
    }

    private void OnGameReset_Clicked(object sender, EventArgs e)
    {
        _gameLogic.ResetGame();
        Cell00.IsEnabled = true;
        Cell01.IsEnabled = true;
        Cell02.IsEnabled = true;
        Cell10.IsEnabled = true;
        Cell11.IsEnabled = true;
        Cell12.IsEnabled = true;
        Cell20.IsEnabled = true;
        Cell21.IsEnabled = true;
        Cell22.IsEnabled = true;
        
        List<Button> gameButtons = new List<Button> 
        { 
            Cell00, Cell01, Cell02, 
            Cell10, Cell11, Cell12, 
            Cell20, Cell21, Cell22 
        };

        foreach(Button button in gameButtons)
        {
            button.IsEnabled = true;
            button.Text = string.Empty;
        }
        
        WinnerLabel.Text = "Game Reset";

    }
}