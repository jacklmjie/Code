using ConsoleApp3;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");
var dict = new Dictionary<string, string>
{
    {"$A$","大吉大利" },
    {"$B$","100"}
};
var template = "红包名称:$A$,红包金额:$B$";
var v1 = V1.replaceTmeplate(template, dict);
Console.WriteLine(v1);

var v2 = V2.replaceTmeplateV2(template, dict);
Console.WriteLine(v2);

var provider = new ServiceCollection().AddMemoryCache().BuildServiceProvider();
var memoryCache = provider.GetService<IMemoryCache>();

var v3 = new V3(memoryCache).replaceTmeplateV3(template, dict);
Console.WriteLine(v3);
var v3Cache = new V3(memoryCache).replaceTmeplateV3(template, dict);
Console.WriteLine(v3Cache);

var v4 = V4.replaceTmeplateV3(template, dict);
Console.WriteLine(v4);

//文档地址 https://mp.weixin.qq.com/s/MAszOfaRMinhTbLFmxDacQ
//v1版本是原版本
//v2版本是减少indexOf 和substring 操作，利用双指针把模板里面所有变量都提取出来
//v3版本在v2版本基础上加上本地缓存
//v4版本在v2版本基础上去掉replace  方法，用StringBuilder  来实现(这个是最耗时的)
//v5版本在v4版本基础上加上本地缓存
Console.ReadLine();