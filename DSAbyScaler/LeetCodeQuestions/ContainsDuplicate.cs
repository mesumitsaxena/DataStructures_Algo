using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //Given an integer array nums, return true if any value appears at least twice in the array,
    //and return false if every element is distinct.
    internal class ContainsDuplicate
    {
        // Take Hashset and check if set is any duplicate value or not, if yes, return true else add the elemeent
        // if no duplicate found till the end, return false
        //https://leetcode.com/problems/contains-duplicate/
        public bool ContainDuplicate(int[] nums)
        {
            HashSet<int> uniqueSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (uniqueSet.Contains(nums[i]))
                {
                    return true;
                }
                else
                {
                    uniqueSet.Add(nums[i]);
                }
            }
            return false;
        }
    }
}
