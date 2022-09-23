using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    internal class Problem19
    {
        public long Solve()
        {
            //You are given the following information, but you may prefer to do some research for yourself.

            // - 1 Jan 1900 was a Monday.
            // - Thirty days has September,
            //April, June and November.
            //All the rest have thirty - one,
            //Saving February alone,
            //Which has twenty - eight, rain or shine.
            //And on leap years, twenty - nine.
            // - A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

            //How many Sundays fell on the first of the month during the twentieth century(1 Jan 1901 to 31 Dec 2000)?
            DateTime startDate = new DateTime(1901, 1, 1);
            DateTime endDate = new DateTime(2000, 12, 31);

            return SolutionOne(startDate, endDate);
        }

        //First try, brute force.
        private long SolutionOne(DateTime startDate, DateTime endDate)
        {
            int numOfSundays = 0;
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                if(currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    numOfSundays++;
                }
                currentDate = currentDate.AddMonths(1);
            }

            return numOfSundays;
        }

    }
}