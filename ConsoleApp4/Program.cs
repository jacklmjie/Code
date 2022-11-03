// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ConsoleApp4;

Console.WriteLine("Hello, World!");

//五个 .NET 性能小贴士
//文档地址 https://mp.weixin.qq.com/s/dSnay8Xvj0Bl5XKjn5VI1g
//1.用 StringBuilder 拼接字符串
//var summary = BenchmarkRunner.Run<StringBuilderTest>();
//2.赋予动态集合初始大小
//var summary2 = BenchmarkRunner.Run<CollectionsTest>();
//3.ArrayPool 用于短时大数组
var summary3 = BenchmarkRunner.Run<ArrayPoolTest>();
//4.结构代替类
//var summary4 = BenchmarkRunner.Run<VectorTest>();
//5.ConcurrentQueue代替 ConcurrentBag
//var summary5 = BenchmarkRunner.Run<ConcurrentTest>();
Console.ReadLine();