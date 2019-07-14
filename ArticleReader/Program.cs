using System;
using System.Collections.Generic;
using System.IO;
using KeywordContext.Services;
using System.Linq;

namespace ArticleReader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string filepath = args[0];
                if (!File.Exists(filepath)) {
                    Console.WriteLine("File Not Found: " + filepath);                    
                    PressAnyKey();
                    return;
                }

                string text = File.ReadAllText(filepath);
                RunQuery(text);
            }
            else
            {
                Console.WriteLine("ArticleReader a demo of KeywordContext library");
                Console.WriteLine("Usage: ArticleReader myarticle.txt");

                if (File.Exists("sample_article.txt"))
                {
                    Console.WriteLine("Using default article");
                    RunQuery(File.ReadAllText("sample_article.txt"));
                }
            }

            PressAnyKey();
        }

        static void RunQuery(string text)
        {
           List<string> tokens = Tokenizer.GetTokens(text);
           PhraseParser phraseParser = new PhraseParser();

           phraseParser.JoinAllPhrases(ref tokens, 2, 2);

           Console.WriteLine("Phrases used in the article:");
           tokens = WordService.RemoveStopwordPhrases(tokens);

           foreach(string t in tokens.Where(s => s.Contains(" ")).OrderBy(s => s.Length).Reverse().Distinct())
           {
                Console.WriteLine(t);
           }
        }

        static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
