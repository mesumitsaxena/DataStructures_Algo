using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray_1
{
    /*Given an array of integers, A of length N, find out the maximum sum sub-array of non negative numbers from A.

    The sub-array should be contiguous i.e., a sub-array created by choosing the second and fourth element and skipping the third element is invalid.

    Maximum sub-array is defined in terms of the sum of the elements in the sub-array.

    Find and return the required subarray.*/
    internal class MaxnonnegativeSubarray
    {
        // Approach is similiar to Kadane's Algo, we we get -ve number we will reset the sum=0 and start the fresh subarray
        // Apart from Sum and Answer, we will have to take indexes as well as we have to return the subarray which has max sum
        public List<int> maxset(List<int> A)
        {
            // Current Sum of Subarray
            long sum = 0;
            // Maximum Sum
            long ans = 0;
            // local start index of a subarray
            int start = -1;
            // local end index of a subarray
            int end = 0;
            // Start index of max sum subarray
            int ans_start = 0;
            // end index of max sum subarray
            int ans_end = 0;
            for (int i = 0; i < A.Count; i++)
            {
                // if element is -ve, we can not continue the subarray, so reset sum=0 and reset the local indexes
                if (A[i] < 0)
                {
                    sum = 0;
                    start = i;
                    end = i;
                }
                // else add the sum and update local end of subarray
                else
                {
                    sum = sum + (long)A[i];
                    end = i;
                }
                // now if sum is greater than answer than answer should be updated
                // Apart from that if ans is qual to sum but array length is higher than max subarray lenght, then also update answer
                // Apart from updating answer, Update maximum subarray indexes as well.
                if (ans < sum || (ans == sum && end - start > ans_end - ans_start))
                {
                    ans = sum;
                    ans_start = start;
                    ans_end = end;
                }
            }
            List<int> MaxSumSubArray = new List<int>();
            //Now create a list from maximum subarray indexes. we will take ans_start+1,
            //because whenever A[i] is -ve, start index is that index only, so orginal index will be next index,
            //that is why we have starrted the index with -1
            for (int i = ans_start + 1; i <= ans_end; i++)
            {
                MaxSumSubArray.Add(A[i]);
            }
            return MaxSumSubArray;
        }
    }
}
