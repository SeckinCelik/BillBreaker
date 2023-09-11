using BenchmarkDotNet.Running;

namespace BillBreaker
{
    class Program
    {
        static void Main(string[] args)
        {
            var ways = getWays.getNumberOfWays(148, new long[] { 1, 5, 10, 25 });
            var bm = new BreakerBenchmark();
            var result = bm.getPossibleCoins();

            System.Console.WriteLine(bm.Print(result));

            System.Console.ReadKey();
            //var summary = BenchmarkRunner.Run<BreakerBenchmark>();
        }
    }
}
