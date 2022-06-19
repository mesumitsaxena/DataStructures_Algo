using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

    //Note that you must do this in-place without making a copy of the array.
    //https://leetcode.com/problems/move-zeroes/
    internal class MoveZeros
    {
        //take two pointers
        // when you encountered zero just stop the zero pointer and move the nonzero pointer
        // when you encountered non zero elements, we already have a pointer which is at zero, so just swap the elements
        public void MoveZeroes(int[] nums)
        {
            int nonZero = 0;
            int zero = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[nonZero] != 0)
                {
                    int temp = nums[nonZero];
                    nums[nonZero] = nums[zero];
                    nums[zero] = temp;
                    zero++;
                }
                nonZero++;
            }
        }
    }
}
