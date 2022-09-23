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
    internal class Problem16
    {
        public long Solve()
        {
            //2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

            //What is the sum of the digits of the number 2^1000 ?

            return SolutionOne(1000);
        }

        //First try
        private long SolutionOne(int theExponent)
        {
            string theProduct = "1";
            int theBase = 2;
            long sum = 0;

            for (int i = 1; i <= theExponent; i++)
            {
                int carryover = 0;
                string newProduct = "";
                for (int j = theProduct.Length - 1; j >= 0; j--)
                {
                    int product = (Convert.ToInt32(theProduct[j].ToString()) * theBase) + carryover;
                    if (j != 0)
                    {
                        newProduct = String.Concat(product.ToString()[product.ToString().Length - 1], newProduct);
                    }
                    else
                    {
                        newProduct = String.Concat(product.ToString(), newProduct);
                    }
                    carryover = product / 10;
                }
                theProduct = newProduct;
            }

            foreach (char character in theProduct)
            {
                sum += Convert.ToInt64(character.ToString());
            }

            return sum;
        }

        private long SolutionTwo(int theExponent)
        {
            //TODO: Find a way to do it quicker
            //I can do this in base 2... the 1000th bit. But how do i turn that into base 10 string?
            return 0;
        }
    }
}