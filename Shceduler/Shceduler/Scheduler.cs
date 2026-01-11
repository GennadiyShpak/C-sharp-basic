using Shceduler.Enums;

namespace Shceduler;

class Scheduler
{
    private static readonly List<ScheduleItem> schedule = new();
    private static readonly string[] ActionList = ["1 - Add action", "2 - Show all task", "3 - Change activity status for task", "4 - Remove task"];
    private static readonly string activeStatus = "Active";
    private static readonly string inActiveStatus = "Not Active";
    private static bool IsSchedulerActive { get; set; } = true;

    public static void Session()
    {
        Console.WriteLine("Welcome in scheduler");
        Console.WriteLine();

        do
        {
            var action = GetUserAction();
            HandleUserAction(action);
        } while (IsSchedulerActive);
    }

    private static Actions GetUserAction()
    {
        Console.WriteLine("Please choose your action: ");
        foreach (var action in ActionList)
        {
            Console.WriteLine(action);
        }
        Console.WriteLine();

        var userAction = Console.ReadLine();
        Console.WriteLine();

        if (Validator.IsAnswerValid(userAction))
        {
            return (Actions)int.Parse(userAction);
        }
        else
        {
           return GetUserAction();
        }

    }

    private static void HandleUserAction(Actions userAction)
    {
        switch (userAction)
        {
            case Actions.AddTask:
                AddTask();
                break;

            case Actions.ShowTaskList:
                ShowTaskList();
                break;

            case Actions.ChangeTaskStatus:
                ChangeTaskStatus();
                break;

            case Actions.RemoveTask:
                RemoveTask();
                break;
        }
    }

    private static void AddTask()
    {
        var task = AskUserAction("Please provide task");
        Console.WriteLine("Please provide status for new task:");
        Console.WriteLine("1 - Active");
        Console.WriteLine("2 - InActive");
        Console.WriteLine();
        var status = Console.ReadLine();
        Console.WriteLine();

        if (Validator.IsStatusValid(status))
        {
            var convertedStatus = ConvertStatusToBool(status);
            schedule.Add(new ScheduleItem(convertedStatus, task));
        }
    }

    private static bool ConvertStatusToBool(string status)
    {
        return int.Parse(status) == 1 ? true : false;
    }

    private static void ShowTaskList()
    {
        for (var i = 0; i < schedule.Count(); i++)
        {
            Console.WriteLine($"#{i}, Status - {ConvertStatusToString(schedule[i].IsActive)}, \"{schedule[i].Task}\"");
        }
        Console.WriteLine();
    }

    private static string ConvertStatusToString(bool isActive)
    {
        return isActive ? activeStatus : inActiveStatus;
    }

    private static void ChangeTaskStatus()
    {
        var taskNumber = AskUserAction("Please number of task");

        if (Validator.IsNumberOfTaskValid(taskNumber, schedule.Count()))
        {
            var taskIndex = int.Parse(taskNumber);
            schedule[taskIndex] = schedule[taskIndex] with { IsActive = !schedule[taskIndex].IsActive };
            Console.WriteLine("The action was sucseed");
        }
        else
        {
            ChangeTaskStatus();
        }
    }

    private static void RemoveTask()
    {
        var taskNumber = AskUserAction("Please number of task");

        if (Validator.IsNumberOfTaskValid(taskNumber, schedule.Count()))
        {
            var taskIndex = int.Parse(taskNumber);
            schedule.RemoveAt(taskIndex);
            Console.WriteLine("The action was sucseed");
        }
        else
        {
            RemoveTask();
        }
    }

    private static string AskUserAction(string title)
    {
        Console.WriteLine(title);
        var task = Console.ReadLine();
        Console.WriteLine();

        return task;
    }
}
