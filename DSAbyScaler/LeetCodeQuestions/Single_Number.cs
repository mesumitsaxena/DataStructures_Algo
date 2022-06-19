using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //Given a non-empty array of integers nums, every element appears twice except for one.Find that single one.

    //You must implement a solution with a linear runtime complexity and use only constant extra space.



    //Example 1:


    //Input: nums = [2, 2, 1]
    //Output: 1
    //Example 2:


    //Input: nums = [4, 1, 2, 1, 2]
    //Output: 4
    //Example 3:


    //Input: nums = [1]
    //Output: 1
    internal class Single_Number
    {
        // Simple silution is XOR-> A XOR A =0 and X XOR 0=X.
        // So just take XOR of whole array, repeating elements will be cancelled out will left with Single Unique element
        public int SingleNumber(int[] nums)
        {
            int num = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                num = num ^ nums[i];
            }
            return num;

        }
    }
}
