using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch1
{
    //Given an array of integers A, find and return the peak element in it.An array element is peak if it is NOT smaller than its neighbors.

    //For corner elements, we need to consider only one neighbor.We ensure that answer will be unique.

    //NOTE: Users are expected to solve this in O(log(N)) time.
    internal class FindPeakElement
    {
        // Approach to solve this question is we have to find  any of the peak element.
        //peak element is greater than previous element and ggreater than next element
        // We can go linearly and find the peak element, but as per the question we haev to find in logn time,
        // so only binary search can be applied here(even though data is not sorted, lets see how we can apply)
        // So Inorder to apply Binary search,we would have to know 4 conditions
        // 1,) if we land on mid and A[mid]>A[mid-1> and A[mid]>A[mid+1], bingo we go the answer
        // 2.) if we land on mid and there is tilted line like A[mid-1]<A[mid] and A[mid]<A[mid+1] so kind of / this. so we have to go to greater side so, l=mid+1
        // 3.) if we land on mid and there is tilted line like A[mid+1]<A[mid] and A[mid]<A[mid-1] so kind of \ this. so we have to go to greater side so , r=mid-1
        // 4.) if mid is very less and its like \/ and condition can be A[mid-1]>A[mid] and A[mid+1]>A[mid], then what should be do and where to go?
        // we will choose between A[mid-1] and A[mid+1] if any of them is greater, lets see from the code
        public int solve(List<int> A)
        {
            if(A.Count==1) return A[0];// if single element then return it.
            // if first element is greater than second element, then it can be our peak, as we can consider lesser value on left
            if (A[0] > A[1]) return A[0];
            // if last element is greater than second last element, then it can be our peak, as we can consider lesser value on right
            if (A[A.Count - 1] > A[A.Count - 2]) return A[A.Count - 1];
            //After checking first and last element,we can reduce our search space to 1 to seocnd last element
            int l = 1;
            int r = A.Count - 2;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                // 1,) if we land on mid and A[mid]>A[mid-1]> and A[mid]>A[mid+1], bingo we go the answer
                if (A[mid]>A[mid-1] && A[mid] > A[mid + 1])
                {
                    return A[mid];
                }
                //2.) if we land on mid and there is tilted line like A[mid - 1]< A[mid] and A[mid]< A[mid + 1] so kind of / this.so we have to go to greater side so, l = mid + 1
                else if(A[mid-1]<A[mid] && A[mid] < A[mid + 1])
                {
                    l = mid + 1;
                }
                // 3.) if we land on mid and there is tilted line like A[mid+1]<A[mid] and A[mid]<A[mid-1] so kind of \ this. so we have to go to greater side so , r=mid-1
                else if (A[mid-1]>A[mid] && A[mid] > A[mid + 1])
                {
                    r = mid - 1;
                }
                // 4.) if mid is very less and its like \/ and condition can be A[mid-1]>A[mid] and A[mid+1]>A[mid], then what should be do and where to go?
                // we will choose between A[mid-1] and A[mid+1] if any of them is greater
                else
                {
                    // if A[mid-1] is greater than move to left side
                    if (A[mid - 1] > A[mid + 1])
                    {
                        r = mid - 1;
                    }
                    // if A[mid+1] is greater than move to right side
                    else
                    {
                        l = mid + 1;
                    }
                }
            }
            // after the loop return mid element
            return A[(l + r) / 2];
        }
    }
}
