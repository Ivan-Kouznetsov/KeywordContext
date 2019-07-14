using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using KeywordContext.Comparers;
using KeywordContext.Interfaces;
using KeywordContext.Models;
using KeywordContext.Services;

namespace KeywordContextTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetTokens()
        {
            const string jews = "Association services, namely, promoting the interests of local, national and international Jewish communities, namely, Jewish chaplains, Jews in the armed forces and military veterans; Charitable services, namely, providing assistance, food, spiritual guidance and training to Jews in the armed forces and military veterans";
            const string jewsharps = "Percussion instruments and accessories, namely, taborins, bass drums, drumsticks for drums, drumsticks for tabor drums used by children, jews harps, bongo drums, rattles, nylon reeds for woodwind mouthpieces, tambourines, drumheads, straps for guitars, straps for saxophones; percussion instrument producing grunting sounds, namely, cuica";
            const string jewelry = "Brooches; Earrings; Jewellery; Jewellery findings; jet Jewellery cases; Pearls; Bracelets; Cultured pearls; Necklaces; Rings";

            IEnumerable<string> jewsTokens = Tokenizer.GetTokens(jews, "jews");
            IEnumerable<string> jewsharpsTokens = Tokenizer.GetTokens(jewsharps, "jews harps");
            IEnumerable<string> jewsharpsTokensSwitched = Tokenizer.GetTokens(jews, "jews harps");
            IEnumerable<string> jewelryTokens = Tokenizer.GetTokens(jewelry, "jew");

            Assert.AreEqual(43, jewsTokens.Count());
            Assert.AreEqual(42, jewsharpsTokens.Count());
            Assert.AreEqual(0, jewsharpsTokensSwitched.Count());
            Assert.AreEqual(0, jewelryTokens.Count());
        }

        [TestMethod]
        public void FindSentenceFragments()
        {
            const string jews = "Association services, namely, promoting the interests of local, national and international Jewish communities, namely, Jewish chaplains, Jews in the armed forces and military veterans; Charitable services, namely, providing assistance, food, spiritual guidance and training to Jews in the armed forces and military veterans";
            IEnumerable<string> jewsTokens = Tokenizer.GetTokens(jews, "jews");

            WordSequenceParser wordSequenceParser = new WordSequenceParser(new Stemmer(), 5);
            List<SentenceFragment> sentenceFragments = wordSequenceParser.FindSentenceFragments(new List<string>(jewsTokens), "jews");

            Assert.AreEqual(2,sentenceFragments.Count);
        }

        [TestMethod]
        public void CountWordOccurancesInSequences()
        {
            WordSequenceParser wordSequenceParser = new WordSequenceParser(new Stemmer(), 5);

            List<Word> wordList = new List<Word>();
            wordList.Add(new Word("cats", "cat"));
            wordList.Add(new Word("puppies", "puppy"));
            wordList.Add(new Word("pie", "pie"));
            wordList.Add(new Word("women", "woman"));
            wordList.Add(new Word("feet", "foot"));
           
            List<SentenceFragment> sentenceFragments = new List<SentenceFragment>();
            sentenceFragments.Add(new SentenceFragment("keyword", wordList, wordList));
            sentenceFragments.Add(new SentenceFragment("keyword", wordList, wordList));
            sentenceFragments.Add(new SentenceFragment("keyword", wordList, wordList));
            sentenceFragments.Add(new SentenceFragment("keyword", wordList, wordList));
            sentenceFragments.Add(new SentenceFragment("keyword", wordList, wordList));

            IEnumerable<CountedWord> countedStems = wordSequenceParser.CountWordOccurancesInSequences(sentenceFragments);

            foreach (CountedWord countedWord in countedStems)
            {
                Assert.AreEqual(4, countedWord.Count);
            }            
        }
      
        [TestMethod]
        public void JoinPhrasesZero()
        {
            PhraseParser phraseParser = new PhraseParser();
            string text = File.ReadAllText("TestData" + Path.DirectorySeparatorChar + "GoodsAndServicesSample.txt");
            List<string> tokens = Tokenizer.GetTokens(text, "games");

            phraseParser.JoinAllPhrases(ref tokens, 5, 10);


            Assert.AreEqual(0, tokens.Count);
        }

        [TestMethod]
        public void JoinPhrasesNone()
        {
            PhraseParser phraseParser = new PhraseParser();

            string text = File.ReadAllText("TestData" + Path.DirectorySeparatorChar + "GoodsAndServicesSample.txt");
            List<string> tokens = Tokenizer.GetTokens(text, "qwertyuiop[]");
            int firstCount = tokens.Count;

            phraseParser.JoinAllPhrases(ref tokens, 5, 10);


            Assert.AreEqual(firstCount, tokens.Count);
        }


        [TestMethod]
        public void JoinPhrasesLowThreshold()
        {
            PhraseParser phraseParser = new PhraseParser();
            string text = File.ReadAllText("TestData" + Path.DirectorySeparatorChar + "GoodsAndServicesSample.txt");
            List<string> tokens = Tokenizer.GetTokens(text, "cat");

            phraseParser.JoinAllPhrases(ref tokens, 1, 1);


            Assert.IsNotNull(tokens);
        }

       
        [TestMethod]
        public void OnePairAtTheEnd()
        {
            PhraseParser phraseParser = new PhraseParser();
            string text = "Cat scratching pads; Coatstands; Costume stands; Deck chairs; Display boards; Display stands;scratching pads Filing cabinets; Furniture; Furniture, namely, showcases; scratching pads Inflatable furniture; Kennels for household pets; Magazine racks; Nesting boxes for household pets; Office furniture; scratching pads Pet cushions; Scratching posts for cats; Screens; Storage racks; Jewellery organizer displays; Non-metal trestles for supporting tables;scratching pads Shelving and component parts thereof, namely, shelves and brackets sold as a unit scratching pads";

            List<string> tokens = Tokenizer.GetTokens(text, "cats");

            phraseParser.JoinPhrases(ref tokens, 2, 2);

            Assert.AreEqual("scratching pads",tokens.Last());
        }


        [TestMethod]
        public void LastChar()
        {
            string text = "Cat scratching pads";

            List<string> tokens = Tokenizer.GetTokens(text, "cat");
                       
            Assert.AreEqual("pads", tokens.Last());
        }


        [TestMethod]
        public void OnePairAtTheStart()
        {
            PhraseParser phraseParser = new PhraseParser();
            string text = "scratching pads for Cats Coatstands; Costume stands; Deck chairs; Display boards; Display stands;scratching pads Filing cabinets; Furniture; Furniture, namely, showcases; scratching pads Inflatable furniture; Kennels for household pets; Magazine racks; Nesting boxes for household pets; Office furniture; scratching pads Pet cushions; Scratching posts for cats; Screens; Storage racks; Jewellery organizer displays; Non-metal trestles for supporting tables;scratching pads Shelving and component parts thereof, namely, shelves and brackets sold as a unit scratching pads";

            List<string> tokens = Tokenizer.GetTokens(text, "cats");

            phraseParser.JoinPhrases(ref tokens, 2, 2);


            Assert.AreEqual("scratching pads", tokens.First());
        }

    }
}
