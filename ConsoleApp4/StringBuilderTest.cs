using BenchmarkDotNet.Attributes;
using System.Text;

namespace ConsoleApp4
{
    public class StringBuilderTest
    {
        private static StringBuilder sb = new();

        [Benchmark]
        public void Concat3() => ExecuteConcat(3);
        [Benchmark]
        public void Concat5() => ExecuteConcat(5);
        [Benchmark]
        public void Concat10() => ExecuteConcat(10);
        //[Benchmark]
        //public void Concat100() => ExecuteConcat(100);
        //[Benchmark]
        //public void Concat1000() => ExecuteConcat(1000);

        [Benchmark]
        public void Builder3() => ExecuteBuilder(3);
        [Benchmark]
        public void Builder5() => ExecuteBuilder(5);
        [Benchmark]
        public void Builder10() => ExecuteBuilder(10);
        //[Benchmark]
        //public void Builder100() => ExecuteBuilder(100);
        //[Benchmark]
        //public void Builder1000() => ExecuteBuilder(1000);

        public void ExecuteConcat(int size)
        {
            string s = "";
            for (int i = 0; i < size; i++)
            {
                s += "a";
            }
        }

        public void ExecuteBuilder(int size)
        {
            sb.Clear();
            for (int i = 0; i < size; i++)
            {
                sb.Append("a");
            }
        }
    }
}
