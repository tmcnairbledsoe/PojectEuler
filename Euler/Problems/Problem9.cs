using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem9
    {
        public long Solve()
        {
            //A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
            //a2 + b2 = c2
            //For example, 32 + 42 = 9 + 16 = 25 = 52.

            //There exists exactly one Pythagorean triplet for which a +b + c = 1000.
            //Find the product abc.

            return SolutionTwo(1000);
        }

        private long SolutionOne(int pythagoreanSum)
        {
            long iterations = 0;
            int largestA = pythagoreanSum / 3;

            for (int a = 1; a <= largestA; a++)
            {
                for (int b = a + 1; a + b + b + 1 <= pythagoreanSum; b++)
                {
                    for (int c = b + 1; a + b + c <= pythagoreanSum; c++)
                    {
                        iterations++;
                        if (a + b + c == pythagoreanSum)
                        {
                            if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                            {
                                Console.WriteLine(iterations);
                                return a * b * c;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(iterations);
            return -1;
        }

        private long SolutionTwo(int pythagoreanSum)
        {
            long iterations = 0;
            int largestA = pythagoreanSum / 3;

            for (int a = 1; a <= largestA; a++)
            {
                for (int b = a + 1; a + b + b + 1 <= pythagoreanSum; b++)
                {
                    iterations++;
                    int c = pythagoreanSum - b - a;
                    if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                    {
                        Console.WriteLine(iterations);
                        return a * b * c;
                    }
                }
            }

            Console.WriteLine(iterations);
            return -1;
        }
    }
}