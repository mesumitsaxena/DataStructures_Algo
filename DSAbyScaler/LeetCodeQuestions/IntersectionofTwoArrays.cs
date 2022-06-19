using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //Given two integer arrays nums1 and nums2, return an array of their intersection.Each element in the result must appear
    //as many times as it shows in both arrays and you may return the result in any order.
    //Example 1:

    //Input: nums1 = [1,2,2,1], nums2 = [2,2]
    //Output: [2,2]
    //Example 2:

    //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
    //Output: [4,9]
    //Explanation: [9,4] is also accepted.
    //https://leetcode.com/problems/intersection-of-two-arrays-ii/
    internal class IntersectionofTwoArrays
    {
        // Solution is store second array values in hashmap and check with 1st array, if matched add it in output
        // and decrease the frequency from map, if freq becomes 0, remove the element from map.
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                if (freqMap.ContainsKey(nums2[i]))
                {
                    freqMap[nums2[i]]++;
                }
                else
                {
                    freqMap.Add(nums2[i], 1);
                }
            }
            int maxLength = Math.Max(nums1.Length, nums2.Length);
            List<int> output = new List<int>();
            int j = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                if (freqMap.ContainsKey(nums1[i]))
                {
                    output.Add(nums1[i]);
                    freqMap[nums1[i]]--;
                    if (freqMap[nums1[i]] == 0)
                    {
                        freqMap.Remove(nums1[i]);
                    }
                }
            }
            int[] finaloutput = new int[output.Count];
            for (int i = 0; i < output.Count; i++)
            {
                finaloutput[i] = output[i];
            }
            return finaloutput;
        }
    }
}
