using System;
using System.Collections.Generic;
using System.Text;

namespace KeywordContext.Services
{
    public class PhraseParser
    {
        // List<KeyValuePair<int IndexA, int Count>> 
        // IndexA is the index of the 1st token or a 1 token pair, indexB = indexA + 1

         List<KeyValuePair<int, int>> pairCounts = new List<KeyValuePair<int, int>>();
        
         Dictionary<string, int> GetTokenCounts(IEnumerable<string> tokens)
         {
            Dictionary<string, int> results = new Dictionary<string, int>();

            foreach (string t in tokens)
            {
                if (!results.ContainsKey(t))
                {
                    results.Add(t, 1);
                }
                else
                {
                    results[t]++;
                }
            }
            return results;
         }

         int GetTokenPairCount(List<string> tokens, string word1, string word2)
         {
            int count = 0;
            for (int i = 0; i < tokens.Count - 1; i++)
            {
                if (tokens[i] == word1 && tokens[i + 1] == word2) count++;
            }
            return count;
         }

         void JoinListElements(ref List<string> list, int indexA, int indexB, char separator = ' ')
         {
            list[indexA] = list[indexA] + separator + list[indexB];
            list.RemoveAt(indexB);
         }

         List<KeyValuePair<int, int>> GetPairCounts(List<string> tokens)
         {
            List<KeyValuePair<int, int>> pairCounts = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < tokens.Count - 1; i++)
            {
                pairCounts.Add(new KeyValuePair<int, int>(i, GetTokenPairCount(tokens, tokens[i], tokens[i + 1])));
            }

            return pairCounts;
         }
         /// <summary>
         /// Delete the pair that was merged, adjust the subsequent pairs to subtract one from the key which indicates the the index of the token where the pair starts
         /// </summary>
         /// <param name="index">index of the token which begins the pair</param>
         void AdjustIndicesOfPairCounts(int index)
         {
            int currentPairCountsKeyValueIndex = 0;
            
            for(int i=0;i<pairCounts.Count;i++)
            {
                if (pairCounts[i].Key == index)
                {
                    currentPairCountsKeyValueIndex = i;
                }
                else if (pairCounts[i].Key > index)
                {
                    pairCounts[i] = new KeyValuePair<int, int>(pairCounts[i].Key - 1, pairCounts[i].Value);
                }
            }

            pairCounts.RemoveAt(currentPairCountsKeyValueIndex);
         }

        public void JoinAllPhrases(ref List<string> tokens, int pairOccuranceThreshold, int pairRelationshipThreshold)
        {
            if (tokens.Count == 0) return;
            int lastCount;
            do
            {
                lastCount = tokens.Count;
                JoinPhrases(ref tokens, pairOccuranceThreshold, pairRelationshipThreshold);
            }
            while (lastCount != tokens.Count);
        }

        public void JoinPhrases(ref List<string> tokens, int pairOccuranceThreshold, int pairRelationshipThreshold)
        {
            if (tokens.Count == 0) return;
            var allCounts = GetTokenCounts(tokens);
            if (pairCounts.Count==0) pairCounts = GetPairCounts(tokens);
            
            for (int i = 0; i < pairCounts.Count; i++)
            {
                if (((float)pairCounts[i].Value - pairOccuranceThreshold) / (allCounts[tokens[pairCounts[i].Key]] * allCounts[tokens[pairCounts[i].Key+1]]) * tokens.Count > pairRelationshipThreshold)
                {
                    JoinListElements(ref tokens, pairCounts[i].Key, pairCounts[i].Key+1); // indices are going to change
                                                                                          // adjust indices and count the occurance of new pair 
                                                                                          // if index is higher (after) pair.Key.indexA then subtract 1
                    AdjustIndicesOfPairCounts(pairCounts[i].Key);
                                       
                    allCounts = GetTokenCounts(tokens);                    
                }
            }
        }
    }
}