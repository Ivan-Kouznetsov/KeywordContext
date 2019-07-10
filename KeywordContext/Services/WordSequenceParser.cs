using KeywordContext.Comparers;
using KeywordContext.Interfaces;
using KeywordContext.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeywordContext.Services
{
    public class WordSequenceParser
    {
        private static IStemmer Stemmer { get; set; }
        private int MaxWordsAround { get; set; }

        public WordSequenceParser(IStemmer stemmer, int maxWordsAround)
        {
            Stemmer = stemmer;
            MaxWordsAround = maxWordsAround;
        }

        public List<SentenceFragment> FindSentenceFragments(List<string> orderedList, string keyword)
        {
            List<SentenceFragment> wordSequences = new List<SentenceFragment>();

            for (int i = 0; i < orderedList.Count; i++)
            {
                if (Stemmer.HasSameStem(keyword, orderedList[i]))
                {
                    // Before and after need to check bounds

                    int earliestIndex = Math.Max(0, i - MaxWordsAround);
                    int latestIndex = Math.Min(orderedList.Count - 1, i + MaxWordsAround);

                    List<Word> wordsBefore = new List<Word>();
                    List<Word> wordsAfter = new List<Word>();

                    for (int e = earliestIndex; e < i; e++)
                    {
                        wordsBefore.Add(new Word(orderedList[e], Stemmer.GetStem(orderedList[e])));
                    }

                    for (int l = i + 1; l <= latestIndex; l++)
                    {
                        wordsAfter.Add(new Word(orderedList[l], Stemmer.GetStem(orderedList[l])));
                    }

                    wordSequences.Add(new SentenceFragment(keyword, wordsBefore, wordsAfter));
                }
            }
            return wordSequences;
        }

        public IEnumerable<Word> GetAllWords(IEnumerable<SentenceFragment> fragments)
        {
            List<Word> words = new List<Word>();

            foreach (SentenceFragment fragment in fragments)
            {
                foreach (KeyValuePair<string, string> keyValue in fragment.NearByWords)
                {
                    words.Add(new Word(keyValue.Value, keyValue.Key));
                }
            }

            return words.Distinct();
        }

        public int CountStemOccurance(string stem, IEnumerable<SentenceFragment> fragments)
        {
            int count = 0;

            foreach (SentenceFragment fragment in fragments)
            {
                if (fragment.ContainsStem(stem))
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Takes SentenceFragments returns Words with a count of how often they occur in other SentenceFragments
        /// </summary>
        /// <param name="fragments">All of the SentenceFragments for the search being done</param>
        /// <returns>Words with a count of how often they occur in other SentenceFragments</returns>
        public IEnumerable<CountedWord> CountWordOccurancesInSequences(IEnumerable<SentenceFragment> fragments)
        {
            if (fragments.Count() == 0) return new List<CountedWord>();

            string keywordStem = Stemmer.GetStem(fragments.First().Keyword);
            ConcurrentBag<CountedWord> countedWords = new ConcurrentBag<CountedWord>();
            ConcurrentBag<Word> unFilteredWords = new ConcurrentBag<Word>(GetAllWords(fragments).Where(s => s.Stem != keywordStem));
            ConcurrentBag<Word> words = new ConcurrentBag<Word>();

            foreach (Word word in unFilteredWords)
            {
                if (words.FirstOrDefault(w => w.Stem == word.Stem) == null && !WordService.IsStopword(word.Stem))
                {
                    words.Add(word);
                }
            }

            Parallel.ForEach(words,
                new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                word =>
                {
                    countedWords.Add(new CountedWord(word, CountStemOccurance(word.Stem, fragments) - 1)); // subtract one for match with itself
                }
            );

            List<CountedWord> sortableCountedWords = new List<CountedWord>(countedWords);

            sortableCountedWords.Sort(new CountedWordComparer());
            return sortableCountedWords;
        }
    }
}
