using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given an array A of N integers.

    //Find the largest continuous sequence in a array which sums to zero.
    //Output Format
    //Return an array denoting the longest continuous sequence with total sum of zero.

    //NOTE : If there are multiple correct answers, return the sequence which occurs first in the array.
    //Example Input
    //A = [1, 2, -2, 4, -4]


    //Example Output
    //[2,-2,4,-4]


    //Example Explanation
    //[2,-2,4,-4] is the longest sequence with total sum of zero.
    internal class LargestContinouesSequenceZeroSum
    {
        // Longest Continues Sequence means Longest Subarray.
        // So basically we need to find Longest Subarray whose sum is zero, we can find subarray whose sum is zero.
        // easily by creating prefix sum array and check if there is any duplicate or not
        // but here we need to find the longest subarray.
        // it means we need to find if there are duplicate elements than what is the maximum distance between two
        // duplicate elements in prefix array.
        // example: 2 2 1 -3 4 3 1 -8 6 -2 -1
        // prefix : 2 4  5 2 6 9 10 2 8  6  5
        // here we can see, many duplicate elements, which are 2 5 and 6, so in order to find the longest subarray.
        // we need to find the farthest duplicates, example: for 2 at index 0 and 2 at index 7 are fardest, so longest subarray is 7 till now
        // but 5 at index 2 and 5 at index 10 are giving subarray of length 8 which is maximum, that is what we need to check
        // how to proceed?
        // So we need to find first occurance of any element and when its duplicate comes, check the distance between them
        // if its distance is more than the previous max length than update it.
        // we can do it by hashmap, because when an element comes we need to know its duplicate on left, hashmap will store it
        // Also it is not neccessary to create prefix sum, we can calculate its value on the fly only.
        // because we will make sum and then check in hashmap at the same time, so by this we can save some space
        public List<int> lszero(List<int> A)
        {
            // frequency map with element and index
            Dictionary<int, int> firstOccuranceMap = new Dictionary<int, int>();
            // in order to check if subarray starting with 0th index having subarray sum is 0, will store 0 as value in map
            // and its index would be -1, because pf[r]-pf[l-1], example 1 2 3 -5 6=> so subarray sum 0 having length 4
            // which can be determine by pf[r] which is 3-(-1) =4, that is why we will insert (0,-1) in map
            firstOccuranceMap.Add(0, -1);
            int maxsubarrayLength = Int32.MinValue;
            int prefixSum = 0;
            int left = -1;
            int right = -1;
            for(int i=0;i<A.Count; i++)
            {
                //Instead of prefix sum array, we will create prefix sum on the fly.
                prefixSum += A[i];
                if (firstOccuranceMap.ContainsKey(prefixSum))
                {
                    //current index - firstoccurance of duplicate element
                    int difference=i-firstOccuranceMap[prefixSum];
                    // Update the answer and indexes
                    if (difference > maxsubarrayLength)
                    {
                        // left would be pf[l+1], because index is stored as of duplicate value which was made by previous element
                        // so we need to skip to next element
                        left = firstOccuranceMap[prefixSum]+1;
                        right = i;
                        maxsubarrayLength = difference;
                    }
                }
                else
                {
                    //else add the first occurance of the element
                    firstOccuranceMap.Add(prefixSum, i);
                }
            }
            List<int> output = new List<int>();
            if(left>=0 && right >= 0)
            {
                for(int i = left; i <= right; i++)
                {
                    output.Add(A[i]);
                }
            }
            return output;
        }
    }
}
