using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    static class Helpers
    {
        private static List<long> listOfPrimes = new List<long>() { 2 };

        //Math
        public static double Factorial(double number)
        {
            if (number == 0)
                return 1;
            else
                return number * Factorial(number - 1);
        }

        public static BigInteger BigIntFactorial(BigInteger number)
        {
            if (number == 0)
                return 1;
            else
                return number * BigIntFactorial(number - 1);
        }

        public static string LongMultiplication(string numberOne, string numberTwo)
        {
            List<string> numbersToSum = new List<string>();
            string trailingZeros = "";
            for (int i = numberOne.Length - 1; i >= 0; i--)
            {
                int carryover = 0;
                string totalProduct = "";
                for (int j = numberTwo.Length - 1; j >= 0; j--)
                {
                    int product = (Convert.ToInt32(numberOne[i].ToString()) * Convert.ToInt32(numberTwo[j].ToString())) + carryover;
                    if (j != 0)
                    {
                        totalProduct = String.Concat(product.ToString()[product.ToString().Length - 1], totalProduct);
                    }
                    else
                    {
                        totalProduct = String.Concat(product.ToString(), totalProduct);
                    }
                    carryover = product / 10;
                }
                numbersToSum.Add(String.Concat(totalProduct, trailingZeros));
                trailingZeros += "0";
            }
            return LongAddition(numbersToSum.ToArray());
        }

        public static string LongAddition(string[] arrayOfNumbers)
        {
            int numberSize = 0;
            long remainder = 0;
            string theNumber = "";

            if (arrayOfNumbers.Length == 0)
                return "";
            if (arrayOfNumbers.Length == 1)
                return arrayOfNumbers[0];

            foreach (string number in arrayOfNumbers)
            {
                if (number.Length > numberSize)
                {
                    numberSize = number.Length;
                }
            }

            for (int i = numberSize - 1; i >= 0; i--)
            {
                long rowSum = remainder;
                foreach (string number in arrayOfNumbers)
                {
                    if (i - (numberSize - number.Length) >= 0)
                        rowSum += Convert.ToInt32(number[i - (numberSize - number.Length)].ToString());
                }

                if (i == 0)
                    theNumber = String.Concat(rowSum.ToString(), theNumber);
                else
                    theNumber = String.Concat(rowSum.ToString()[rowSum.ToString().Length - 1], theNumber);

                remainder = rowSum / 10;
            }
            return theNumber;
        }

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
