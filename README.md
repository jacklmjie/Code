# Code

# ConsoleApp3 字符串替换优化
```
文档地址 https://mp.weixin.qq.com/s/MAszOfaRMinhTbLFmxDacQ
v1版本是原版本
v2版本是减少indexOf 和substring 操作，利用双指针把模板里面所有变量都提取出来
v3版本在v2版本基础上加上本地缓存
v4版本在v2版本基础上去掉replace  方法，用StringBuilder  来实现(这个是最耗时的)
v5版本在v4版本基础上加上本地缓存
```

# ConsoleApp4 五个 .NET 性能小贴士
```
文档地址 https://mp.weixin.qq.com/s/dSnay8Xvj0Bl5XKjn5VI1g
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
```