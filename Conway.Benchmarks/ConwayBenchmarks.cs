
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
            ConwayPerformance.NextState(InitialGridMulti);
        }

        private static readonly ConwayPerformance ConwayPerformance =
            new ConwayPerformance(200, 200);

        private static readonly bool[,] InitialGridMulti = RandomGridMulti(200);

        private static readonly bool[][] InitialGrid = RandomGrid(200);

        private static bool[,] RandomGridMulti(int size)
        {
            static bool RandomBool() => new Random().Next(0, 2) == 1;

            var grid = new bool[size, size];

            for (var i = 0; i < grid.GetLength(0); i++)
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = RandomBool();
            }

            return grid;
        }

        private static bool[][] RandomGrid(int size)
        {
            static bool RandomBool() => new Random().Next(0, 2) == 1;

            return Enumerable.Range(0, size)
                .Select(_ => Enumerable.Range(0, size)
                    .Select(_ => RandomBool())
                    .ToArray()).ToArray();
        }
    }
}
