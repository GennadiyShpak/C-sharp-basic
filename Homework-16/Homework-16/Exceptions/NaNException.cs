namespace Homework_16.Exeptions;

internal class NaNException : Exception
{
    public string userInput = string.Empty;

    public NaNException(string userInput, string message = "Your input is not a number") : base(message)
    {
        this.userInput = userInput;
    }
}
