using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class V4
    {
        //第4版
        //在V2版基础上，去掉replace  方法，用StringBuilder  来实现
        //StringBuilder 实现过程中有一点要注意。V2版本中，提取变量返回的是一个Set 集合。返回集合中出现变量的顺序和模板中变量顺序会不一致，模板中有多个相同变量的情况下，也只会替换第一个出现的变量。所以要将变量提取返回的结果换成有序可重复的List ，才能保证逻辑的正确性
        public static string replaceTmeplateV3(string templateContent, Dictionary<string, string> paramValuePair)
        {
            var stringBuilder = new StringBuilder();
            int startIndex = 0;
            var paramList = pickDynamicParamListV3(templateContent);
            foreach (var param in paramList)
            {
                if (paramValuePair.ContainsKey(param))
                {
                    string value = paramValuePair[param.Trim()];
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        //templateContent = templateContent.Replace(param, value);
                        int index = templateContent.IndexOf(param, startIndex);
                        stringBuilder.Append(templateContent, startIndex, index - startIndex);
                        stringBuilder.Append(value);
                        startIndex = index + param.Length;
                    }
                }
            }
            stringBuilder.Append(templateContent.Substring(startIndex));
            return stringBuilder.ToString();
        }

        static List<string> pickDynamicParamListV3(string templateContent)
        {
            List<string> result = new List<string>();
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
