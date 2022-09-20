// See https://aka.ms/new-console-template for more information
using System;
using Euler.Problems;

namespace Euler // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem9();

            Console.WriteLine(problem.Solve().ToString());
        }
    }
}