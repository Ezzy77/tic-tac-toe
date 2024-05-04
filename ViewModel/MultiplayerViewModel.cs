using System.ComponentModel;
using System.Runtime.CompilerServices;
using tic_tac_toe.Models;

namespace tic_tac_toe.ViewModel;

public class MultiplayerViewModel : INotifyPropertyChanged
{
    public readonly GameLogic GameLogic;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Player1Name { get; set; }
    public string Player2Name { get; set; }
    
    private int _player1Score;
    public int Player1Score 
    { 
        get => _player1Score; 
        set
        {
            if (_player1Score != value)
            {
                _player1Score = value;
                OnPropertyChanged();
            }
        }
    }
        
    private int _player2Score;
    public int Player2Score 
    { 
        get => _player2Score; 
        set
        {
            if (_player2Score != value)
            {
                _player2Score = value;
                OnPropertyChanged();
            }
        }
    }

    public MultiplayerViewModel()
    {
        Player1Name = "John";
        Player2Name = "Doe";
        
        var player1 = new Player(Player1Name, PlayerSymbol.X);
        var player2 = new Player(Player2Name, PlayerSymbol.O);

        GameLogic = new GameLogic(player1, player2);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public void UpdatePlayerScores()
    {
        // Update player scores here
        Player1Score = GameLogic.Player1.Score;
        Player2Score = GameLogic.Player2.Score;
    }
}