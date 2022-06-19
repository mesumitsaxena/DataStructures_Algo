using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given an array of positive integers A and an integer B, find and return first continuous subarray which adds to B.

    //If the answer does not exist return an array with a single element "-1".

    //First sub-array means the sub-array for which starting index in minimum.
    // Note : Array is sorted
    internal class SubarrayWithGivenSum
    {
        // As we are not aware of the subarray length, so we can not apply Sliding Window Technique
        // So we can use two pointers technique.
        // we need to sum of the subarray, if we iterate and create submatrix, it will take much time
        // So create prefix array, by this we will get to know about the submatrixes
        // now this is like a problem that we need to find the given difference with two pointers.
        // how can we find the subarray, with given sum, simple PF[p2]-PF[p1]+A[p1], because all those sums are calculated from index 0
        // so to find the sum of subarray from p1 to p2, we use this above formula
        
        public List<int> solve(List<int> A, int B)
        {
            int l = 0;
            int r = 0;
            List<int> ans = new List<int>() { -1 };
            List<int> pf = new List<int>();
            pf.Add(A[0]);
            //create prefix array
            for (int i = 1; i < A.Count; i++)
            {
                pf.Add(pf[i - 1] + A[i]);

            }
            while (l<A.Count && r < A.Count)
            {
                // if we found the difference, break the loop so that we will get the p1 and p2 pointers
                // and we will create our answer array from original array from p1 to p2
                if ((pf[r] - pf[l] + A[l]) == B)
                {
                   
                    break;
                }
                // if difference is greater than B, move p1, because we will get greater value on right
                // then only we can reduce the difference
                else if ((pf[r] - pf[l] + A[l]) > B)
                {
                    l++;

                }
                // if difference is lesser than B, move p2 right, to increase the difference, becasue greater elements
                // are on the right and if two pointers move fardest than difference will increase
                else if ((pf[r] - pf[l] + A[l]) < B)
                {
                    r++;
                }
            }
            // if p1 and p2, doesnt reached till end, then create the answer array 
            // with original array by copying the data from p1 to p2 from orginal array to answer array
            if (l < A.Count && r < A.Count)
            {
                ans = new List<int>();
                for (int i = l; i <= r; i++)
                {
                    ans.Add(A[i]);
                }
            }
            return ans;
        }
    }
}
