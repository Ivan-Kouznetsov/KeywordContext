using System;
using System.Collections.Generic;
using System.Linq;

namespace KeywordContext.Services
{
    public static class Tokenizer
    {
        private static char[] Separators { get; set; }
        static Tokenizer()
        {
            Separators = Enumerable.Range(0, char.MaxValue + 1)
                                   .Select(i => (char)i)
                                   .Where(c => char.IsPunctuation(c) || char.IsSymbol(c) || char.IsSeparator(c) || Environment.NewLine.ToCharArray().Contains(c))
                                   .ToArray();
        }

        static bool IsKeywordStartIndex(char[] chars, int startIndex, string keyword)
        {
            if (keyword == null) return false;

            int endIndex = startIndex + keyword.Length-1;
            char[] keywordChars = keyword.ToCharArray();
          
            if (chars.Length > endIndex && (endIndex == chars.Length-1 || Separators.Contains(chars[endIndex + 1])))
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (chars[i] != keywordChars[i - startIndex])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        static string GetNextToken(char[] chars, int startIndex, out int endIndex)
        {
            List<char> tokenChars = new List<char>();
            int tokenStartIndex = -1;

            for (int i = startIndex; i < chars.Length; i++)
            {
                if (tokenStartIndex == -1 && !Separators.Contains(chars[i]))
                {
                    tokenStartIndex = i;
                }

                if (tokenStartIndex > -1 && (Separators.Contains(chars[i]) || i == chars.Length - 1))
                {
                    // return token
                    endIndex = i;
                    if (tokenChars.Count > 0)
                    {
                        if (!Separators.Contains(chars[i])) tokenChars.Add(chars[i]);
                        return new string(tokenChars.ToArray());
                    }
                    else {
                        return null;
                    }
                }
                else
                {
                    // add char to token
                    tokenChars.Add(chars[i]);
                }
            }

            endIndex = chars.Length - 1;
            return null;
        }

        public static List<string> GetTokens(string text, string keyword=null)
        {
            if (keyword!=null) keyword = keyword.ToLower();
            text = text.ToLower().Trim().Replace(Environment.NewLine," ");
            char[] chars = text.ToCharArray();
            List<string> tokens = new List<string>();
            bool keywordFound = false;
            
            // INDEX CHANGES FROM WITHIN LOOP
            for (int i = 0; i < chars.Length; i++)
            {
                if (!Separators.Contains(chars[i]))
                {
                    if (IsKeywordStartIndex(chars, i, keyword))
                    {
                        keywordFound = true;
                        tokens.Add(keyword);
                        i += keyword.Length;
                    }
                    else
                    {
                        tokens.Add(GetNextToken(chars, i, out i).Trim());
                    }
                }
            }
            var result = (keywordFound || keyword==null) ? tokens : new List<string>();
            return result; 
        }
    }
}
