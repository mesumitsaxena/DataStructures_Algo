using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Sorting
{
    //Find the Bth smallest element in given array A.

    //NOTE: Users should try to solve it in less than equal to B swaps.
    internal class KthSmallestNumber
    {
        // First way is just Sort the array and find the B-1 element.
        // Another way's hint is Selection Sort, we will find 1st minimum element swap it with 0th index, then next minimum swap it with 1st index
        // And so on till Bth index, so that is how we can complete the problem in less than B swaps
        // This is Selection Sort, but just for B elements
        public int kthsmallest(List<int> A, int B)
        {
            // For B elements
            for(int i = 0; i < B; i++)
            {
                // Maintain minimum value for ith postion
                int minimumVal=Int32.MaxValue;
                // Maintain the index of minimum value
                int minIndex = -1;
                // We will check the minimum value from i to n
                for(int j = i;j<A.Count; j++)
                {
                    // Update minimum value and min index each time for given i
                    if (minimumVal > A[j])
                    {
                        minimumVal = A[j];
                        minIndex = j;
                    }
                }
                // After the loop we will have minimum value and index for i, now swap it with A[i]
                int temp = A[i];
                A[i] = A[minIndex];
                A[minIndex] = temp;
            }
            // List is sorted for B elements
            // Return B-1th element
            return A[B - 1];
        }
    }
}
