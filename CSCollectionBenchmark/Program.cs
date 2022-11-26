using BenchmarkDotNet.Running;

namespace CSCollectionBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<YieldIEnumerableBenchmark>();
        }
    }
}