#nullable enable
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace tic_tac_toe.Models;

public class Player : INotifyPropertyChanged
{
    public string Name { get; private set; }
    public PlayerSymbol Symbol { get; private set; }
    public PlayerType Type { get; private set; }

    private int _score;

    public int Score
    {
        get => _score;
        set
        {
            if (_score == value)
                return;
            _score = value;
            OnPropertyChanged();
        }
    }

    public Player(string name, PlayerSymbol symbol, PlayerType type)
    {
        Name = name;
        Symbol = symbol;
        Type = type;
        Score = 0;
    }

    public event PropertyChangedEventHandler ? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}