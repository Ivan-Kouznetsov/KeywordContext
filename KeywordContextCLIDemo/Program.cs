using System;
using System.Collections.Generic;
using System.Linq;
using KeywordContext.Comparers;
using KeywordContext.DAO;
using KeywordContext.Models;
using KeywordContext.Services;

namespace KeywordContextCLIDemo
{
    class Program
    {
        const int SqlLimit = 1000;
        const int ResultLimit = 8;

        static (List<Word> Words, List<SentenceFragment> SentenceFragment) Query(string filepath, string keyword, DateTime start, DateTime end, int resultLimit)
        {
            List<string> textSegments = SqliteDAO.GetText(filepath,  start, end, keyword, SqlLimit);
            List<SentenceFragment> sentenceFragments = new List<SentenceFragment>();
            // settings
            const int MaxWordsAround = 5;

            List<Word> importantStems = new List<Word>();
            List<SentenceFragment> exampleFragments = new List<SentenceFragment>();
            WordSequenceParser wordSequenceParser = new WordSequenceParser(new Stemmer(), MaxWordsAround);

            foreach (string text in textSegments)
            {
                sentenceFragments.AddRange(wordSequenceParser.FindSentenceFragments(Tokenizer.GetTokens(text, keyword), keyword));
            }
            
            IEnumerable<CountedWord> countedStems = wordSequenceParser.CountWordOccurancesInSequences(sentenceFragments);
            importantStems = countedStems.Where(x => x.Count > 0 && !WordService.IsStopword(x.Word.FullWord) && x.Word.FullWord.Length>2)
                                                    .OrderBy(x => x, new CountedWordComparer())
                                                    .Select(x => x.Word)
                                                    .Take(resultLimit).ToList();

            exampleFragments = sentenceFragments.Where(s => s.ContainsAnyStems(importantStems))
                                                                       .Distinct(new SentenceFragmentEqualityComparer())
                                                                       .Take(resultLimit).ToList();

            return (importantStems, exampleFragments);
        }

        static void Main(string[] args)
        {
            const string sqlitefilepath = @"SampleData\uspto_archive_small_subset.sqlite";

            Console.WriteLine("KeyContext (C)2019 Ivan Kouznetsov");
            Console.WriteLine("Type .quit to exit");
            Console.WriteLine("Type a keyword to search for how it is used in context");
                    
            (List<Word> Words, List<SentenceFragment> SentenceFragment) results;

            string input = string.Empty;

            while (input != ".quit")
            {
                Console.Write("Search: ");
                input = Console.ReadLine();

                results = Query(sqlitefilepath, input, DateTime.MinValue, DateTime.MaxValue, ResultLimit);

                if (results.Words.Count > 0 && results.SentenceFragment.Count > 0)
                {
                    Console.WriteLine("Related words:");

                    for (int i = 0; i < results.Words.Count; i++)
                    {
                        Console.WriteLine("\t" + results.Words[i].FullWord);
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Usage examples:");
                    Console.WriteLine();

                    for (int i = 0; i < results.SentenceFragment.Count; i++)
                    {
                        Console.WriteLine("\"" + results.SentenceFragment[i] + "\"");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found. Note that the sample database included in this demo has only 80,000 records.");
                }

                Console.WriteLine();
            }

            PressAnyKey();
        }

        static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
