using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    //Given an array of integers A of size N that is a permutation of[0, 1, 2, ..., (N - 1)]. It is allowed to swap any two elements(not necessarily consecutive).

    //Find the minimum number of swaps required to sort the array in ascending order.
    internal class MinimumSwapsToSort
    {
        public int solve(List<int> A)
        {
            // Swapping Approach-
            int count = 0;
            int i = 0;
            while (i < A.Count)
            {
                // If element is not in range between 1 to N, just pass
                if (A[i] < 0 || A[i] > A.Count)
                {
                    i++;
                }
                else
                {
                    //Find the right position, Example: 2 3 1    => 2 should be at index 1, so right position is A[i]-1 which is 2-1=1
                    int rightposition = A[i];
                    // if A[i] is not at right position than swap, but do not increment i, because ith elemnt is moved
                    // current position, but we also need to check the element which came after swapping at ith position is 
                    // at current index or not, and we will only move forward until it is moved to current position
                    // or rightposition is already having correct number
                    if (A[rightposition] != A[i])
                    {
                        int temp = A[i];
                        A[i] = A[rightposition];
                        A[rightposition] = temp;
                        //count number of swaps
                        count++;

                    }
                    // if A[i] is at right position than move to increment i
                    else
                    {
                        i++;
                    }
                }
            }
            return count;
        }
    }
}
