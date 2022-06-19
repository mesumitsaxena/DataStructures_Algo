using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //Given an array of strings strs, group the anagrams together. You can return the answer in any order.

    //An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
    internal class GroupAnagrams
    {
        // if we sort a string we will get to know if this is anagrams or not
        // we will keep sorted value as key and its original values as list
        // if sorted value of a string is available as key, then add the string as value in list
        // at the just create 2D array and add all the values of hashmap
        // we are string sorted value as key, because if two strings are anagrams then its sorted string will equal
        public IList<IList<string>> Groupanagrams(string[] strs)
        {
            // create map
            Dictionary<string, List<string>> anagramsMap = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                //sort the string and check as key in map
                string sortedString = SortString(strs[i]);
                if (anagramsMap.ContainsKey(sortedString))
                {
                    // if sorted string exist as key add the existing string as value
                    anagramsMap[sortedString].Add(strs[i]);
                }
                else
                {
                    // if sorted string not exist as key in map then the key with its original value
                    anagramsMap.Add(sortedString, new List<string>() { strs[i] });
                }
            }
            IList<IList<string>> output = new List<IList<string>>();
            foreach (var item in anagramsMap)
            {
                output.Add(item.Value);
            }
            return output;
        }
        public string SortString(string S)
        {
            char[] charArray = S.ToCharArray();
            Array.Sort(charArray);
            return new String(charArray);
        }
    }
}
