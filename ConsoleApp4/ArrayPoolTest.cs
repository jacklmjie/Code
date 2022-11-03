using BenchmarkDotNet.Attributes;
using System.Buffers;

namespace ConsoleApp4
{
    public class ArrayPoolTest
    {
        [Params(100, 1000)]
        public int ArraySize;

        [Benchmark]
        public void RegularArray()
        {
            int[] array = new int[ArraySize];
        }

        [Benchmark]
        public void SharedArrayPool()
        {
            var pool = ArrayPool<int>.Shared;
            int[] array = pool.Rent(ArraySize);
            pool.Return(array);
        }
    }
}
