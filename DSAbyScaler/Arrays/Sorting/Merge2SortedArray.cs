using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Sorting
{
    //Given two sorted integer arrays A and B, merge B and A as one sorted array and return it as an output.
    internal class Merge2SortedArray
    {
        // So this approach is used in Merge Sort to Merge two sorted Arrays
        // Step 1: set pointers p1 and p2 on starting index of both list
        // Step 2: Create a new List(Kind of Temp List) to store Sorted data
        // Step 3: Compare A[p1] and B[p2] which ever is lesser will be the lesser value and can we coppied to Target list
        // Lets understand how? if A[p1] < B[p2] it means no other element can be lesser than A[p1], its because both the arrays
        // are sorted and first element of both array will have least value, So if we pick lease among them will be least in both.
        public List<int> solve(List<int> A, List<int> B)
        {
            // Set the Starting Index as 0 for both Array
            int p1 = 0;
            int p2 = 0;
            // Prepare output Array to store sorted data
            List<int> SortedArray = new List<int>();
            // Continue until we traverse first array or right array completed, if any of the array is traverse 
            // it means rest of array which is left will be kept as it is
            while (p1 < A.Count && p2 < B.Count)
            {
                // if first array element is lesser than push it in answer array and increament the p1 count
                if (A[p1] < B[p2])
                {
                    SortedArray.Add(A[p1++]);
                }
                // if second array element is lesser than push it in answer array and increament the p2 count
                else
                {
                    SortedArray.Add(B[p2++]);
                }
            }
            // If first array is left with elements than push them in answer array
            while (p1 < A.Count) { SortedArray.Add(A[p1++]); }
            // if second array is left with elements than push them in answer array
            while (p2 < B.Count) { SortedArray.Add(B[p2++]); }
            return SortedArray;
        }
    }
}
