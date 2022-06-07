using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch1
{
    //Given a sorted array of integers A where every element appears twice except for one element which appears once, find and return this single element that appears only once.

    //NOTE: Users are expected to solve this in O(log(N)) time.
    internal class SingleElementinSortedArray
    {
        // Approach is as every element is repeated twice we can make use of this information.
        // here there will be two sides, of the array, left side of the array from the unique element and right side of the array from the unique element
        // how to identify if we are on left side or right side?
        // every duplicate element will have their first occurance.
        // So left side of the array from unqiue element will have their first occurance index at even position or we can say (%2==0)
        // and right side of the array from unique element will have their first occurance index at odd position or we can say (%2!=0)
        // how? lets see 2 2 3 3 4 4 5 6 6
        // can we see, as there are only 2 occurance of elements and they are together, so left side first occ will be at even position
        // but once the unique element came, it will disturb the order as itis only 1 element, so after that each first occurance will be at odd position
        // So we will apply binary search, if mid came to an element we will check if left of it is not equal and right of it is not equal, then bingo, we got the element
        // otherwise, we will check if mid is on first occ or not, because then only we will be able to know if we are on left side or right side
        // so for that we will check if left of mid is same then we are on second occ so mid=mid-1
        // now check if first occ is even or odd and then move accordingly
        public int solve(List<int> A)
        {
            if (A.Count == 1) return A[0];
            //if unique element is on the edges, say at first index
            if (A[0] != A[1]) return A[0];
            //if unique index is on the last index
            if (A[A.Count - 1] != A[A.Count - 2]) return A[A.Count - 1];
            int l = 0;
            int r = A.Count - 1;
            int mid = -1;
            while (l <= r)
            {
                mid = (l + r) / 2;
                // if mid element is not equal to left of it and right of it, then that is unique element
                if (A[mid - 1] != A[mid] && A[mid] != A[mid + 1])
                {
                    return A[mid];
                }
                // if it is not unique and still left is equal to mid then surely it is a second occurance, so move it to first occurance
                else if (A[mid - 1] == A[mid])
                {
                    mid = mid - 1;
                }
                // if first occurance of mid is even than move 2 steps(as we have duplicate element) on right, 
                if (mid % 2 == 0)
                {
                    l = mid + 2;
                }
                // if first occurance is odd then answer wpuld be available at left so move left
                else
                {
                    r = mid - 1;
                }
            }
            return A[mid];
        }
    }
}
