﻿// You are given a set of infinite number of coins (1, 2 and 5) and end value – N. Write an
// algorithm that gives the number of coins needed so that the sum of the coins equals N.
// Example: N = 33 => 6 coins x 5 + 1 coin x 2 + 1 coin x 1

namespace Coins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static int[] coinValues = new int[] { 5, 2, 1 };
        static int[] coinCount;
        static int valueToFind;

        public static void Main()
        {
            Console.Write("Please enter a value: ");
            valueToFind = int.Parse(Console.ReadLine());

            coinCount = new int[coinValues.Length];

            Greedy(coinCount, 0, 0);
        }

        public static void Greedy(int[] coinCount, int currentPos, int currentSum)
        {

            for (int i = currentPos; i < coinCount.Length; i++)
            {
                coinCount[i] = (valueToFind - currentSum) / coinValues[i];
                currentSum += coinCount[i] * coinValues[i];
            }

            if (currentSum < valueToFind)
            {
                Greedy(coinCount, currentPos + 1, currentSum);
            }

            if (currentSum == valueToFind)
            {
                PrintCounts(coinCount);
            }
        }

        public static void PrintCounts(int[] coinCount)
        {
            for (int i = 0; i < coinCount.Length; i++)
            {
                Console.WriteLine("{0} coints with value {1}", coinCount[i], coinValues[i]);
            }
        }
    }
}
