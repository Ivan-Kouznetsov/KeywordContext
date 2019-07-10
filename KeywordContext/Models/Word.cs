namespace KeywordContext.Models
{
    public class Word
    {
        public string FullWord { get; private set; }
        public string Stem { get; private set; }

        public Word(string fullWord, string stem)
        {
            FullWord = fullWord;
            Stem = stem;
        }
    }
}
