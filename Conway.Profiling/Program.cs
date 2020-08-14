
using System;

using JetBrains.Profiler.Api;

namespace Conway.Profiling
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialGrid = RandomGridMulti(100);

            var conway = new Core.ConwayPerformance(100, 100);

            MemoryProfiler.CollectAllocations(true);

            MemoryProfiler.GetSnapshot();

            for (var i = 0; i < 100; i++)
            {
                conway.NextState(initialGrid);
            }

            MemoryProfiler.GetSnapshot();
        }

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
    }
}
