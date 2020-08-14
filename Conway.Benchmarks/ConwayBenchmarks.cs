
using System;
using System.Linq;

using BenchmarkDotNet.Attributes;

using Conway.Core;

namespace Conway.Benchmarks
{
    [MemoryDiagnoser]
    public class ConwayBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void NextState()
        {
            Core.Conway.NextState(InitialGrid);
        }

        [Benchmark]
        public void PerformanceNextState()
        {
            ConwayPerformance.NextState(InitialGrid);
        }

        private static readonly bool[][] InitialGrid = RandomGrid(100);

        private static bool[][] RandomGrid(int size)
        {
            static bool RandomBool() => new Random().Next(0, 2) == 1;

            return Enumerable.Range(0, size)
                  .Select(_ => Enumerable.Range(0, size)
                              .Select(_ => RandomBool()).ToArray())
                  .ToArray();
        }
    }
}
