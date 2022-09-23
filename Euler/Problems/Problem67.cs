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
    internal class Problem67
    {
        long largestSum = 0;

        public long Solve()
        {
            //By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

            //3
            //7 4
            //2 4 6
            //8 5 9 3

            //That is, 3 + 7 + 4 + 9 = 23.

            //Find the maximum total from top to bottom in triangle.txt(right click and 'Save Link/Target As...'), a 15K text file containing a triangle with one-hundred rows.

            //NOTE: This is a much more difficult version of Problem 18.It is not possible to try every route to solve this problem, as there are 299 altogether! If you could check one trillion(1012) routes every second it would take over twenty billion years to check them all. There is an efficient algorithm to solve it. ; o)

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