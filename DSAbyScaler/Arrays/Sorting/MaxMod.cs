using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Sorting
{
    /*Given an array A of size N, Groot wants you to pick 2 indices i and j such that
    1 <= i, j <= N
    A[i] % A[j] is maximum among all possible pairs of(i, j).
    Help Groot in finding the maximum value of A[i] % A[j] for some i, j.*/
    internal class MaxMod
    {
        // Observation - When will we get max mod? if A[i] is less than A[j] and A[i] is also higher than other element.
        // Example 1 44 3 2, so max mod will be 3%44=3, we cant get more than this, lets try, 44%1=0, 44%2=0, 44%3=2
        // Now try 1%44=1, 1%2=1, 1%3=1, next 2%1=0, 2%3=2, 2%44=2
        // Now finally 3%1=0, 3%2=1, 3%44=3, So we can see max mod is 3.
        // Final Observation, mod will be maximum when A[i] is less than A[j] and A[i] should be greater than other element
        // In other words A[i] should be second max and A[j] should be maximum
        public int solve(List<int> A)
        {
            // So to get the second max and max, either we can iterate and find, or sort the array
            A.Sort();
            // then we just have to return A[secondlastindex]%A[lastindex],
            // but what if Array is 1 2 2 2 2 2, in duplicates we cant perform above statement because it will give the result as 0
            // So we will iterate from the back and see if last two elements are not duplicate then return A[i-1]%A[i]
            for (int i = A.Count - 1; i >= 1; i--)
            {
                if (A[i] != A[i - 1])
                {
                    return A[i - 1] % A[i];
                }
            }
            return 0;
        }
    }
}
