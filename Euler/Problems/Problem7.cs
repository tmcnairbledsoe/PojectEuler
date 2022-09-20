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

            int primeNumberToReach = 10001;
            int sequenceNumber = 0;
            long theNumber = 2;


            while (sequenceNumber < primeNumberToReach)
            {
                if (Helpers.IsPrime(theNumber))
                {
                    sequenceNumber++;
                    if (sequenceNumber == primeNumberToReach)
                    {
                        return theNumber;
                    }
                }
                theNumber++;
            }

            return theNumber;
        }
    }
}