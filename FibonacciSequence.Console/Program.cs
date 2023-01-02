using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace FibonacciSequence.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<FibonacciGenerator>();
            System.Console.ReadLine();
        }
    }
}