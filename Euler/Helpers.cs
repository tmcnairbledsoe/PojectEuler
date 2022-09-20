using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    static class Helpers
    {
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
        public static bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (long)Math.Floor(Math.Sqrt(number));

            for (long i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

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
    }
}
