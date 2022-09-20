using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem4
    {
        public long Solve()
        {
            //A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
            //Find the largest palindrome made from the product of two 3 - digit numbers.

            int numdigits = 3;

            return SolutionTwo(numdigits);
        }

        private long SolutionOne(int numDigits)
        {
            string digitString = "";

            for (int i = 0; i < numDigits; i++)
            {
                digitString = digitString + "9";
            }

            int digitInt32 = Convert.ToInt32(digitString);
            long biggestNumber = digitInt32 * digitInt32;

            for (long currentNumber = biggestNumber; currentNumber > 0; currentNumber--)
            {
                if (Helpers.IsPalindrome(currentNumber))
                {
                    for (int j = digitInt32; j > 0; j--)
                    {
                        Boolean productTooLow = j * digitInt32 < currentNumber;
                        if (productTooLow)
                        {
                            break;
                        }
                        if (currentNumber % j == 0)
                        {
                            for (int k = digitInt32; k > 0; k--)
                            {
                                long product = j * k;
                                if (product < currentNumber)
                                {
                                    break;
                                }
                                if (product == currentNumber)
                                {
                                    return currentNumber;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

        private long SolutionTwo(int numDigits)
        {
            int max = -1;

            for (int i = 999; i >= 100; i--)
            {
                if (max >= i * 999)
                {
                    break;
                }
                for (int j = 999; j >= i; j--)
                {
                    int p = i * j;
                    if (max < p && Helpers.IsPalindrome(p))
                    {
                        max = p;
                    }
                }
            }
            return max;
        }
    }
}