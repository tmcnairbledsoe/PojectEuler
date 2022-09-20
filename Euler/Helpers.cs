using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    static class Helpers
    {
        //Prime Sieve
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number < 4) return true;
            if (number % 2 == 0) return false;
            if (number < 9) return true;
            if (number % 3 == 0) return false;

            long r = (long)Math.Floor(Math.Sqrt(number));
            long f = 5;

            while (f <= r)
            {
                if (number % f == 0) return false;
                if (number % (f + 2) == 0) return false;
                f += 6;
            }

            return true;
        }
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
        public static bool IsPalindrome(int numberInput)
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
    }
}
