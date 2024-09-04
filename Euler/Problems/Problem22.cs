using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Euler;
using static System.Formats.Asn1.AsnWriter;

namespace Euler.Problems
{
    internal class Problem22
    {
        long largestSum = 0;

        public long Solve()
        {
            //Using names.txt(right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

            //For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.So, COLIN would obtain a score of 938 × 53 = 49714.

            //What is the total of all the name scores in the file ?

            return SolutionTwo();
        }

        //First try, brute force
        private long SolutionOne()
        {
            string[] rows = System.IO.File.ReadAllLines("./files/p067_triangle.txt");
            string[][] triangleArray = new string[rows.Length][];
            int count = 0;
            foreach (var row in rows)
            {
                triangleArray[count++] = row.Split(' ');
            }

            RecurseTriangle(triangleArray, 0, 0, 0);

            return largestSum;
        }

        //Second self made attempt
        private long SolutionTwo()
        {
            string[] rows = System.IO.File.ReadAllLines("./files/p067_triangle.txt");
            int triangleHeight = rows.Length;
            string[][] triangleArray = new string[triangleHeight][];
            int count = 0;
            foreach (var row in rows)
            {
                triangleArray[count++] = row.Split(' ');
            }

            for (int i = 1; i < triangleHeight; i++)
            {
                int triangleWidth = triangleArray[i].Length;
                for (int j = 0; j < triangleWidth; j++)
                {
                    if (j == 0)
                    {
                        triangleArray[i][j] = (Convert.ToInt32(triangleArray[i - 1][j]) + Convert.ToInt32(triangleArray[i][j])).ToString();
                    }
                    else if (j == triangleWidth - 1)
                    {
                        triangleArray[i][j] = (Convert.ToInt32(triangleArray[i - 1][j - 1]) + Convert.ToInt32(triangleArray[i][j])).ToString();
                    }
                    else
                    {
                        triangleArray[i][j] = Math.Max(Convert.ToInt32(triangleArray[i - 1][j]) + Convert.ToInt32(triangleArray[i][j]), Convert.ToInt32(triangleArray[i - 1][j - 1]) + Convert.ToInt32(triangleArray[i][j])).ToString();
                    }

                    if (i == triangleHeight - 1 && Convert.ToInt32(triangleArray[i][j]) > largestSum)
                    {
                        largestSum = Convert.ToInt32(triangleArray[i][j]);
                    }
                }
            }

            return largestSum;
        }

        private void RecurseTriangle(string[][] triangleArray, int row, int col, long sum)
        {
            sum += Convert.ToInt32(triangleArray[row][col]);
            if (row < triangleArray.Length - 1)
            {
                RecurseTriangle(triangleArray, row + 1, col, sum);
                RecurseTriangle(triangleArray, row + 1, col + 1, sum);
            }
            else if (sum > largestSum)
            {
                largestSum = sum;
            }
        }
    }
}