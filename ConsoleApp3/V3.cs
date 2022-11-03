using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class V3
    {
        private readonly IMemoryCache _memoryCache;
        public V3(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        //第3版
        //利用双指针把模板里面所有变量都提取出来，再对变量集合进行循环，依次替换掉模板内容里面的变量
        //在v2的基础上加上本地缓存
        public string replaceTmeplateV3(string templateContent, Dictionary<string, string> paramValuePair)
        {
            var hashCode = templateContent.GetHashCode();
            HashSet<string> paramSet;
            if (!_memoryCache.TryGetValue(hashCode, out paramSet))
            {
                paramSet = pickDynamicParamSetV3(templateContent);
                _memoryCache.Set(hashCode, paramSet, new TimeSpan(20, 0, 0));
            }
            foreach (var param in paramSet)
            {
                if (paramValuePair.ContainsKey(param))
                {
                    string value = paramValuePair[param.Trim()];
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        templateContent = templateContent.Replace(param, value);
                    }
                }
            }
            return templateContent;
        }

        HashSet<string> pickDynamicParamSetV3(string templateContent)
        {
            var result = new HashSet<string>();
            int startIndex = 0;
            int endIndex = 0;
            bool entryDynamic = false;
            char[] chars = templateContent.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if ('$' != chars[i])
                {
                    continue;
                }
                if (!entryDynamic)
                {
                    startIndex = i;
                    entryDynamic = true;
                }
                else
                {
                    endIndex = i;
                    entryDynamic = false;
                }
                if (!entryDynamic)
                {
                    var parms = string.Join("", chars.Take(startIndex..(endIndex + 1)));
                    result.Add(parms);
                }
            }
            return result;
        }
    }
}
