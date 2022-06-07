using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch2
{
    //Given a bitonic sequence A of N distinct elements, write a program to find a given element B in the bitonic sequence in O(logN) time.
    //NOTE:
    //•  A Bitonic Sequence is a sequence of numbers which is first strictly increasing then after a point strictly decreasing.

    internal class BitonicArray
    {
        // If we have completed Sorted Array than we can find the element very easily in the array in logN time
        // but we dont have sorted array, so if somehow if find pivot element where it is decreasing, then we can apply
        // binary search on the left side and right side respectivly
        // how to find pivot element or position?
        // Observation, if A[i] is the pivot element, then A[i-1]<A[i]>A[i+1].
        // if we are on the left side, then A[i]>A[i-1].
        // if we are on the right side, then A[i]>A[i+1].
        // SO we know where are we exactly. So if land on mid then we can check if mid is left or right
        // suppose we are on left and our answer is lying between left and mid then go to left and right=mid-1
        // suppose we are on left and our answer is not lying between left and mid than go to right and left=mid+1;
        // suppose we are on right and our answer is lying between mid and right  than go to right so left=mid+1
        // suppose we are on right and our answer is not lying between mid and right than go to left so right=mid-1

        public int solve(List<int> A, int B)
        {
            int left = 0;
            int right = A.Count - 1;
            while (left <= right)
            {
                int mid=(left+right)/2;
                // if element found
                if(A[mid] == B) return mid;
                // if mid is on left
                if(mid!=0 && A[mid] > A[mid - 1])
                {
                    // if B lyes between left and mid, then check on left
                    if(A[left]<=B && B < A[mid])
                    {
                        right = mid - 1;
                    }
                    //else check on right
                    else
                    {
                        left = mid + 1;
                    }
                }
                // if we are on the right
                else if(mid<A.Count && A[mid] > A[mid + 1])
                {
                    // if B lyes between mid and right then check on right 
                    if(A[mid]>=B && B < A[right])
                    {
                        left = mid + 1;
                    }
                    // else check on left
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return -1;

        }
    }
}
