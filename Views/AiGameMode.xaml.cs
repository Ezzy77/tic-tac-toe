
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
            WinnerLabel.Text = "Its a Win";
            return;
        }
        
        if (_gameLogic.CheckForDraw())
        {
            WinnerLabel.Text = "Its a draw";
        }
        _gameLogic.SwitchPlayer();
        
    }
    
    private async void EndGameButton_Clicked(object sender, EventArgs e)
    {
        // Perform any necessary actions to end the game
        
        await Navigation.PopAsync(); // Navigate back to the previous page
    }

    // public void OnGameReset_Clicked(object sender, EventArgs e)
    // {
    //     _gameLogic.ResetGame();
    // }
}