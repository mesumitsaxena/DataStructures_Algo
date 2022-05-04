using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    internal class LeadersinArray
    {
        //Given an integer array A containing N distinct integers, you have to find all the leaders in array A.

        //An element is a leader if it is strictly greater than all the elements to its right side.

        //NOTE:The rightmost element is always a leader.
        public List<int> solve(List<int> A)
        {
            //Brute Force Solution is , Pick one element and check if all the elements on right is smaller than the element.
            // It will be O(N2) Solution.
            // Optimize way is Traverse from right and keep the maxonright value update it once you get higher element and add it to leaders array
            // while travering to left.
            // its working because right most element will always be leader, we will assign it as maxvalue, then 
            // if we have lesser value it cant be a leader but if we get higher value than max, it can be a leader because
            // max value contains the max, if current value is higher than max value than current value should be max value 
            // as well as leader
            int maxonright = A[A.Count - 1];
            List<int> leaders = new List<int>();
            leaders.Add(maxonright);
            for (int i = A.Count - 2; i >= 0; i--)
            {
                if (A[i] > maxonright)
                {
                    leaders.Add(A[i]);
                    maxonright = A[i];
                }
            }
            return leaders;
        }
    }
}
