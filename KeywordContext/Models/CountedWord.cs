namespace KeywordContext.Models
{
    public class CountedWord
    {
        public Word Word { get; private set; }
        public int Count { get; private set; }
        public CountedWord(Word word, int count)
        {
            Word = word;
            Count = count;
        }
    }
}
