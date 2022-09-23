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
using System.Threading;
using System.Threading.Tasks;
using Euler;

namespace Euler.Problems
{
    internal class Problem17
    {
        Dictionary<int, int> numberLengths = new Dictionary<int, int>() { { 1, 3 }, { 2, 3 }, { 3, 5 }, { 4, 4 }, { 5, 4 }, { 6, 3 }, { 7, 5 }, { 8, 5 }, { 9, 4 }, { 10, 3 },
                                                                          { 11, 6 }, { 12, 6 }, { 13, 8 }, { 14, 8 }, { 15, 7 }, { 16, 7 }, { 17, 9 }, { 18, 8 }, { 19, 8 }, { 20, 6 },
                                                                          { 30, 6 }, { 40, 5 }, { 50, 5 }, { 60, 5 }, { 70, 7 }, { 80, 6 }, { 90, 6 }, { 100, 7 }, { 1000, 8 }, { 0, 0 }};
        public long Solve()
        {
            //If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

            //If all the numbers from 1 to 1000(one thousand) inclusive were written out in words, how many letters would be used?

            //NOTE: Do not count spaces or hyphens. For example, 342(three hundred and forty - two) contains 23 letters and 115(one hundred and fifteen) contains 20 letters.The use of "and" when writing out numbers is in compliance with British usage.

            return SolutionOne(1000);
        }

        //Pseudocode

        // Consider just having numbers in a dictionary instead of the words. Case statement may also be smart
        // Consider having repeats saved in another dictionary
        // Go from left to right in the number
        // Thousand? Hundred? if so place the number then "hundred." Check for 0's to exclude the and
        // Check if its a teen number
        // If it's a teen then use the teen version
        // If not use the 10 and 1 digit version

        //Brute Force
        private long SolutionOne(int topNumber)
        {
            long sum = 0;
            for (int i = 0; i <= topNumber; i++)
            {
                string numbserString = i.ToString();
                int numberLength = numbserString.Length;
                for (int j = 0; j < numberLength; j++)
                {
                    int position = numberLength - j;
                    int currentDigit = Convert.ToInt32(numbserString[j].ToString());

                    if (position > 4)
                        throw new NotImplementedException("This code isnt ready for big numbers.");
                    else if (position == 4)
                        sum += numberLengths[currentDigit] + numberLengths[1000];
                    else if (position == 3)
                    {
                        if (currentDigit != 0)
                            sum += numberLengths[currentDigit] + numberLengths[100];

                        //Check for 0's
                        for (int k = j + 1; k < numberLength; k++)
                        {
                            if (numbserString[k] != '0')
                            {
                                sum += 3;
                                break;
                            }
                        }
                    }
                    else if (position == 2)
                    {
                        if (currentDigit == 1)
                        {
                            int teenNumber = Convert.ToInt32(numbserString.Substring(numberLength - 2));
                            sum += numberLengths[teenNumber];
                            j++;
                        }
                        else
                        {
                            sum += numberLengths[currentDigit*10];
                        }
                    }
                    else if (position == 1)
                        sum += numberLengths[currentDigit];
                }
            }

            return sum;
        }
    }
}