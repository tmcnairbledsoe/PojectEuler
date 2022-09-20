using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    internal class Problem1
    {
        public long Solve()
        {
            //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.The sum of these multiples is 23.
            //Find the sum of all the multiples of 3 or 5 below 1000.

            //Answer: 233168

            return SolutionTwo(1000);
        }
        private long SolutionOne(int topNum)
        {
            var numberList = new HashSet<int>();

            for (int i = 3; i < topNum; i = i + 3)
            {
                numberList.Add(i);
            }

            for (int i = 5; i < topNum; i = i + 5)
            {
                numberList.Add(i);
            }

            return numberList.Sum();
        }
        private long SolutionTwo(int topNum)
        {
            //We need to solve for below the top number
            topNum = topNum - 1;
            return SumOfMultiples(topNum, 3) + SumOfMultiples(topNum, 5) - SumOfMultiples(topNum, 15);
        }

        private long SumOfMultiples(int target, int number)
        {
            return number*Helpers.CalculateTriangleNumber(target / number);
        }
    }
}
