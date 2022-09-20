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
            int topNumberInSequence = 20;
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
    }
}