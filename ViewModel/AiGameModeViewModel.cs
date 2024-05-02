using System.ComponentModel;
using System.Runtime.CompilerServices;
using tic_tac_toe.Models;

namespace tic_tac_toe.ViewModel
{
    public class AiGameModeViewModel : INotifyPropertyChanged
    {
        public readonly GameLogic _gameLogic;

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

        public AiGameModeViewModel()
        {
            var player1 = new Player("Player 1", PlayerSymbol.X, PlayerType.Human);
            var player2 = new Player("AI", PlayerSymbol.O, PlayerType.Computer);

            _gameLogic = new GameLogic(player1, player2);
        }

        public void UpdatePlayerScores()
        {
            // Update player scores here
            Player1Score = _gameLogic.Player1.Score;
            Player2Score = _gameLogic.Player2.Score;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}