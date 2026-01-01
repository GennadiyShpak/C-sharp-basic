using System.Text;

namespace Homework_9._1.Solutions
{
    class SpaceRemover
    {
        public static void RemoveSpace(string userInput)
        {
            var normalizedInput = new StringBuilder(userInput).Replace(" ", "").ToString();

            Console.WriteLine(normalizedInput);
        }
    }
}
