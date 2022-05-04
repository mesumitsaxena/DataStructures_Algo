using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Sorting
{
    //Given an array of positive integers A, check and return whether the array elements are consecutive or not.
    //NOTE: Try this with O(1) extra space.
    internal class ArrayWithConsecutiveElements
    {
        // Approach is Sort he array and check if next element is not consecutive retun 0, else after checking all the elements return 1
        // As Constraints says try it in O(1), we can maybe try Bubble or Selection Sort
        public int solve(List<int> A)
        {
            // If Constraints are length of Array is 10^5 then below approach wont work, because it is O(N^2) Approach
            // 10^5^2=10^10 which will lead us into TLE, in that case, just use A.Sort();
            // Repeat the process of pushing the max element at end
            for(int i = 0; i < A.Count; i++)
            {
                // Now check for every element if it is greater than consecutive element or not.
                // By this we will push maximum element at Nth place, and then second max element at (n-1)th index and so on 
                for(int j = 0; j < A.Count - i-1; j++)
                {
                    // If yes, swap it with next element
                    if (A[j] > A[j + 1])
                    {
                        int temp=A[j];
                        A[j] = A[j + 1];
                        A[j+1] = temp;
                    }
                }
            }
            for(int i=0;i< A.Count-1; i++)
            {
                // Check if next element is consecutive or not
                if (A[i] + 1 != A[i + 1])
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
