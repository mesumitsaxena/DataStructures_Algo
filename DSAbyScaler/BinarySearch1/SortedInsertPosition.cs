using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch1
{
    //Given a sorted array A of size N and a target value B, return the index(0-based indexing) if the target is found.
    //If not, return the index where it would be if it were inserted in order.

    //NOTE: You may assume no duplicates in the array.Users are expected to solve this in O(log(N)) time.
    internal class SortedInsertPosition
    {
        // Apply Binary Search Concept,
        // find mid element, if mid element is desited element return mid index
        // if mid element is lesser than desired element, then answer should be on right hand side, so left=mid+1
        // if mid element is greater than desited element, then answer should be on left hand side, so right=mid-1
        // if element is not found, then after iteration we would have been near to that position where the element should be
        // so if mid element is < b then b element should be at next position of mid
        // if it is on greater than we are already on correct position
        public int searchInsert(List<int> A, int B)
        {
            //left
            int l = 0;
            //right
            int r = A.Count - 1;
            //start mid as -1 becasue 0 can be a position
            int mid = -1;
            // while l is not greater than r
            while (l <= r)
            {
                mid = (l + r) / 2;
                //if element found
                if (A[mid] == B)
                    return mid;
                //if mid element is greater than desited element, then answer should be on left hand side, so right = mid - 1
                else if (A[mid] > B)
                    r = mid - 1;
                //if mid element is lesser than desired element, then answer should be on right hand side, so left = mid + 1
                else if (A[mid] < B)
                    l = mid + 1;
            }
            // if elemeent not found and mid element is < b then b element should be at next position of mid
            if (A[mid] < B)
                return mid + 1;
            //if it is on greater than we are already on correct position
            return mid;
        }
    }
}
