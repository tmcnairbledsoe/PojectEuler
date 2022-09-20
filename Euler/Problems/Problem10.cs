using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem10
    {
        public long Solve()
        {
            //The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
            //Find the sum of all the primes below two million.


            long cap = 2000000;
            long sumOfPrimes = 5;

            for (int i = 5; i <= cap; i+=2)
            {
                if (Helpers.IsPrime(i))
                {
                    sumOfPrimes += i;
                }
            }

            return sumOfPrimes;
        }
    }
}