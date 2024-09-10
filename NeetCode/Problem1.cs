using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode
{
    internal class Problem1
    {
        public bool Solve()
        {
            int[] testArray = [1,2,3,3];
            return SolutionOne(testArray);
        }
        private bool SolutionOne(int[] nums)
        {
            List<int> counted = new List<int>();

            foreach (int num in nums)
            {
                if (!counted.Contains(num))
                {
                    counted.Add(num);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
