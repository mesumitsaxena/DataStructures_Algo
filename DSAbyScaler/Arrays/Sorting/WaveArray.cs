using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Sorting
{
    // Given an array of integers A, sort the array into a wave-like array and return it.
    //In other words, arrange the elements into a sequence such that

    //a1 >= a2 <= a3 >= a4 <= a5.....
    //NOTE: If multiple answers are possible, return the lexicographically smallest one.
    internal class WaveArray
    {
        // Solution Approach is first we have to sort the array, which will take NlogN time, 
        // then we can swap the adjacent element and skip the swapped element by jumping 2 step away
        public List<int> wave(List<int> A)
        {
            // when we sort the array, then we can clearly see what elements to be swapped
            A.Sort();
            // Iterate on elements skipping 1 element, we will go till n-1 because we will be swapping Nth element by selecting n-1th element
            // Eg:  1 2 3 4 5, we will swap 1 and 2 and then we will jump 2 steps directly to 3 so array will look like 2 1 3 4 5 and our index will be on element valued 3.
            for(int i = 0; i < A.Count - 1; i += 2)
            {
                int temp = A[i];
                A[i] = A[i + 1];
                A[i + 1] = temp;
            }
            // Once done return the array
            return A;
            
        }
    }
}
