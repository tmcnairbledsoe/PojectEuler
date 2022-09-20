using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    internal class Problem1
    {
        public int Solve()
        {
            //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.The sum of these multiples is 23.
            //Find the sum of all the multiples of 3 or 5 below 1000.

            //Answer: 233168

            var numberList = new HashSet<int>();

            for (int i = 3; i < 1000; i = i + 3)
            {
                numberList.Add(i);
            }

            for (int i = 5; i < 1000; i = i + 5)
            {
                numberList.Add(i);
            }

            return numberList.Sum();
        }
    }
}
