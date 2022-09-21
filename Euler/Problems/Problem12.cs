﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem12
    {
        private List<long> listOfPrimes = new List<long>() { 2 };
        public long Solve()
        {
            //The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

            //1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

            //Let us list the factors of the first seven triangle numbers:

            // 1: 1
            // 3: 1,3
            // 6: 1,2,3,6
            //10: 1,2,5,10
            //15: 1,3,5,15
            //21: 1,3,7,21
            //28: 1,2,4,7,14,28
            //We can see that 28 is the first triangle number to have over five divisors.

            //What is the value of the first triangle number to have over five hundred divisors ?

            return SolutionTwo(500);
        }

        //Brute Force (Doesn't Work)
        private long SolutionOne(int numOfDivisors)
        {
            int currentNumber = 1;
            while (true)
            {
                int divisors = 1;
                long currentTriangleNumber = Helpers.CalculateTriangleNumber(currentNumber);

                for (int i = 1; i <= currentTriangleNumber/2; i++)
                {
                    if (currentTriangleNumber % i == 0)
                    {
                        divisors++;
                    }
                }
                if (divisors > numOfDivisors)
                {
                    return currentTriangleNumber;
                }
                currentNumber++;
            }
        }

        //Second Self Made Solution
        private long SolutionTwo(int numOfDivisors)
        {
            int currentNumber = 1;
            while (true)
            {
                long currentTriangleNumber = Helpers.CalculateTriangleNumber(currentNumber);
                int divisors = Helpers.GetNumberOfDivisors(currentTriangleNumber);
                
                if (divisors > numOfDivisors)
                {
                    return currentTriangleNumber;
                }
                currentNumber++;
            }
        }
    }
}