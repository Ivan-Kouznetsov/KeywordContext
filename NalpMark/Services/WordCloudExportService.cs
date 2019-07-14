using System;
using System.Collections.Generic;
using System.Linq;
using NalpMark.Models;
using System.IO;

namespace NalpMark.Services
{
    public static class WordCloudExportService
    {
        const int FontFactor = 40;
        const int MinFont = 20;

        public static void Show(WordCloud wordCloud, string keyword)
        {
            File.WriteAllText("WordClouds" + Path.DirectorySeparatorChar + "currentData.js",
                              "var WordCloud = {keyword:\""+keyword+"\", words:"  
                              + CreateWordCloud2JsArray(wordCloud.ToDictionary()) + "};");

            BrowserService.OpenBrowser("WordClouds" + Path.DirectorySeparatorChar + "WordCloud.html");
        }
        
        private static string CreateWordCloud2JsArray(Dictionary<string, int> dictionary)
        {
            List<int> counts = new List<int>();
            foreach (KeyValuePair<string, int> keyValue in dictionary)
            {
                counts.Add(keyValue.Value);
            }

            List<string> pairs = new List<string>();
            foreach (KeyValuePair<string, int> keyValue in dictionary)
            {
                pairs.Add("{text:\"" + keyValue.Key + "\",fontSize:" + (MinFont + FontFactor * Normalize(keyValue.Value, counts)) + "}");
            }

            return "[" + String.Join(',', pairs) + "]";
        }

        private static float Normalize(int value, IEnumerable<int> nums)
        {
            return ((float)value - nums.Min()) / (nums.Max() - nums.Min());
        }
    }
}
