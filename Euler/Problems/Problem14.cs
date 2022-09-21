using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem14
    {
        public long Solve()
        {
            //The following iterative sequence is defined for the set of positive integers:

            //n → n / 2(n is even)
            //n → 3n + 1(n is odd)

            //Using the rule above and starting with 13, we generate the following sequence:

            //            13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
            //It can be seen that this sequence(starting at 13 and finishing at 1) contains 10 terms.Although it has not been proved yet(Collatz Problem), it is thought that all starting numbers finish at 1.

            //Which starting number, under one million, produces the longest chain?

            //NOTE: Once the chain starts the terms are allowed to go above one million.
            return SolutionOne(1000000);
        }

        //Brute Force
        private long SolutionOne(long highestNumber)
        {
            long longestSequence = 0;
            long numberWithHighestSequence = 0;

            for (long i = highestNumber - 1; i > 1; i--)
            {
                long sequence = Helpers.GetCollatzSequenceLength(i);

                if (sequence > longestSequence)
                {
                    longestSequence = sequence;
                    numberWithHighestSequence = i;
                }
            }

            return numberWithHighestSequence;
        }
    }
}