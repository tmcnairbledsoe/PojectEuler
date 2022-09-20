using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem3
    {
        public int Solve()
        {
            //The prime factors of 13195 are 5, 7, 13 and 29.
            //What is the largest prime factor of the number 600851475143 ?

            long number = 600851475143;
            var primeFactors = new List<int>();
            int divisor = 2;

            while (!Helpers.IsPrime(number))
            {
                if (number % divisor == 0)
                {
                    number = number/divisor;
                    primeFactors.Add(divisor);
                }
                else
                {
                    divisor++;
                }
            }

            primeFactors.Add(Convert.ToInt32(number));

            return primeFactors.Max();
        }
    }
}