using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //https://leetcode.com/problems/remove-element/
    internal class RemoveElement
    {
        public int removeElement(int[] nums, int val)
        {
            int nonDuplicate = 0;
            int duplicate = 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[nonDuplicate] != val)
                {
                    nums[duplicate] = nums[nonDuplicate];
                    duplicate++;
                }
                else
                {
                    count++;
                }
                nonDuplicate++;
            }
            return nums.Length - count;
        }
    }
}
