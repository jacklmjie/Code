using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class V2
    {
        //第2版
        //利用双指针把模板里面所有变量都提取出来，再对变量集合进行循环，依次替换掉模板内容里面的变量
        public static string replaceTmeplateV2(string templateContent, Dictionary<string, string> paramValuePair)
        {
            var paramSet = pickDynamicParamSetV2(templateContent);
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

        static HashSet<string> pickDynamicParamSetV2(string templateContent)
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
