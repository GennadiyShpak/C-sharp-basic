namespace Hangman;

class AiPlayer : Player
{
    private Random random = new Random();
    public AiPlayer(string secretWord) : base(secretWord)
    {
    }

    public override void PlayerMove()
    {
        var index = random.Next(0, alphabet.Count);
        var letter = alphabet[index];
        Console.WriteLine($"Ai opponent moved");
        Console.WriteLine($"It choosen letter - {letter}");
        HandleUserMove(letter);
    }
}
