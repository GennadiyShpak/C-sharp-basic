namespace Homework_8
{
    class Solutions
    {
        public static int FindSecondBiggestNumber(int[,] numberList)
        {
            int biggestNumber = 0;
            int secondBiggestNumber = 0;

            for (int i = 0; i < numberList.GetLength(0); i++)
            {
                for (uint j = 0; j < numberList.GetLength(1); j++)
                {
                    int currentNumber = numberList[i, j];

                    if (currentNumber > biggestNumber)
                    {
                        secondBiggestNumber = biggestNumber;
                        biggestNumber = numberList[i, j];
                    }

                    if (currentNumber < biggestNumber && currentNumber > secondBiggestNumber)
                    {
                        secondBiggestNumber = currentNumber;
                    }
                }
            }

            return secondBiggestNumber;
        }

        public static int[,] SortTwoLevelArray(int[,] arr)
        {
            int arrLenghts = arr.GetLength(0);
            int elCount = arr.GetLength(1);
            int[] arrayCopy = new int[arrLenghts * elCount];
            int currentIteration = 0;

            for (int i = 0; i < arrLenghts; i++)
            {
                for (int j = 0; j < elCount; j++)
                {
                    for (int k = 0; k < arrayCopy.Length; k++)
                    {
                        if (arr[i, j] < arrayCopy[k] || k == currentIteration)
                        {
                            currentIteration++;
                            Array.Copy(arrayCopy, k, arrayCopy, k + 1, arrayCopy.Length - k - 1);
                            arrayCopy[k] = arr[i, j];
                            break;
                        }
                    }
                }
            }

            currentIteration = 0;
            for (int i = 0; i < arrLenghts; i++)
            {
                for (int j = 0; j < elCount; j++)
                {
                    arr[i, j] = arrayCopy[currentIteration++];
                }
            }

            return arr;
        }

        public static int[] RemoveArrayElement(int[] targetArray, uint elementIndex)
        {
            int[] newArray = new int[targetArray.Length - 1];

            if (elementIndex > targetArray.Length - 1)
            {
                Console.WriteLine("Provided index is incorrect");
                
                return targetArray;
            }

            for (int i = 0; i < targetArray.Length; i++)
            {
                if (i == elementIndex)
                {
                    continue;
                }

                if (i < elementIndex)
                {
                    newArray[i] = targetArray[i];
                }
                if (i > elementIndex)
                {
                    newArray[i - 1] = targetArray[i];
                }
            }

            return newArray;
        }

        public static string DiagonalSum(int[,] targetArray)
        {
            int sum = 0;
            bool isSingleCenter = targetArray.GetLength(1) % 2 != 0;
            var arrayLength = targetArray.GetLength(0);

            if (arrayLength != targetArray.GetLength(1))
            {
                return "Provided array is incorrect";
            }

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < arrayLength; i++)
            {
                sum1 += targetArray[i, i];
                sum2 += targetArray[i, arrayLength - 1 - i];
            }

            Console.WriteLine($"SUM-1 {sum1}");
            Console.WriteLine($"SUM-2 {sum2}");

            return $"First diagonal is - {sum}, second - {sum2}";
        }
    }
}
