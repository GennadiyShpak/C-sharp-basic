namespace Hangman
{
    class HangmanStepExtensions
    {
        public static string GetHangmanView(HangmanStep step)
        {
            return step switch
            {
                HangmanStep.Empty => @"
  +---+
  |   |
      |
      |
      |
      |
=========",
                HangmanStep.Head => @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
                HangmanStep.Body => @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
                HangmanStep.OneArm => @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
                HangmanStep.TwoArms => @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
                HangmanStep.Leg => @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
                HangmanStep.Full => @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========",
                _ => ""
            };
        }

        public static string GetHangmanViewByStepNumber(int step)
        {
            var currentState = (HangmanStep)step;

            return GetHangmanView(currentState);
        }
    }
}
