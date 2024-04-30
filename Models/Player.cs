namespace tic_tac_toe.Models;


public class Player
{
    public string Name { get; private set; }
    public PlayerSymbol Symbol { get; private set; }
    public PlayerType Type { get; private set; }
    public int Score { get; set; }
    public bool HasWon { get; set; }

    public Player(string name, PlayerSymbol symbol, PlayerType type)
    {
        Name = name;
        Symbol = symbol;
        Type = type;
        Score = 0;
        HasWon = false;
    }
    
    
    
}