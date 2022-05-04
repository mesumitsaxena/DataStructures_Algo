using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    //Given an array of integers A and an integer B,
    //find and return the difference of B'th max element and B'th min element of the array A.
    internal class BthMaxandMin
    {
        // To Find Bth Max and Min, Brute force solution is Find the maximum than next and next B times.
        // same for Bth Minimum
        // Optimize way is , if we sort the array, we will have all the minimum values at starting and all the maximum values at end
        // Now very simple, just find Bth from end and Bth from beginning
        public int solve(List<int> A, int B)
        {
            //  As order is not a concern herem we can Sort the Array
            A.Sort();
            // total numbers of elements - B will give us Bth maxmimum element from last
            int bthMaximum=A[A.Count-B];
            // As it is a Zero based indexing, B-1 element from beginning will give minimum Bth element
            int bthMinimum = A[B - 1];
            // return the difference
            return bthMaximum - bthMinimum;
        }
    }
}
