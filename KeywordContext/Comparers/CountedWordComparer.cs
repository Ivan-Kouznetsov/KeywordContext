using KeywordContext.Models;
using System;
using System.Collections.Generic;

namespace KeywordContext.Comparers
{
    public class CountedWordComparer : IComparer<CountedWord>
    {
       int IComparer<CountedWord>.Compare(CountedWord x, CountedWord y)
        {
            if (x.Count > y.Count)
            {
                return -1;
            }

            if (x.Count == y.Count)
            {
                return 0;
            }

            if (x.Count < y.Count)
            {
                return 1;
            }

            throw new ArgumentException("Arguments are not counted words");
        }
    }
}
