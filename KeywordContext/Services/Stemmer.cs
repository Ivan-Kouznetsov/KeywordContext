using Porter2Stemmer;

namespace KeywordContext.Services
{
    public class Stemmer : KeywordContext.Interfaces.IStemmer
    {
        private EnglishPorter2Stemmer EnglishStemmer { get; set; }

        public Stemmer()
        {
            EnglishStemmer = new EnglishPorter2Stemmer();
        }
        public string GetStem(string word)
        {
            return EnglishStemmer.Stem(word).Value;
        }

        public bool HasSameStem(string word1, string word2)
        {
            return EnglishStemmer.Stem(word1).Value == EnglishStemmer.Stem(word2).Value;
        }
    }
}
