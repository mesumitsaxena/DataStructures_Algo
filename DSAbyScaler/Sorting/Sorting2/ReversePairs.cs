using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Sorting.Sorting2
{
//    Given an array of integers A, we call(i, j) an important reverse pair if i<j and A[i]> 2* A[j].
//Return the number of important reverse pairs in the given array A.
    internal class ReversePairs
    {
        public int solve(List<int> A)
        {
            return Inversion(A, 0, A.Count - 1);
        }
        public int Inversion(List<int> A, int l, int r)
        {
            //Base condition
            // when we are left with single element after breaking into half, number of count will be 0,
            // becasue we cant make the comparison with any one to check A[i]>A[j]
            if (l == r) return 0;
            // Calculate Middle
            int mid = (l + r) / 2;
            // Do a recursive calls to calculate left side count.(eg. left side we have 2 elements so, we will calculate
            // count of inversion pairs of two elements with Merge function(recursivly) and it will give us the count
            // Note: this will be sorted
            int countfromleft = Inversion(A, l, mid);
            // Do a recursive calls to calculate right side count.(eg. right side we have 2 elements so, we will calculate
            // count of inversion pairs of two elements with Merge function(recursivly) and it will give us the count
            // Note: this will be Sorted
            int countfromright = Inversion(A, mid + 1, r);
            int p1 = l;
            int p2 = mid + 1;
            int countwhilemerge = 0;
            while (p1 < mid + 1 && p2 <= r)
            {
                if (A[p1] > 1L * 2 * A[p2])// Range is 10^9, so if we multiply by 2,
                                           // it might give us overflow value which is -ve and answer might be different, so convert it to long
                {
                    countwhilemerge = countwhilemerge + (mid + 1 - p1);
                    p2++;
                }
                else
                {
                    p1++;
                }
            }
            // After getting the counts of (eg. 2 elements) from left and 2 elements from right, we will calculate the inversion
            // count pairs by merging these arrays 
            Merge(A, l, mid + 1, r); // Merge the array from l to m and m+1 to r
            // return addition of all the count to previous function call( this will be like carry forwarding the count).
            // note: by this only we are getting the count in countfromleft and countfromright
            return countfromleft + countfromright + countwhilemerge;
        }
        public void Merge(List<int> A, int l, int mid, int r)
        {
            int p1 = l;
            int p2 = mid;
            List<int> tempArray = new List<int>();
            while (p1 < mid && p2 <= r)
            {
                if (A[p1] <= A[p2])
                {
                    tempArray.Add(A[p1++]);
                }
                else
                {
                    tempArray.Add(A[p2++]);
                }
            }
            while (p1 < mid) tempArray.Add(A[p1++]);
            while (p2 <= r) tempArray.Add(A[p2++]);
            for (int i = 0; i < tempArray.Count; i++)
            {
                A[i + l] = tempArray[i];
            }
        }
    }
}
