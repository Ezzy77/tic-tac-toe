namespace tic_tac_toe.Models
{
    public class GameLogic
    {
        public readonly GameBoard _gameBoard;
        private readonly Player[] _players;
        public Player Player1 => _players[0];
        public Player Player2 => _players[1];
        public Player CurrentPlayer { get; private set; }

        public GameLogic(Player player1, Player player2)
        {
            _gameBoard = new GameBoard();
            _players = new[] { player1, player2 };
            CurrentPlayer = _players[0];
        }

        public bool MakeMove(int row, int col)
        {
            if (!IsValidMove(row, col)) return false;
            _gameBoard.UpdateCell(row, col, CurrentPlayer.Symbol);

            // computer move 
            // if (CurrentPlayer.Type == PlayerType.Computer)
            // {
            //     
            // }
            return true;


        }

        private bool IsValidMove(int row, int col)
        {
            return !(row < 0 || row >= 3 || col < 0 || col >= 3) && _gameBoard.IsCellEmpty(row, col);
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == _players[0]) ? _players[1] : _players[0];
        }

        public void ResetGame()
        {
            _gameBoard.ResetBoard();
            CurrentPlayer = _players[0];
        }

        public bool CheckForWin(PlayerSymbol playerSymbol)
        {
            Console.WriteLine($"Checking if {playerSymbol} has won");
            return HasPlayerWonInRows(playerSymbol) || HasPlayerWonInColumns(playerSymbol) ||
                   HasPlayerWonInDiagonal(playerSymbol);
        }

        private bool HasPlayerWonInRows(PlayerSymbol playerSymbol)
        {
            char symbol = (char)playerSymbol;
            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine("Row {0}: {1} {2} {3}", row, _gameBoard.Board[row, 0], _gameBoard.Board[row, 1],
                    _gameBoard.Board[row, 2]);
                if (_gameBoard.Board[row, 0] == symbol &&
                    _gameBoard.Board[row, 1] == symbol &&
                    _gameBoard.Board[row, 2] == symbol)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasPlayerWonInColumns(PlayerSymbol playerSymbol)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.WriteLine("Checking column {0}: cell ASCII = {1}, symbol ASCII = {2}",
                    col, (int)_gameBoard.Board[0, col], (int)(char)playerSymbol);
                if (_gameBoard.Board[0, col] == (char)playerSymbol &&
                    _gameBoard.Board[1, col] == (char)playerSymbol &&
                    _gameBoard.Board[2, col] == (char)playerSymbol)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasPlayerWonInDiagonal(PlayerSymbol playerSymbol)
        {
            char symbol = (char)playerSymbol;
            Console.WriteLine("Diagonals: {0} {1} {2}, {3} {4} {5}",
                _gameBoard.Board[0, 0], _gameBoard.Board[1, 1], _gameBoard.Board[2, 2], _gameBoard.Board[0, 2],
                _gameBoard.Board[1, 1], _gameBoard.Board[2, 0]);

            bool hasWonInLeftRightDiagonal = _gameBoard.Board[0, 0] == symbol &&
                                             _gameBoard.Board[1, 1] == symbol &&
                                             _gameBoard.Board[2, 2] == symbol;

            bool hasWonInRightLeftDiagonal = _gameBoard.Board[0, 2] == symbol &&
                                             _gameBoard.Board[1, 1] == symbol &&
                                             _gameBoard.Board[2, 0] == symbol;

            return hasWonInLeftRightDiagonal || hasWonInRightLeftDiagonal;
        }


        public bool CheckForDraw()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (_gameBoard.IsCellEmpty(i, j)) return false;
                }
            }

            return true;
        }


       public (int score, int row, int col) Minimax(GameBoard board, PlayerSymbol playerSymbol, int alpha, int beta)
{
    // Base case – return the score if game is over
    if (CheckForWin(PlayerSymbol.X)) return (-10, -1, -1); // Assuming -10 represents a loss for the AI player
    if (CheckForWin(PlayerSymbol.O)) return (10, -1, -1); // Assuming 10 represents a win for the AI player
    if (CheckForDraw()) return (0, -1, -1); // Assuming 0 represents a draw

    List<(int score, int row, int col)> moves = new List<(int, int, int)>();

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (board.IsCellEmpty(i, j))
            {
                // Make a copy of the original board
                GameBoard simulatedBoard = board.Clone();
                
                simulatedBoard.UpdateCell(i, j, playerSymbol); // Make the move
                int score = Minimax(simulatedBoard, playerSymbol == PlayerSymbol.O ? PlayerSymbol.X : PlayerSymbol.O, alpha, beta)
                    .Item1; // Recursively explore the next move
                moves.Add((score, i, j));

                // Alpha Beta Pruning
                if (playerSymbol == PlayerSymbol.O)
                {
                    alpha = Math.Max(alpha, score);
                    if (beta <= alpha)
                        break;
                }
                else
                {
                    beta = Math.Min(beta, score);
                    if (beta <= alpha)
                        break;
                }
            }
        }
    }

    // If no moves are available, return a default value
    if (moves.Count == 0)
    {
        return (0, -1, -1); // Adjust this default value as needed
    }

    int bestMove = 0;
    int bestScore = playerSymbol == PlayerSymbol.O ? -1000 : 1000;

    for (int i = 0; i < moves.Count; i++)
    {
        if ((playerSymbol == PlayerSymbol.O && moves[i].Item1 > bestScore) ||
            (playerSymbol == PlayerSymbol.X && moves[i].Item1 < bestScore))
        {
            bestMove = i;
            bestScore = moves[i].Item1;
        }
    }

    return moves[bestMove];
}
    }
}

