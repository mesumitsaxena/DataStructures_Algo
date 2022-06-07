using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch2
{
    //Given a matrix of integers A of size N x M in which each row is sorted.

    //Find and return the overall median of matrix A.

    //NOTE: No extra memory is allowed.

    //NOTE: Rows are numbered from top to bottom and columns are numbered from left to right.
    //N*M is odd
    internal class MatrixMedian
    {
        // So first of all, what is median for odd count, it is always (1+N)/2
        // but in matrix it will be (1+N*M)/2. So we have to find the (1+N*M)/2th element
        // Now how to find median if we know the number, we can use the same binary search approach.
        // we will use search space on answer and check if mid element is median element or not, how to check?
        // As rows of the matrix are sorted then minRange will be 1st column and maxRange will be last column
        // lets say we land on mid, we will check how many elements are there which are greater than equal to median.
        // we checking count of elements which are less than equal to mid elements are greater than or equal to the median which we calculated.
        // if it is less it means count of elements which are less than or equal to mid are less than K(median) means this mid cannot be our answer
        // because count itself is less.
        // if it is greater it means it can be our answer but lets check for greater answer on right side.
        // we can check count by binary search in each row, as they are sorted.
        public int countByBS(int middle, List<int> A)
        {
            // caculate the count of elements which are less than equal to middle element from main method
            int left = 0;
            int right = A.Count - 1;
            int count = 0;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                // if A[mid] is less than middle it means all the element before mid will also be less than mid
                // but there could be more element on right which are less than middle
                if (A[mid] <= middle)
                {
                    // we can calculate because rows are sorted
                    count += (mid - left)+1;
                    left = mid + 1;
                }
                // if greater than check on left hand side
                else
                {
                    right = mid - 1;
                }

            }
            return count;
        }
        public bool checkCount(int mid, List<List<int>> A, int medianElement)
        {
            //Calculate total number if counts in each rows which is less than equal to mid(from main method)
            int count = 0;
            for (int i = 0; i < A.Count; i++)
            {
                count += countByBS(mid, A[i]);
            }
            // if count is greater than midean which we calculated in beginning, then yes this can be our answer
            if (count >= medianElement) return true;
            // if less than counts are less than medianlement, so answer is not possible with count less than medianelement
            return false;
        }
        public int findMedian(List<List<int>> A)
        {
            // Calculate Median of odd elements by (1+N*M)/2
            int medianElement = (1 + A.Count * A[0].Count) / 2;
            //define search space
            int minRange = Int32.MaxValue;
            int maxRange = Int32.MinValue;
            int lastColumn = A[0].Count - 1;
            int median = 0;
            //Calculate minimum and maximum range
            for (int i = 0; i < A.Count; i++)
            {
                minRange = Math.Min(minRange, A[i][0]);
                maxRange = Math.Max(maxRange, A[i][lastColumn]);
            }
            while (minRange <= maxRange)
            {
                int mid = (minRange + maxRange) / 2;
                // if number of elements which are less than equal to mid are greater than medianElement then answer is possible
                // but check for better answer on left side
                if (checkCount(mid, A, medianElement))
                {
                    median = mid;
                    maxRange = mid - 1;
                }
                // else check the answer on right side
                else
                {
                    minRange = mid + 1;
                }

            }
            //return answer
            return median;
        }
    }
}
