using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray_1
{
    //Find the contiguous non-empty subarray within an array, A of length N, with the largest sum.
    internal class MaxSubArraySum_Kadane_sAlgo
    {
        public int maxSubArray(List<int> A)
        {
            // Brute Force Solution is Find each subarray and sum all the elements. maintain maxsumans (O(N^2))
            // Optimize Solution is, Kadane's Algorithm
            // include elements in sum until sum becomes -ve, when sum become -ve, reset the sum to 0, why?
            // Because -ve sum can not give max answer even though there higher number after that.
            // next positive number will itself maximum than adding a -ve number into it, so that is why if -ve - Reset to 0.
            // By this we are actually stopping to include an elemnt in subarray and now start a new fresh subarray and check if it can give max sum
            // while calculating sum, maintain maxsumanswer.

            int maxsubarraysum = Int32.MinValue; // Start with least minimum value, so that we can maintain max value each time
            int maxsum = 0; // Start with 0

            for (int i = 0; i < A.Count; i++)
            {
                //Include the element in maxsum
                maxsum += A[i];
                //Update the maxsubarraysum answer
                maxsubarraysum = Math.Max(maxsubarraysum, maxsum);
                // if maxsum is -ve, reset it to 0
                if (maxsum < 0)
                {
                    maxsum = 0;
                }

            }
            return maxsubarraysum;
        }
    }
}
