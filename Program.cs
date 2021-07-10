using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace BenchMark_Testing
{
    public static class Program
    {
        public static void Main()
        {
            var config = new ManualConfig()
       .WithOptions(ConfigOptions.DisableOptimizationsValidator)
       .AddValidator(JitOptimizationsValidator.DontFailOnError)
       .AddLogger(ConsoleLogger.Default)
       .AddColumnProvider(DefaultColumnProviders.Instance);
            BenchmarkRunner.Run<Benchmarks>(config);
        }
    }

    [MemoryDiagnoser]
    public class Benchmarks
    {
        const int NumOfIterations = 1;

        [Benchmark]
        public int IList()
        {
            int sum = 0;
            IList<int> numbers = new List<int> { 0 };

            for (int i = 0; i < NumOfIterations; i++)
            {
                foreach (var number in numbers)
                {
                    sum += number;
                }
            }
            return sum;
        }

        [Benchmark]
        public int List()
        {
            int sum = 0;
            List<int> numbers = new List<int> { 0 };

            for (int i = 0; i < NumOfIterations; i++)
            {
                foreach (var number in numbers)
                {
                    sum += number;
                }
            }
            return sum;
        }
        [Benchmark]
        public int IEnumerable()
        {
            int sum = 0;
            IEnumerable<int> numbers = new List<int> { 0 };

            for (int i = 0; i < NumOfIterations; i++)
            {
                foreach (var number in numbers)
                {
                    sum += number;
                }
            }
            return sum;
        }
    }

}
