using System;
using System.Collections.Generic;
using KeywordContext.Comparers;
using KeywordContext.Models;
using KeywordContext.Services;
using System.Linq;
using System.Diagnostics;

namespace NalpMark.Services
{
    public static class  SearchService
    {
        public static (List<CountedWord> ImportantWords, List<SentenceFragment> ExampleFragments)   Search(string DatabaseFilepath,
                                                                                                    DateTime from,
                                                                                                    DateTime to,
                                                                                                    List<int> classes,
                                                                                                    string keyword,
                                                                                                    int selectLimit, 
                                                                                                    bool useFilingDate,
                                                                                                    int maxWordsAround,
                                                                                                    int resultsLimit)
        {            
            List<CountedWord> importantWords = new List<CountedWord>();
            List<SentenceFragment> exampleFragments = new List<SentenceFragment>();

            string text = DAO.GetText(DatabaseFilepath, from, to, classes, keyword, selectLimit, useFilingDate);

            if (text.Length > 0)
            {
                WordSequenceParser wordSequenceParser = new WordSequenceParser(new Stemmer(), maxWordsAround);                             
                var words = Tokenizer.GetTokens(text, keyword);
                PhraseParser phraseParser = new PhraseParser();
                phraseParser.JoinAllPhrases(ref words,2,1);            

                List<SentenceFragment> sentenceFragments = wordSequenceParser.FindSentenceFragments(new List<string>(words), keyword);
                IEnumerable<CountedWord> countedStems = wordSequenceParser.CountWordOccurancesInSequences(sentenceFragments);

                importantWords = countedStems.Where(x => x.Count > 0 && !WordService.IsStopword(x.Word.FullWord) && x.Word.FullWord.Length > 2)
                                             .OrderBy(x => x, new CountedWordComparer())                                                            
                                             .Take(resultsLimit).ToList();

                exampleFragments = sentenceFragments.Where(s => s.ContainsAnyStems(importantWords.Select(w => w.Word)))
                                                    .Distinct(new SentenceFragmentEqualityComparer())
                                                    .Take(resultsLimit).ToList();
            }

            return (importantWords, exampleFragments);            
        }
    }
}
