using System;

namespace Hangman;

class WordGenerator
{
    private readonly Random random = new Random();
    private readonly Dictionary<GameDifficulty, string[]> WordsByDifficulty = new Dictionary<GameDifficulty, string[]>
        {
            { GameDifficulty.Easy, new string[] { "cat", "dog", "sun", "tree", "book", "fish", "ball", "hat", "car", "pen" } },
            { GameDifficulty.Medium, new string[] { "garden", "window", "rabbit", "pencil", "school", "travel", "orange", "monkey", "doctor", "castle" } },
            { GameDifficulty.Hard, new string[] { "architecture", "psychology", "refrigerator", "helicopter", "skyscraper", "questionnaire", "encyclopedia", "submarine", "microscope", "labyrinth" } }
        };

    public string InitSecretWord(GameDifficulty difficulty)
    {
        var wordList = WordsByDifficulty[difficulty];
        return wordList[GetIndex()];
    }

    private int GetIndex()
    {
        return random.Next(0, 9);
    }
}
