namespace Hangman;

class HumanPlayer : Player
{
    public HumanPlayer(string secretWord) : base(secretWord)
    {
    }

    public override void PlayerMove()
    {
        Console.WriteLine($"Please try to guess word. It has {secretWord.Length} letters");
        Console.WriteLine();
        Console.WriteLine($"!!!!!!!!!!{secretWord}");

        var userInput = AskUserMove();
        var validatedChar = HandleUserInput(userInput);
        HandleUserMove(validatedChar);
    }

    private char HandleUserInput(string userInput)
    {
        var isValid = char.TryParse(userInput.ToLowerInvariant(), out var letter);

        if (isValid && alphabet.Contains(letter))
        {
            alphabet.Remove(letter);

            return letter;
        }
        else
        {
            Console.WriteLine($"Your move - {userInput} is incorrect");
            string userAnswer = AskUserMove();

            return HandleUserInput(userAnswer);
        }
    }

    private string AskUserMove()
    {
        Console.Write($"Chose available letter from list: ");
        Console.Write(ShowAlphabet());
        Console.WriteLine();

        return Console.ReadLine()!;
    }
}
