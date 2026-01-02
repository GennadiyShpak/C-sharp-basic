namespace Homework_9
{
    class Homework_9_1
    {
        public static string FullNameComparison(string fullName)
        {
            var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var firstFullNamePart = parts.ElementAtOrDefault(0) ?? "";
            var secondFullNamePart = parts.ElementAtOrDefault(1) ?? "";

            var isSameFirstLetter = firstFullNamePart[0] == secondFullNamePart[0];
            var result = isSameFirstLetter ? "same" : "different";

            return  $"Name and Surname start with the {result} first letter";
        }
    }
}
