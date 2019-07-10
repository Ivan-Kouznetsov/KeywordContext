namespace KeywordContext.Interfaces
{
    public interface IStemmer
    {
        string GetStem(string word);
        bool HasSameStem(string word1, string word2);
    }
}
