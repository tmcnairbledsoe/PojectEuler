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
    internal class Problem15
    {
        long paths = 0;
        int currentX = 0;
        int currentY = 0;
        int dimensions = 1;

        public long Solve()
        {
            //Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

            //How many such routes are there through a 20×20 grid ?

            //Answer : 137846528820

            return SolutionFour(20, 20);
        }

        //Recursive Brute Force: 41m
        private long SolutionOne(int gridDimensions)
        {
            dimensions = gridDimensions;
            Traverse();
            return paths;
        }

        //Self found method, only works for a square grid.
        private long SolutionTwo(int gridDimensions)
        {
            long currentNumOfPaths = 6;

            for (double i = 2; i < gridDimensions; i++)
            {
                currentNumOfPaths = (long)(currentNumOfPaths * (3 + ((i - 1) / (i + 1))));
            }

            return currentNumOfPaths;
        }

        //Euler's method
        private long SolutionThree(int gridDimensions)
        {
            long currentNumOfPaths = 1;

            for (double i = 2; i < gridDimensions; i++)
            {
                currentNumOfPaths = (long)((currentNumOfPaths + i) / i);
            }

            return currentNumOfPaths;
        }

        //Combinations without repetition formula for a rectangular grid of x by y
        private long SolutionFour(int x, int y)
        {
            return (long)(Helpers.Factorial(x+y) / (Helpers.Factorial(x) * Helpers.Factorial(y)));
        }

        public void Traverse()
        {
            if (currentX == dimensions && currentY == dimensions)
            {
                paths++;
            }
            else
            {
                if (currentX != dimensions)
                {
                    currentX++;
                    Traverse();
                    currentX--;
                }
                if (currentY != dimensions)
                {
                    currentY++;
                    Traverse();
                    currentY--;
                }
            }
        }
    }
}