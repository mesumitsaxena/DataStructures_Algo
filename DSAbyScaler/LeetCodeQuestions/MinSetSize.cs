using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //You are given an integer array arr. You can choose a set of integers and remove all the occurrences of these integers in the array.

    //Return the minimum size of the set so that at least half of the integers of the array are removed.
    //https://leetcode.com/problems/reduce-array-size-to-the-half/
    internal class MinSetSize
    {
        public int MinSet(int[] arr)
        {
            // Will prepare map to store frequency of each element
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            int halfArray = arr.Length/2;
            for (int i = 0; i < arr.Length; i++)
            {
                if (frequencyMap.ContainsKey(arr[i]))
                {
                    frequencyMap[arr[i]]++;
                }
                else
                {
                    frequencyMap.Add(arr[i], 1);
                }
            }
            // then only store the frequency in list so that we can sort the data in descending order
            // because we will remove the first element which has higher freq, then only we can come to the conclusion
            // that these many elements left and we can stop or continue
            // if I remove small freq elements, then there might be chance that when larger freq elements then we might ending removing more elements
            // but in question it is clear that try removing minimum elements
            int count = 0;
            List<int> countofElements = new List<int>();
            foreach (var iteminMap in frequencyMap)
            {
                countofElements.Add(iteminMap.Value);
            }
            countofElements.Sort((a, b) => b.CompareTo(a));
            int sum = 0;
            for (int i = 0; i < countofElements.Count; i++)
            {
                // create the sum of freq
                sum += countofElements[i];
                // increase the count as we included one element
                count++;
                // if sum is greater or equal to half of the array then return
                if (sum >= halfArray) return count;

            }
            return count;

        }
    }
}
