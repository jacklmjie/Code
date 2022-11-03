# Code

# ConsoleApp3 字符串替换优化
```
- 文档地址 https://mp.weixin.qq.com/s/MAszOfaRMinhTbLFmxDacQ
- v1版本是原版本
- v2版本是减少indexOf 和substring 操作，利用双指针把模板里面所有变量都提取出来
- v3版本在v2版本基础上加上本地缓存
- v4版本在v2版本基础上去掉replace  方法，用StringBuilder  来实现(这个是最耗时的)
- v5版本在v4版本基础上加上本地缓存
```