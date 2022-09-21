using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem5
    {
        public long Solve()
        {
            //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
            //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?

            //Answer: 232792560

            return SolutionThree(20);
        }

        private long SolutionOne(int topNumberInSequence)
        {
            int currentNumber = topNumberInSequence;

            while (true)
            {
                for (int i = topNumberInSequence - 1; i > 1; i--)
                {
                    if (currentNumber % i == 0)
                    {
                        if (i == 2)
                        {
                            return currentNumber;
                        }
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                currentNumber = currentNumber + topNumberInSequence;
            }
        }

        //Euler's algorithm
        private long SolutionTwo(int topNumberInSequence)
        {
            long lowestNumber = 1;
            bool varchecked = true;
            var limit = Math.Sqrt(topNumberInSequence);

            var listOfPrimes = new List<int>();

            for (int j = 1; j <= topNumberInSequence; j++)
            {
                if (Helpers.IsPrime(j))
                    listOfPrimes.Add(j);
            }

            foreach (int prime in listOfPrimes)
            {
                int exponent = 1;
                if (varchecked == true)
                {
                    if (prime <= limit)
                    {
                        exponent = (int)Math.Floor(Math.Log(topNumberInSequence)/Math.Log(prime));
                    }
                    else
                    {
                        varchecked = false;
                    }
                }
                lowestNumber *= (long)Math.Pow(prime,exponent);
            }

            return lowestNumber;
        }

        //Basic Algorithm Least Common Multiple
        private long SolutionThree(int topNumberInSequence)
        {
            var listOfNumbers = new List<long>();

            for (int i = 1; i <= topNumberInSequence; i++)
            {
                listOfNumbers.Add(i);
            }

            return Helpers.GetLeastCommonMultiple(listOfNumbers.ToArray());
        }
    }
}