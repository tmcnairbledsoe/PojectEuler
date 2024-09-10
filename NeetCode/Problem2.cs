using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode
{
    internal class Problem2
    {
        public bool Solve()
        {
            string s = "xx";
            string t = "x";
            return SolutionOne(s,t);
        }
        private bool SolutionOne(string s, string t)
        {
            if(s.Length > t.Length)
            {
                return false;
            }
            foreach (char character in s) 
            {
                int charIndex = t.IndexOf(character);
                if (charIndex != -1)
                {
                    t = t.Remove(charIndex,1);
                }
            }
            if (t.Length > 0) { 
                return false;
            }
            return true;
        }
    }
}
