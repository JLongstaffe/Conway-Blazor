
using BenchmarkDotNet.Running;

namespace Conway.Benchmarks
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ConwayBenchmarks>();
        }
    }
}
