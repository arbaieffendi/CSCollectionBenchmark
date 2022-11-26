using BenchmarkDotNet.Attributes;

namespace CSCollectionBenchmark
{
    [MemoryDiagnoser]
    public class YieldIEnumerableBenchmark
    {
        readonly int total = 1_000;
        readonly int totalLarge = 1_000_000;

        [Benchmark]
        public void PrintFruit()
        {
            Console.WriteLine("Using GetFruit");
            foreach (var fruit in GetFruit(total))
            {
                Console.WriteLine(fruit);
            }
        }
        
        [Benchmark]
        public void PrintFruitYield()
        {
            Console.WriteLine("Using GetFruitYield");
            foreach (var fruit in GetFruitYield(total))
            {
                Console.WriteLine(fruit);
            }
        }

        [Benchmark]
        public void PrintFruitLarge()
        {
            int i = 0;
            Console.WriteLine("Using GetFruit");
            foreach (var fruit in GetFruit(totalLarge))
            {
                if (i > 1_000)
                {
                    break;
                }
                Console.WriteLine(fruit);
                i++;
            }
        }

        [Benchmark]
        public void PrintFruitYieldLarge()
        {
            int i = 0;
            Console.WriteLine("Using GetFruitYield");
            foreach (var fruit in GetFruitYield(totalLarge))
            {
                if (i > 1_000)
                {
                    break;
                }
                Console.WriteLine(fruit);
                i++;
            }
        }

        public static IEnumerable<string> GetFruit(int total)
        {
            List<string> fruits = new();
            for (int i = 0; i < total; i++)
            {
                fruits.Add("Fruit " + i);
            }
            return fruits;
        }

        public static IEnumerable<string> GetFruitYield(int total)
        {
            for (int i = 0; i < total; i++)
            {
                yield return "Fruit " + i;
            }
        }
    }
}
