using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem20
    {
        public long Solve()
        {
            //n! means n × (n − 1) × ... × 3 × 2 × 1

            //For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
            //and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

            //Find the sum of the digits in the number 100!


            return SolutionThree(100);
        }

        //First try, brute force.
        private long SolutionOne(int number)
        {
            long sum = 0;
            string factorial = "1";

            for (int i = 2; i <= number; i++)
            {
                factorial = Helpers.LongMultiplication(i.ToString(),factorial);
            }

            foreach (char digit in factorial)
            {
                sum += Convert.ToInt32(digit.ToString());
            }

            return sum;
        }

        //Testing... Doesnt work.
        private long SolutionTwo(int number)
        {
            double sum = 0;
            double factorial = Helpers.Factorial((double)number);

            while(factorial > 0)
            {
                sum += factorial % 10;
                factorial /= 10;
            }

            return (long)sum;
        }

        //Taken from forums. BigInteger is much much easier than doing what I have been doing, doing math with strings. Takes all the fun out of it really.
        private long SolutionThree(int number)
        {
            BigInteger g = new BigInteger(100);
            long answer = 0;
            string NoString = Helpers.BigIntFactorial(g).ToString();
            int charlength = NoString.Length;
            char[] NoChars = NoString.ToCharArray();
            for (int i = 0; i<charlength; i++)
                answer += Convert.ToInt32(NoChars[i].ToString());

            return answer;
        }

}
}