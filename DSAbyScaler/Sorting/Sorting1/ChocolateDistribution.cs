using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Sorting
{
    //Given an array A of N integers where each value represents number of chocolates in a packet.

    //i-th can have A[i] number of chocolates.

    //There are B number students, the task is to distribute chocolate packets following below conditions:

    //1. Each student gets one packet.
    //2. The difference between the number of chocolates in packet with maximum chocolates and packet with minimum chocolates given to the students is minimum.
    //Return the minimum difference (that can be achieved) between maximum and minimum number of chocolates distributed.
    internal class ChocolateDistribution
    {
        // Solution Approach is, we need a window of B element and find maximum and minimum value in that window.
        // Once we get the max and min, we can maintain the minimum difference of Max-Min of current window.
        // But if we have to find min and max value by iteration then it would be N^2 Solution.
        // We can sort the array, create the window get the last element of the window which will be maximum and 
        // get the first value of the window which will be minimum. make a difference and maintain MinDifference
        public int solve(List<int> A, int B)
        {
            // If Array is empty and B is 0 then return 0
            if (A.Count == 0 || B == 0) return 0;
            // Sorting the array which will help us to get the maximum and minimum of any window
            // maximum of a window will be last element of the window and minimum of a window will be first element of the window
            A.Sort();
            // Initialize minimum with maximum value, so that we can maintain global minimum easily
            int minDifference = Int32.MaxValue;
            // start with window of lenght B
            for (int i = B - 1; i < A.Count; i++)
            {
                // as we observered maximum of the window = last element of the window = A[i] - current element
                // minimum of the window = first element of the window = A[i-(B-1)] = remove window lenght from current index
                int difference = A[i] - A[i - (B - 1)];
                // Maintain minimum difference
                if (difference < minDifference)
                {
                    minDifference = difference;
                }
            }
            //return minimum difference
            return minDifference;
        }
    }
}
