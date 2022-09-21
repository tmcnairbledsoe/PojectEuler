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

            return SolutionOne(20);
        }

        //Recursive Brute Force: 41m
        private long SolutionOne(int gridDimensions)
        {
            dimensions = gridDimensions;
            Traverse();
            return paths;
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