using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

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