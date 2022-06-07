using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch2
{
    //Given an array of integers A and an integer B, find and return the maximum value K such that
    //there is no subarray in A of size K with the sum of elements greater than B.
    internal class SpecialInteger
    {
        // Brute force way is find start with any k and check if any subarray with length K has sum>B, if yes than K is not valid
        // how to decide number for K,? lets start with 1 and check if it is possible than great, lets try with K=2, again possible
        // Lets try K=3 and so on until subarray sum is >B so that K value is our Answer.
        // How to find subarray sum of length K - Sliding Window Technique
        // K will start with 1 and go on till??
        // So what could be maximum subarray size? complete array can be the largest subarray right.
        // So K will be 1 to N
        // So TC will be O(n2)

        // Optimized way, instead of iterating on each K from 1 to N, we can apply binary search and find mid
        // then ask slidingwindow method is mid can be my answer means is subarray of size mid sum is >B or not
        // if subarray sum is <B then mid can be my answer and lets check for better answer on right hand side i.e next greater window

        public int solve(List<int> A, int B)
        {
            // minimum window length can be 1
            int left = 1;
            // maximum window length can be N
            int right = A.Count - 1;
            int Windowlength = -1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                // if window lenght with mid subarray sum is not greater than B than it can be the answer
                // but look for the better answer on right hand side i.e next largest window for which it is possible
                if (CheckSlidingWindow(A, B, mid))
                {
                    Windowlength = mid;
                    left = mid + 1;
                }
                // if window lenght with mid subarray sum is greater than B than it can not be the answer
                // So anything greater than mid can also not be my answer so search it on left hand side
                else
                {
                    right = mid - 1;
                }
            }
            return Windowlength;
        }
        public bool CheckSlidingWindow(List<int> A, int B, int mid)
        {
            int sum = 0;
            //Calculate sum for first window
            for(int i = 0; i < mid; i++)
            {
                sum+=A[i];
            }
            // if first window sum itself > B return false
            if (sum > B) return false;
            for(int i = mid; i < A.Count; i++)
            {
                // for next window, remove previous window first element and add next window last element
                sum += A[i] - A[i - mid];
                //if next window sum itself > B return false
                if (sum > B) return false;
            }
            // if we are done with all windows than it means no window sum is >B
            return true;
        }
    }
}
