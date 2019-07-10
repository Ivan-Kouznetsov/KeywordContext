using System.Collections.Generic;

namespace KeywordContext.Models
{
    public class SentenceFragment
    {
        private readonly string displayString = string.Empty;

        public string Keyword { get; private set; }
        public Dictionary<string, string> NearByWords { get; private set; }

        // words need to be ordered here 
        public SentenceFragment(string keyword, List<Word> wordsBefore, List<Word> wordsAfter)
        {
            NearByWords = new Dictionary<string, string>();

            for (int i = 0; i < wordsBefore.Count; i++)
            {
                displayString += wordsBefore[i].FullWord + " ";
                if (!NearByWords.ContainsKey(wordsBefore[i].Stem))
                {
                    NearByWords.Add(wordsBefore[i].Stem, wordsBefore[i].FullWord);
                }
            }

            displayString += keyword;

            for (int i = 0; i < wordsAfter.Count; i++)
            {
                displayString += " " + wordsAfter[i].FullWord;
                if (!NearByWords.ContainsKey(wordsAfter[i].Stem))
                {
                    NearByWords.Add(wordsAfter[i].Stem, wordsAfter[i].FullWord);
                }
            }

            Keyword = keyword;
        }

        public override string ToString()
        {
            return displayString;
        }

        public bool ContainsStem(string stem)
        {
            return NearByWords.ContainsKey(stem);
        }

        public bool ContainsAnyStems(IEnumerable<Word> stems)
        {
            foreach (Word w in stems)
            {
                if (NearByWords.ContainsKey(w.Stem))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
