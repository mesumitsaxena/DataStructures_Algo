using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch1
{
    //Given a sorted array of integers A(0 based index) of size N, find the starting and the ending position of a given integer B in array A.

    //Your algorithm's runtime complexity must be in the order of O(log n).

    //Return an array of size 2, such that the first element = starting position of B in A and the second element = ending position of B in A, if B is not found in A return [-1, -1].
    internal class SearchforaRange
    {
        // Approach is, we will find the first occuranse of the number by binary search.
        // We will find the last occurance of the same number using binary search, lets see how we can find first adn last occurances
        public List<int> searchRange(List<int> A, int B)
        {
            int firstoccurance = OccuranceBinarySearch(A, B, "first");
            int lastoccurance = OccuranceBinarySearch(A, B, "last");
            return new List<int>() { firstoccurance, lastoccurance };

        }
        public int OccuranceBinarySearch(List<int> A, int B, string occurance)
        {
            //left
            int l = 0;
            //right
            int r = A.Count - 1;
            //start mid as -1 becasue 0 can be a position
            int occindex = -1;
            // while l is not greater than r
            while (l <= r)
            {
                int mid = (l + r) / 2;
                //if element found
                if (A[mid] == B)
                {
                    // if element found, this can be our desired index(first or last occurance)
                    occindex = mid;
                    // so we will store the index as answer and search for better answer based on first or last index
                    // if we are searching for firsr occurance, then search the better answer left side
                    if (occurance == "first")
                    {
                        r = mid - 1;
                    }
                    // if we are searching for last occurance, then search the better answer right side
                    else if (occurance == "last")
                    {
                        l = mid + 1;
                    }
                }
                //if mid element is greater than desited element, then answer should be on left hand side, so right = mid - 1
                else if (A[mid] > B)
                    r = mid - 1;
                //if mid element is lesser than desired element, then answer should be on right hand side, so left = mid + 1
                else if (A[mid] < B)
                    l = mid + 1;
            }
            return occindex;
        }
    }
}
