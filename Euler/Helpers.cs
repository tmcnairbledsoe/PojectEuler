using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    static class Helpers
    {
        private static List<long> listOfPrimes = new List<long>() { 2 };

        //Prime check
        public static bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number < 4) return true;
            if (number % 2 == 0) return false;
            if (number < 9) return true;
            if (number % 3 == 0) return false;

            long r = (long)Math.Floor(Math.Sqrt(number));
            long f = 5;

            while (f<=r)
            {
                if (number % f == 0) return false;
                if (number % (f + 2) == 0) return false;
                f += 6;
            }

            return true;
        }

        //Palindrome Check
        public static bool IsPalindrome(long numberInput)
        {
            string input = numberInput.ToString();
            return input.SequenceEqual(input.Reverse());
        }
        public static bool IsPalindrome(string input)
        {
            return input.SequenceEqual(input.Reverse());
        }

        //Space check
        public static bool CanCheckVertical(int rows, int y, int spaces)
        {
            return rows > y + spaces;
        }
        public static bool CanCheckHorizontal(int cols, int x, int spaces)
        {
            return cols > x + spaces;
        }
        public static bool CanCheckDiagonalForward(int rows, int cols, int x, int y, int spaces)
        {
            return rows > y + spaces && cols > x + spaces;
        }
        public static bool CanCheckDiagonalBack(int rows, int cols, int x, int y, int spaces)
        {
            return rows > y + spaces && 0 <= x - spaces && cols >= spaces;
        }

        //Calculate Triangle Number
        public static long CalculateTriangleNumber(int number)
        {
            return number * (number + 1) / 2;
        }

        //Calculate Greatest Common Denominator
        public static long GetGreatestCommonDenominator(long[] numbers)
        {
            return numbers.Aggregate(GetGreatestCommonDenominator);
        }
        public static long GetGreatestCommonDenominator(long a, long b)
        {
            return b == 0 ? a : GetGreatestCommonDenominator(b, a % b);
        }

        //Calculate Least Common Multiple
        public static long GetLeastCommonMultiple(long[] numbers)
        {
            long lcm = 1;
            foreach (long number in numbers)
            {
                lcm = GetLeastCommonMultiple(lcm, number);
            }

            return lcm;
        }
        public static long GetLeastCommonMultiple(long a, long b)
        {
            long gcd = GetGreatestCommonDenominator(a, b);
            return (a * b) / gcd;
        }

        //Collatz Sequence
        public static long GetCollatzSequenceLength(long startingNumber)
        {
            long sequenceLength = 1;

            while(startingNumber != 1)
            {
                if (startingNumber % 2 == 0)
                    startingNumber = startingNumber / 2;
                else
                    startingNumber = (3 * startingNumber) + 1;
                sequenceLength++;
            }

            return sequenceLength;
        }

        //Divisors
        public static int GetNumberOfDivisors(long number)
        {
            HashSet<long> factors = new HashSet<long>() { 1, number };
            double limit = (long)Math.Sqrt(number);

            for (long j = listOfPrimes.Max() + 1; j <= limit; j++)
            {
                if (Helpers.IsPrime(j))
                    listOfPrimes.Add(j);
            }

            foreach (long prime in listOfPrimes)
            {
                if (number % prime == 0)
                {
                    factors.Add(prime);
                    factors.Add(number / prime);
                    for (long i = prime + prime; i <= limit; i += prime)
                    {
                        if (number % i == 0)
                        {
                            factors.Add(i);
                            factors.Add(number / i);
                        }
                    }
                }
            }

            return factors.Count();
        }
    }
}
