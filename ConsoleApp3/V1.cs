using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class V1
    {
        //第1版原版
        public static string replaceTmeplate(string templateContent, Dictionary<string, string> paramValuePair)
        {
            int beginIndex;
            int endIndex;
            if (paramValuePair != null && !string.IsNullOrWhiteSpace(templateContent))
            {
                beginIndex = templateContent.IndexOf('$', 0);
                while (beginIndex != -1)
                {
                    endIndex = templateContent.IndexOf('$', beginIndex + 1);
                    var length = endIndex - beginIndex + 1;
                    string key = templateContent.Substring(beginIndex, length);
                    if (!paramValuePair.ContainsKey(key) || string.IsNullOrWhiteSpace(paramValuePair[key]))
                    {
                        templateContent = templateContent.Replace(templateContent.Substring(beginIndex, endIndex + 1), "");
                    }
                    else
                    {
                        var replacekey = templateContent.Substring(beginIndex, length);
                        templateContent = templateContent.Replace(replacekey, paramValuePair[key]);
                    }
                    beginIndex = templateContent.IndexOf('$', 0);
                }
            }
            else
            {
                return "";
            }
            return templateContent;
        }
    }
}
