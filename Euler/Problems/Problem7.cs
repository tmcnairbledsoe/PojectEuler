using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem7
    {
        public long Solve()
        {
            //By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
            //What is the 10001st prime number ?

            return SolutionOne(10001);
        }

        private long SolutionOne(int primeNumberToReach)
        {
            int sequenceNumber = 1;
            long theNumber = 1;


            if (primeNumberToReach == 1)
                return 2;

            do
            {
                theNumber = theNumber + 2;
                if (Helpers.IsPrime(theNumber))
                    sequenceNumber++;
            } while (sequenceNumber < primeNumberToReach);

            return theNumber;
        }
    }
}