using System.Text;

namespace Homework_9._1.Solutions
{
    class TextReport
    {
        static private StringBuilder textContent = new StringBuilder();
        static private string reportTitle = "Title: ";
        static private string reportTitleMessage = "Please provide title for your report";
        static private string dateTitle = "Date: ";
        static private string dateMessage = "Please provide date for the report";
        static private string actionListTitle = "Action list: ";
        static private string actionListMessage = "Please provide the actions";
        static private string devider = "\n---------------------------------------------------\n";

        public static void GenerateTextReport()
        {
            bool shouldExpandRepord = true;

            do
            {
                GetData(reportTitleMessage, reportTitle);
                GetData(dateMessage, dateTitle);
                GetData(actionListMessage, actionListTitle);
                SaveData("", devider);
                Console.WriteLine(textContent.ToString());
                Console.WriteLine();
            } while (shouldExpandRepord);
        }

        private static void GetData(string userMessage, string dataTitle)
        {
            Console.WriteLine(userMessage);
            var reportDate = Console.ReadLine()!;

            SaveData(dataTitle, reportDate);

        }

        private static void SaveData(string title, string data)
        {
            textContent.Append($"{title}{data}\n");
            Console.WriteLine();
        }
    }
}
