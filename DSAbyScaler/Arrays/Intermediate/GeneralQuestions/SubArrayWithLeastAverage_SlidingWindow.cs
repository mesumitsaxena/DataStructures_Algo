using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    //Given an array of size N, find the subarray of size K with the least average.
    internal class SubArrayWithLeastAverage_SlidingWindow
    {
        // Brute Force Solution is we can find each subarray of Size B and check if we get min Average
        // If we can get a minimum sum, it will give us minumum average as well.
        // Optimize solution is , we can Use Sliding Window Technique
        // We can precompute sum of subarray of size B, then we can add K+1 element and remove i-1 element to check the next subarray of size k
        // example : 1 2 3 4 5 and B=2 1+2=3 now add i+B= 3 and remove i-1= 2-1=1 so remove 1 and so on.
        // Maintain minimum variable answer to capture minimum value.
        public int solve(List<int> A, int B)
        {
            int minAverageSum = Int32.MaxValue;
            int sum = 0;
            // Make a sum of first B elements
            for(int i = 0; i < B; i++)
            {
                sum+=A[i];
            }
            // This sum can be the answer, so that the minimum
            minAverageSum = Math.Min(minAverageSum, sum);
            // we will go till last windows first element. 
            for(int i = 1; i <A.Count-B; i++)
            {
                // Add next window element, example: 1 2 3 4 5, and B=2, so in first 2 elements will make a sum
                // now when i=1, we have to add 3 which is i=2, how to get? i+(B-1)=1+(2-1)=2. (B-1) because we need a next element when
                // we are at one index up. 1 2 3 4, B=3, we have first 3 elements sum, now we need next element while removing first element
                // of window, for that we need to jump into new window, i++, as we jump to next index, we need B-1 index more to get the next windows last element value.
                // thats why (B-1), and we need it from current index, so i+(B-1)
                sum+=A[i+B-1];
                //Remove first element of last window.
                sum -= A[i-1];
                minAverageSum = Math.Min(minAverageSum, sum);
            }
            return minAverageSum;
        }
    }
}
