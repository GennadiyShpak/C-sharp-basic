namespace Shceduler;

class Validator
{
    public static bool IsStatusValid(string status)
    {
        return int.TryParse(status, out var statusIndex) && statusIndex > 0 && statusIndex <= 2;
    }
    public static bool IsAnswerValid(string userAction)
    {
        return int.TryParse(userAction, out var actionNumber) && actionNumber > 0 && actionNumber <= 4;
    }

    public static bool IsNumberOfTaskValid(string taskNumber, int listSize)
    {
        return int.TryParse(taskNumber, out var taskIndex) && taskIndex >= 0 && taskIndex <= listSize;
    }
}
