using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch2
{
    //Given a sorted array of integers A of size N and an integer B.

    //array A is rotated at some pivot unknown to you beforehand.

    //(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2 ).

    //You are given a target value B to search.If found in the array, return its index otherwise, return -1.

    //You may assume no duplicate exists in the array.

    //NOTE: Users are expected to solve this in O(log(N)) time.
    internal class SearchinRotatedSortedArray
    {
        // So in question Array might be rotated number of times we don't know, only thing which is helping is Array was sorted before rotation.
        // So if look at the example given in question itself and observe - 4 5 6 7 0 1 2
        // we can see there is still sorted array in two parts, one is 4 to 7 and another is 0 to 2
        // So Approach is if find the dipping point somehow and apply binary search on left half and binary search on right half, we can find the element.
        // How do i find the dipping point or pivot element?
        // If we closely look at the data, left side data is always >= A[0] and right side data is <A[0], why?
        // because before rotation, array was sorted and data on right side is smaller than 1st value of array
        // So we can find the pivot element with binary search lets say the pivot element point is t and then we can search
        // the data in 0 to t-1 and to n-1


        // Another approach is instead of 2 binary search, we can make a single binary search and check if required array 
        // K is lying between 0 to mid and A[mid] is >A[0] then search in left side else search on right
        // Next is if A[0]>A[mid] means we are on left side and K is lying between A[n-1] and A[mid] then go to right else go to left
        public int SearchinSingleBS(List<int> A,int B)
        {
            int left = 0;
            int right = A.Count - 1;
            int mid = -1;
            while (left <= right)
            {
                mid=(left+right)/2;
                // if element is found
                if (A[mid] == B) { return mid; }
                // if mid lyies on left side
                if (A[0] <= A[mid])
                {
                    // Also if searched element B is between A[0] and A[mid], means it will not available on right side
                    // so search in left side
                    if(A[0]<B && B < A[mid])
                    {
                        right = mid - 1;
                    }
                    // if it is not in range, then definatly it is availble on right side
                    else
                    {
                        left = mid + 1;
                    }
                }
                // if mid lyies on right side
                else
                {
                    // Also if searched element B is between A[N] and A[mid], means it will available on right side
                    // so search in right side
                    if (A[mid]<B && B < A[A.Count - 1])
                    {
                        left = mid + 1;
                    }
                    // if it is not in range, then definatly it is availble on left side
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return -1;
        }
        public int search(List<int> A, int B)
        {
            int pivot = findPivot(A);
            int foundIndex = -1;
            // if searched element is on left side, then search the element from 0 to pivot
            if (B > A[0])
            {
                foundIndex = BinarySearch(A, 0, pivot - 1,B);
            }
            // if searched element is on right side, then search the element from pivot to n
            else
            {
                foundIndex = BinarySearch(A, pivot, A.Count - 1, B);
            }
            return foundIndex;
        }
        //Find Pivot
        public int findPivot(List<int> A)
        {
            int left = 0;
            int right = A.Count - 1;
            // initialize pivot as -1
            int pivot = -1;
            while (left <= right)
            {
                int mid=(left+right)/2;
                // if mid lyies on left part of the array
                if (A[0] <= A[mid])
                {
                    left = mid + 1;
                }
                // if mid lyies on right part of the array, store the answer and move to the right
                else
                {
                    pivot = mid;
                    right = mid - 1;
                }
            }
            return pivot;
        }
        // Find the element from 0 to pivot and pivot to n and return the found index
        public int BinarySearch(List<int> A,int l, int r, int B)
        {
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if(A[mid]==B) return mid;
                else if (A[mid] > B) { r = mid - 1; }
                else { l=mid+1; }
            }
            //if not found
            return -1;
        }
    }
}
