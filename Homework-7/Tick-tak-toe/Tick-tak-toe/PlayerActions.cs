namespace Tick_tak_toe
{
    internal class PlayerActions
    {
        public uint PlayerMove(uint turnNumber, uint playerNumber, Func<string, bool> isFieldAlreadyUsed)
        {
            Console.Write($"Player {playerNumber} turn, please provide number of cell: ");
            string userInput = Console.ReadLine();
            return UserInputConvertation(turnNumber, userInput, playerNumber, isFieldAlreadyUsed);
        }

        public uint UserInputConvertation(uint turnNumber, string userInput, uint playerNumber, Func<string, bool> isFieldAlreadyUsed)
        {
            bool isInputValid = uint.TryParse(userInput, out uint number);
            if (isInputValid && number > 0 && number <= 9 && isFieldAlreadyUsed(userInput))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Dude your move is not so good, please think better and make your move");
                return this.PlayerMove(turnNumber, playerNumber, isFieldAlreadyUsed);
            }
        }

        public uint GetPlayerNumber(uint turnNumber)
        {
            return turnNumber % 2 == 1 ? (uint)1 : 2;
        }
    }
}
