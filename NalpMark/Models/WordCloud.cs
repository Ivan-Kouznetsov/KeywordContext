using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NalpMark.Models
{
    public class WordCloud
    {
        private Dictionary<string, int> countedWords = new Dictionary<string, int>();
       
        public bool AddWord(string word, int count)
        {
            if (countedWords.ContainsKey(word)) return false;

            countedWords.Add(word, count);
            return true;
        }

        public Dictionary<string, int> ToDictionary()
        {
            return countedWords;
        }


    }
}
