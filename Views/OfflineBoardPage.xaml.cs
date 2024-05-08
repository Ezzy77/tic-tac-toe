
using tic_tac_toe.Models;
using tic_tac_toe.ViewModel;

namespace tic_tac_toe.Views;

public partial class OfflineBoardPage : ContentPage
{
    private readonly MultiplayerViewModel _multiplayerViewModel;

    public OfflineBoardPage()
    {
        InitializeComponent();
        _multiplayerViewModel = new MultiplayerViewModel();
        BindingContext = _multiplayerViewModel;
    }
    
    void OnButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        // Get the row and column of the clicked cell
        var row = Grid.GetRow(button);
        var col = Grid.GetColumn(button);

        var symbol = _multiplayerViewModel.GameLogic.CurrentPlayer.Symbol;

        if (!_multiplayerViewModel.GameLogic.MakeMove(row, col))
        {
            WinnerLabel.IsEnabled = true;
             WinnerLabel.Text = "Invalid Move";
            return;
        }
        button.Text = _multiplayerViewModel.GameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
        
        if (_multiplayerViewModel.GameLogic.CheckForWin(_multiplayerViewModel.GameLogic.CurrentPlayer.Symbol))
        {
            WinnerLabel.IsEnabled = true;

            WinnerLabel.Text = $"Player {symbol} has Won!!!";
            DisableGameButtons();
            _multiplayerViewModel.GameLogic.CurrentPlayer.Score+= 1;
            
            // to update UI 
            Device.BeginInvokeOnMainThread(() =>
            {
                _multiplayerViewModel.UpdatePlayerScores();
            });

            Console.WriteLine("player 1 score is : " + _multiplayerViewModel.Player1Score);
            Console.WriteLine("player 2 score is : " + _multiplayerViewModel.Player2Score);

            return;
        }
        
        if (_multiplayerViewModel.GameLogic.CheckForDraw())
        {
            WinnerLabel.IsEnabled = true;

             WinnerLabel.Text = "Its a draw";
            ShowWinnerAlert(_multiplayerViewModel.GameLogic.CurrentPlayer.Name);

            DisableGameButtons();
        }
        _multiplayerViewModel.GameLogic.SwitchPlayer();
        
    }
    
    private async void ShowWinnerAlert(string winnerName)
    {
        await DisplayAlert("Winner!", $"{winnerName} has won the game!", "OK");
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
        _multiplayerViewModel.GameLogic.ResetGame();
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