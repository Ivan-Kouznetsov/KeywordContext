using KeywordContext.Models;
using System.Collections.Generic;

namespace KeywordContext.Comparers
{
    public class SentenceFragmentEqualityComparer : IEqualityComparer<SentenceFragment>
    {
        bool IEqualityComparer<SentenceFragment>.Equals(SentenceFragment x, SentenceFragment y)
        {
            return x.ToString() == y.ToString();
        }

        int IEqualityComparer<SentenceFragment>.GetHashCode(SentenceFragment obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
