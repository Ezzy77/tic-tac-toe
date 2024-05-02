
using tic_tac_toe.Models;
using tic_tac_toe.ViewModel;

namespace tic_tac_toe.Views;

public partial class AiGameMode
{
   
    private AiGameModeViewModel _viewModel;

    public AiGameMode()
    {
        InitializeComponent();
        _viewModel = new AiGameModeViewModel();
        BindingContext = _viewModel;

    }
    
    void OnButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        // Get the row and column of the clicked cell
        var row = Grid.GetRow(button);
        var col = Grid.GetColumn(button);

        var symbol = _viewModel._gameLogic.CurrentPlayer.Symbol;

        if (!_viewModel._gameLogic.MakeMove(row, col))
        {
            WinnerLabel.IsEnabled = true;
             WinnerLabel.Text = "Invalid Move";
            return;
        }
        button.Text = _viewModel._gameLogic.CurrentPlayer.Symbol == PlayerSymbol.X ? "X" : "O";
        
        if (_viewModel._gameLogic.CheckForWin(_viewModel._gameLogic.CurrentPlayer.Symbol))
        {
            WinnerLabel.IsEnabled = true;

            WinnerLabel.Text = $"Player {symbol} has Won!!!";
            DisableGameButtons();
            _viewModel._gameLogic.CurrentPlayer.Score+= 1;
            
            // to update UI 
            Device.BeginInvokeOnMainThread(() =>
            {
                _viewModel.UpdatePlayerScores();
            });

            Console.WriteLine("player 1 score is : " + _viewModel.Player1Score);
            Console.WriteLine("player 2 score is : " + _viewModel.Player2Score);

            return;
        }
        
        if (_viewModel._gameLogic.CheckForDraw())
        {
            WinnerLabel.IsEnabled = true;

             WinnerLabel.Text = "Its a draw";
            ShowWinnerAlert(_viewModel._gameLogic.CurrentPlayer.Name);

            DisableGameButtons();
        }
        _viewModel._gameLogic.SwitchPlayer();
        
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
        _viewModel._gameLogic.ResetGame();
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