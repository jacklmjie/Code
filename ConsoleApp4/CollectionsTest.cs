using BenchmarkDotNet.Attributes;

namespace ConsoleApp4
{
    public class CollectionsTest
    {
        [Params(100, 1000)]
        public int Size;

        [Benchmark]
        public void ListDynamicCapacity()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < Size; i++)
            {
                list.Add(i);
            }
        }
        [Benchmark]
        public void ListPlannedCapacity()
        {
            List<int> list = new List<int>(Size);
            for (int i = 0; i < Size; i++)
            {
                list.Add(i);
            }
        }
    }
}
