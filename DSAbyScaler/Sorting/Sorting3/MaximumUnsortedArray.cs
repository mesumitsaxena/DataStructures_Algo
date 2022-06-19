using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Sorting.Sorting3
{
    //Given an array A of non-negative integers of size N.Find the minimum sub-array Al, Al+1 ,..., Ar
    //such that if we sort(in ascending order) that sub-array, then the whole array should get sorted.
    //If A is already sorted, output -1.
    //Input 1:

    //A = [1, 3, 2, 4, 5]
    //Input 2:

    //A = [1, 2, 3, 4, 5]


    //Example Output
    //Output 1:

    //[1, 2]
    //Output 2:

    //[-1]
    internal class MaximumUnsortedArray
    {
        // Solution looks pretty simple, because we will just iterate the array from left and see when next value is smaller
        // that would be the point where this unsorting started
        // Same we will iterate from end and see when previous value is larger, that would be the point where unsorting end.
        // But what if we have duplicate, example : 4 10 4 4 10 18 20, so here we as per the logic from right unsorting end at 2nd index
        // but actually it ended at 3rd index. so how to solve this?
        // so now we know left and right index, just find out the maximum and minimum value in the subarray(left to right)
        // duplicates wont affect max and min.
        // now just iterate from left and right again and check if current value is less than or equal to min value, if yes then fine
        // else that is the point where unsorting started
        // same from end
        // it is because if subarray from i to j is unsorted and we know min and max value, than every value from 0 to i-1 will be lesser or equal
        // same every value from j+1 to n will be larger than max of i to j. 
        // and if array is unsroted than we will find the point where these conditions not satisfying and that would be out indexes
        public List<int> subUnsort(List<int> A)
        {
            // first check left and right pointers
            int left = 0;
            int right = 0;
            for (int i = 0; i < A.Count - 1; i++)
            {
                if (A[i] > A[i + 1])
                {
                    left = i;
                    break;
                }
            }
            for (int i = A.Count - 1; i > 0; i--)
            {
                if (A[i] < A[i - 1])
                {
                    right = i;
                    break;
                }
            }
            // if array is already sorted then return -1
            if (left == 0 && right == 0) return new List<int>() { -1 };
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            // now check max and min within left and right subarray
            for (int i = left; i <= right; i++)
            {
                min = Math.Min(min, A[i]);
                max = Math.Max(max, A[i]);
            }
            int l = 0;
            // now if any array element from left is greater than min of subarray between left and right
            // , it means this is the unsorting starting point
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] > min)
                {
                    l = i;
                    break;
                }
            }
            // now if any array element from right is lesser than max of subarray between left and right
            // , it means this is the unsorting ending point.
            // because if we sort the left and right subarray min value will be on right and max value on the left
            // and from right element will always be greater than max, but if it is not means from this point unsorting ended
            int r = A.Count - 1;
            for (int i = A.Count - 1; i >= 0; i--)
            {
                if (A[i] < max)
                {
                    r = i;
                    break;
                }
            }
            return new List<int>() { l, r };
        }
    }
}
