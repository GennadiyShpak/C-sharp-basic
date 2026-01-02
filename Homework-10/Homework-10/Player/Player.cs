using System.Text;

namespace Hangman
{
    abstract class Player
    {
        public int attemptCount { get; protected set; } = 0;

        protected readonly List<char> alphabet = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
        protected readonly StringBuilder visibleWord = new(string.Empty);
        protected string secretWord = string.Empty;

        private readonly char underScore = '_';

        public Player(string secretWord)
        {
            this.secretWord = secretWord;
            GenerateVisibleWord();
        }

        public abstract void PlayerMove();

        public string ShowResult()
        {
            return visibleWord.ToString();
        }

        public string ShowAlphabet()
        {
            return string.Join(", ", alphabet);
        }

        public GameStatus GetGameStatus()
        {
            if (!visibleWord.ToString().Contains(underScore) && attemptCount < 6)
            {
                return GameStatus.Win;
            } else if (attemptCount >= 6)
            {
                return GameStatus.Lose;
            }

            return GameStatus.InProgress;
        }

        public void HandleUserMove(char userInput)
        {
            var indexList = GetLetterIndex(userInput);

            if (indexList.Count > 0)
            {
                ChangeVisibleWord(indexList, userInput);
                Console.WriteLine($"Your answer was correct, letter \"{userInput}\" present in secret word");
                Console.WriteLine();
                Console.WriteLine($"Check result {visibleWord.ToString()}");
            }
            else
            {
                attemptCount = attemptCount + 1;
                Console.WriteLine($"Your answer is incorrect, there is {6 - attemptCount} attempts left");
            }

            ShowHangman();
        }

        public string GetSecretWord()
        {
            return secretWord;
        }

        protected List<int> GetLetterIndex(char userInput)
        {
            List<int> result = [];

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == userInput)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private void ChangeVisibleWord(List<int> indexList, char userInput)
        {
            foreach (var index in indexList)
            {
                visibleWord.Remove(index, 1);
                visibleWord.Insert(index, userInput);
            }
        }

        private void ShowHangman()
        {
            var picture = HangmanStepExtensions.GetHangmanViewByStepNumber(attemptCount);
            Console.WriteLine(picture);
        }

        private void GenerateVisibleWord()
        {
            foreach (var _letter in secretWord)
            {
                visibleWord.Append(underScore);
            }
        }
    }
}
