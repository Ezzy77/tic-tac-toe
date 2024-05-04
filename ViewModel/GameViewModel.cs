using System.ComponentModel;
using tic_tac_toe.Models;

namespace tic_tac_toe.ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private readonly GameLogic _gameLogic;

        public event PropertyChangedEventHandler PropertyChanged;

        public Player Player1 => _gameLogic.Player1;
        public Player Player2 => _gameLogic.Player2;

        public GameViewModel()
        {
            var player1 = new Player("Player 1", PlayerSymbol.X, PlayerType.Human);
            var player2 = new Player("AI", PlayerSymbol.O, PlayerType.Computer);

            _gameLogic = new GameLogic(player1, player2);
        }

        // You can expose other necessary properties or methods from GameLogic here
    }
}
