using Homework_8;
int[,] unsortedArray = { { 5, 2, 6, -1 }, { 70, 8, 1, 2 }, { 52, 71, 14, 4 }, { 74, 32, 22, 28 } };

int[] numbers = { 1, 2, 3, 4 };

int secondBiggestNumberInstance = Solutions.FindSecondBiggestNumber((int[,])unsortedArray.Clone());

var sortedArray = Solutions.SortTwoLevelArray((int[,])unsortedArray.Clone());

var clearedArray = Solutions.RemoveArrayElement(numbers, 3);

var diagonalSummaryResult = Solutions.DiagonalSum((int[,])unsortedArray.Clone());
