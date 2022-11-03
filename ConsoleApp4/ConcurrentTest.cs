using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;

namespace ConsoleApp4
{
    internal class ConcurrentTest
    {
        private static int Size = 1000;

        [Benchmark]
        public void Bag()
        {
            ConcurrentBag<int> bag = new();
            for (int i = 0; i < Size; i++)
            {
                bag.Add(i);
            }
        }

        [Benchmark]
        public void Queue()
        {
            ConcurrentQueue<int> bag = new();
            for (int i = 0; i < Size; i++)
            {
                bag.Enqueue(i);
            }
        }
    }
}
