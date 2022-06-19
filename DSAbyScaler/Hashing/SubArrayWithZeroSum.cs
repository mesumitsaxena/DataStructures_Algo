using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given an array of integers A, find and return whether the given array contains a non-empty subarray with a sum equal to 0.

    //If the given array contains a sub-array with sum zero return 1, else return 0.
    //Input 1:

    // A = [1, 2, 3, 4, 5]
    //Input 2:

    // A = [-1, 1]


    //    Example Output
    //Output 1:

    // 0
    //Output 2:

    // 1
    internal class SubArrayWithZeroSum
    {
        //Whenever we have to check subarray sum, instead of creating each subarray and check the sum.
        // we have very good technque which is called prefix sum, by this we will be able to create and check each subarray sum
        // prefix arrays are always in ascending order if they are positive elements
        // but here we also have -ve values, which can make the sum as 0.
        // lets observe a case scenario, suppose list is-
        // 1 2 3 4 -7 8 -3, its corresponding prefix array will be
        // 1 3 6 10 3 11 8, we can see we have a repeating character as 3 adn when it is repeating whenever a subarray sum is 0
        // 3 4 -7 this subarray sum is 0, so in prefix sum before these elements sum was 3 and after -7 sum is again 3.
        // it means between 2 and -7 subarray sum was 0 then only prefix sum becomes same, right
        // another use case -
        // 1 2 -3 4 => prefix sum 1 3 0 4, so whenever any subarray which is starting from 0th index sum is 0 we will have a prefix sum element as 0
        // So we will create a prefix sum, check if any element is 0 then return 1.
        // if any element is repeating return 1, how to check repeating elements, hashset.
        public int solve(List<int> A)
        {
            List<int> prefixSum = new List<int>();
            prefixSum.Add(A[0]);
            //Create prefix Sum array
            for (int i = 0; i < A.Count; i++)
            {
                prefixSum.Add(prefixSum[i - 1] + A[i]);
            }
            HashSet<int> repeatingElement = new HashSet<int>();
            // Iterate on prefix sum array
            for (int i = 0; i < prefixSum.Count; i++) {
                // check any prefix sum element is 0
                if (prefixSum[i] == 0)
                {
                    return 1;
                }
                // check if any prefix sum element is repeting or not
                else if (repeatingElement.Contains(prefixSum[i])) {
                    return 1;
                }
                // if it is not in hashset, then add it.
                else
                {
                    repeatingElement.Add(prefixSum[i]);
                }
            }

            return 0;
        }
    }
}
