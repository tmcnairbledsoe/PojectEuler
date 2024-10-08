﻿using System;
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
    internal class Problem18
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

            //Find the maximum total from top to bottom of the triangle below:

            //75
            //95 64
            //17 47 82
            //18 35 87 10
            //20 04 82 47 65
            //19 01 23 75 03 34
            //88 02 77 73 07 63 67
            //99 65 04 28 06 16 70 92
            //41 41 26 56 83 40 80 70 33
            //41 48 72 33 47 32 37 16 94 29
            //53 71 44 65 25 43 91 52 97 51 14
            //70 11 33 28 77 73 17 78 39 68 17 57
            //91 71 52 38 17 14 91 43 58 50 27 29 48
            //63 66 04 68 89 53 67 30 73 16 69 87 40 31
            //04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

            //NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route.However, Problem 67,
            //is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method!; o)


            string smallTriangle = "3\r\n7 4\r\n2 4 6\r\n8 5 9 3";
            string triangle = "75\r\n95 64\r\n17 47 82\r\n18 35 87 10\r\n20 04 82 47 65\r\n19 01 23 75 03 34\r\n88 02 77 73 07 63 67\r\n99 65 04 28 06 16 70 92\r\n41 41 26 56 83 40 80 70 33\r\n41 48 72 33 47 32 37 16 94 29\r\n53 71 44 65 25 43 91 52 97 51 14\r\n70 11 33 28 77 73 17 78 39 68 17 57\r\n91 71 52 38 17 14 91 43 58 50 27 29 48\r\n63 66 04 68 89 53 67 30 73 16 69 87 40 31\r\n04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";


            return SolutionTwo(triangle);
        }

        //First try, brute force
        private long SolutionOne(string triangleString)
        {
            var rows = triangleString.Split("\r\n");
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
        private long SolutionTwo(string triangleString)
        {
            var rows = triangleString.Split("\r\n");
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