namespace Hangman
{
    enum GameDifficulty
    {
        Easy = 1,
        Medium,
        Hard,
    }

    enum HangmanStep
    {
        Empty,
        Head,
        Body,
        OneArm,
        TwoArms,
        Leg,
        Full
    }

    enum GameMode
    {
        Single = 1,
        PvP,
        Ai,
    }

    enum GameStatus
    {
        InProgress,
        Win,
        Lose
    }
}
