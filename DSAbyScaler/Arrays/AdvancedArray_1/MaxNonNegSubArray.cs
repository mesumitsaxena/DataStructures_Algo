using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray_1
{
    //Given an array of integers, A of length N, find out the maximum sum sub-array of non negative numbers from A.

    //The sub-array should be contiguous i.e., a sub-array created by choosing the second and fourth element and skipping the third element is invalid.

    //Maximum sub-array is defined in terms of the sum of the elements in the sub-array.

    //Find and return the required subarray.
    internal class MaxNonNegSubArray
    {
        // We will use the Kadane's Algo concept here, we will reset when we encountered any -ve element.
        // As we need Array element, we will store start and end indexes of global max and local maximum
        public List<int> maxset(List<int> A)
        {
            // Local max answer
            long sum = 0;
            // global max answer
            long ans = 0;
            // local max start index
            int start = -1;
            // local max end index
            int end = 0;
            // global max start index
            int ans_start = 0;
            // global max end index
            int ans_end = 0;
            for (int i = 0; i < A.Count; i++)
            {
                // reset local max start ,end index and local sum
                if (A[i] < 0)
                {
                    sum = 0;
                    start = i;
                    end = i;
                }
                // else add the element and update local end
                else
                {
                    sum = sum + (long)A[i];
                    end = i;
                }
                // whenever local max sum is greater then global max sum, update global sum as well as global indexes
                if (ans < sum || (ans == sum && end - start > ans_end - ans_start))
                {
                    ans = sum;
                    ans_start = start;
                    ans_end = end;
                }
            }
            List<int> MaxSumSubArray = new List<int>();
            for (int i = ans_start + 1; i <= ans_end; i++)
            {
                MaxSumSubArray.Add(A[i]);
            }
            return MaxSumSubArray;
        }
    }
}
