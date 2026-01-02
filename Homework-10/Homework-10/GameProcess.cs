using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class HangmanGame
    {
        private static bool isInProgress = true;
        private static List<Player> playerList = [];
        private static WordGenerator wordGenerator = new WordGenerator();

        public static void InitGameSettings()
        {
            Console.WriteLine("Welcome to the Hangman game");
            Console.WriteLine(HangmanStepExtensions.GetHangmanView(HangmanStep.Full));
            Console.WriteLine();

            var gameDificulty = InitUserAction<GameDifficulty>(AskDificulty);
            var gameMode = InitUserAction<GameMode>(ChooseGameMode);
            ActivatePlayerList(gameDificulty, gameMode);
            GameProcess();
        }

        public static void GameProcess()
        {
            do
            {
                foreach(var player in playerList)
                {
                    player.PlayerMove();
                    var status = player.GetGameStatus();
                    ValidateGameStatus(status, player);

                    if (!isInProgress)
                    {
                        return;
                    }
                }
            } while (isInProgress);
        }

        private static void ValidateGameStatus(GameStatus status, Player player)
        {
            if (status == GameStatus.Win)
            {
                Console.WriteLine("Congratulation you win!!!");
            } else if (status == GameStatus.Lose)
            {
                Console.WriteLine($"You are the loser!!!! The answer was {player.GetSecretWord()}");
            }

            isInProgress = status == GameStatus.InProgress;
        }

        private static void ActivatePlayerList(GameDifficulty gameDificulty, GameMode gameMode)
        {
            AddNewPlayer(secretWord => new HumanPlayer(secretWord), gameDificulty);

            if (gameMode == GameMode.PvP)
            {
                AddNewPlayer(secretWord => new HumanPlayer(secretWord), gameDificulty);
            } else if (gameMode == GameMode.Ai)
            {
                AddNewPlayer(secretWord => new AiPlayer(secretWord), gameDificulty);
            }
        }

        private static void AddNewPlayer(Func<string, Player> playerFactory, GameDifficulty gameDificulty)
        {
            var secretWord = wordGenerator.InitSecretWord(gameDificulty);
            playerList.Add(playerFactory(secretWord));
        }

        private static void ChooseGameMode()
        {
            Console.WriteLine("Choose game mode:");
            Console.WriteLine("\t1 - Single player");
            Console.WriteLine("\t2 - PvP mode");
            Console.WriteLine("\t3 - AI versus");
            Console.WriteLine();
        }

        private static TEnum InitUserAction<TEnum>(Action consoleInfoCallback)
            where TEnum : struct, Enum
        {
            consoleInfoCallback();
            var answer = Console.ReadLine();

            if (Enum.TryParse<TEnum>(answer, out var convertedAnswer))
            {
                return convertedAnswer;
            }

            return InitUserAction<TEnum>(consoleInfoCallback);
        }

        private static GameDifficulty GetUserAnswer()
        {
            AskDificulty();
            var answer = Console.ReadLine();

            if (Enum.TryParse<GameDifficulty>(answer, out var difficulty))
            {
                return difficulty;
            }

            return GetUserAnswer();
        }

        private static void AskDificulty()
        {
            Console.WriteLine("Please choose the game difficulty:");
            Console.WriteLine("\t1 - Easy");
            Console.WriteLine("\t2 - Medium");
            Console.WriteLine("\t3 - Hard");
            Console.WriteLine();
        }
    } 
}
