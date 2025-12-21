namespace Tick_tak_toe
{
    internal class GameProcess
    {
        private string[] lineOne = new string[] { "1", "2", "3" };
        private string[] lineTwo = new string[] { "4", "5", "6" };
        private string[] lineThree = new string[] { "7", "8", "9" };
        private string playerSymbol = "X";
        private PlayerActions playerActions;
        private string[][] field;

        public bool isGameOver { get; private set; } = false;
        public uint turnNumber { get; private set; } = 1;

        public GameProcess(PlayerActions actions)
        {
            playerActions = actions;
            field = [lineOne, lineTwo, lineThree];
        }

        public void PrintField()
        {
            Console.WriteLine();
            for (int i = 0; i < field.Length; i++)
            {
                Console.WriteLine(" " + string.Join(" | ", field[i]));
                if (i < field.Length - 1)
                {
                    Console.WriteLine("---+---+---");
                }
            }
            Console.WriteLine();
        }

        public void ShowGreeting()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            Console.WriteLine();
        }

        public void StartGame()
        {
            ShowGreeting();
            PrintField();

            do
            {
                uint playerNumber = playerActions.GetPlayerNumber(turnNumber);

                uint cellNumber = playerActions.PlayerMove(turnNumber++, playerNumber, IsFieldAlreadyUsed);

                UpdateField(cellNumber, playerNumber);

                PrintField();

                GameResult gameResult = GetGameResult();

                ResultHandling(gameResult);

            } while (!isGameOver);
        }

        private void UpdateField(uint cellNumber, uint playerNumber)
        {
            playerSymbol = playerNumber == 1 ? "X" : "O";
            uint fieldLevel = GetFieldLevel(cellNumber);
            AddFieldValue(fieldLevel, cellNumber);
        }

        private uint GetFieldLevel(uint cellNumber)
        {
            if (cellNumber >= 1 && cellNumber <= 3)
                return 0;
            else if (cellNumber >= 4 && cellNumber <= 6)
                return 1;
            else
                return 2;
        }

        private void AddFieldValue(uint fieldLevel, uint cellValue)
        {
            for(uint i = 0; i < field[fieldLevel].Length; i++)
            {
                if (field[fieldLevel][i] == cellValue.ToString())
                {
                    field[fieldLevel][i] = playerSymbol;
                }
            }
        }

        private GameResult GetGameResult()
        {
            bool horizontalResult = CheckHorizontal();
            if (horizontalResult)
            {
                return GameResult.Win;
            }

            bool verticalResult = CheckVertical();
            if (verticalResult)
            {
                return GameResult.Win;
            }

            bool diagonalResult = CheckDiagonal();
            if (diagonalResult)
            {
                return GameResult.Win;
            }

            if (turnNumber == 9)
                return GameResult.Draw;

            return GameResult.Continue;
        }

        private bool CheckHorizontal()
        {
            return field.Any(line => line.All(cell => cell == playerSymbol));
        }

        private bool CheckVertical()
        {
            for (uint i = 0; i < field[0].Length; i++)
            {
                if (field.All(row => row[i] == playerSymbol))
                    return true;
            }

            return false;
        }

        private bool CheckDiagonal()
        {
            bool leftDiagonal = field[0][0] == playerSymbol && field[1][1] == playerSymbol && field[2][2] == playerSymbol;
            bool rightDiagonal = field[0][2] == playerSymbol && field[1][1] == playerSymbol && field[2][0] == playerSymbol;

            return leftDiagonal || rightDiagonal;
        }

        private void ResultHandling(GameResult result)
        {
            if (result == GameResult.Continue)
            {
                return;
            }

            string message = result == GameResult.Win
                ? $"Player {playerSymbol} win"
                : "Game result - draw";

            isGameOver = true;
            Console.WriteLine(message);
        }

        bool IsFieldAlreadyUsed(string userInput)
        {
            return field.Any(line => line.Contains(userInput));
        }
    }
}
