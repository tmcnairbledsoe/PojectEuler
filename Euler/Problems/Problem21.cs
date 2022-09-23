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
    internal class Problem21
    {
        public long Solve()
        {
            // Let d(n) be defined as the sum of proper divisors of n(numbers less than n which divide evenly into n).
            //If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

            //For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284.The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

            //Evaluate the sum of all the amicable numbers under 10000.


            return SolutionOne(1000);
        }

        //First try, brute force. Use Solution for Problem 12
        private long SolutionOne(int topNumber)
        {
            long sum = 0;

            return sum;
        }

}
}