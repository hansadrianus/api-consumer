using System;

namespace XtramileSolutions
{
    internal class Program
    {
        public static void Main()
        {
            //Task 1
            int[] numbers1 = new int[] { 1, 2, 1, 3, 4, 4 };
            FindUniqueNumbers(numbers1);

            //Task 2
            int[] numbers2 = new int[] { 5, 9, 7, 11, 20, 10, 3, 50 };
            Console.WriteLine(FindMaxSum(numbers2));
        }


        public static void FindUniqueNumbers(int[] numbers)
        {
            foreach (int number in numbers)
            {
                if (IsThisDuplicate(number, numbers))
                    continue;
                Console.WriteLine(number);
            }
        }

        public static bool IsThisDuplicate(int num, int[] numbers)
        {
            int countNum = 0;
            foreach (int number in numbers)
            {
                if (num == number)
                    countNum++;
            }

            return countNum > 1;
        }


        public static int FindMaxSum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i == j)
                        continue;

                    if (sum < (numbers[i] + numbers[j]))
                        sum = (numbers[i] + numbers[j]);
                }
            }

            return sum;
        }
    }
}
