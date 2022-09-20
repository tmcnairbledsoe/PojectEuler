using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem6
    {
        public long Solve()
        {
            //The sum of the squares of the first ten natural numbers is, 385
            //The square of the sum of the first ten natural numbers is, 3025
            //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is. 2640
            //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

            int topNumberInSequence = 100;
            long sumOfSquares = 0;
            long squareOfSums = 0;

            for (int i = 1; i<= topNumberInSequence;i++)
            {
                sumOfSquares += i * i;
            }

            for (int i = 1; i <= topNumberInSequence; i++)
            {
                squareOfSums += i;
            }

            squareOfSums = squareOfSums * squareOfSums;

            return squareOfSums - sumOfSquares;
        }
    }
}