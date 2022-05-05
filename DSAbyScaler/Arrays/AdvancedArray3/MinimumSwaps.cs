using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    //Given an array of integers A and an integer B, find and return the minimum number of swaps required to bring all the numbers less than or equal to B together.

    //Note: It is possible to swap any two elements, not necessarily consecutive.
    internal class MinimumSwaps
    {
        //we need to know how many swaps we can make to have elements together which are less than equal to B
        // first we will count how many elements are there which are less than equal to B, so that we will know how many elements have to be together.
        // now we know the window size which say K which are less than equal to B.
        // now start a loop from 0 to K and check how many elements are there which are >B( we can say bad elements)
        // by this we will get to know that how many swaps we have to make, because no of elements greater than B in that window = number of swaps we have to make in order to gather the elements <=B together
        // now next window, we will check if last window element which is going is >B if yes we will say number of bad elements--, means one bad element gone.
        // also we will check if next element which is incoming is > B then number of bad elements ++. at the end we will get to know min number of bad element in any window
        // and that would be our answer
        public int solve(List<int> A, int B)
        {
            // find number of elements which are <=B
            int numberofminelemnts = 0;
            for(int i=0;i<A.Count; i++)
            {
                if (A[i] <= B)
                {
                    numberofminelemnts++;
                }
            }
            // if we have only 1 element in array, than we cant make any swaps
            if (numberofminelemnts <= 1) return 0;
            // maintain Minswaps
            int minSwaps = Int32.MaxValue;
            // find number of bad elements aka elements >B in the first window
            int numberofbadelements = 0;
            for(int i = 0; i < numberofminelemnts; i++)
            {
                if(A[i] > B)
                {
                    numberofbadelements++;
                }
            }
            minSwaps = Math.Min(numberofbadelements, minSwaps);
            // now move forward in next windows
            for(int i = numberofminelemnts; i < A.Count; i++)
            {
                // if first element of last window is greater than B, then bad element count will be decreased
                if (A[i-numberofminelemnts] > B)
                {
                    numberofbadelements--;
                }
                // if upcoming element in new window is > B than bad element will increase in the window
                if (A[i] > B)
                {
                    numberofbadelements++;
                }
                // maintain minimum swaps
                minSwaps = Math.Min(numberofbadelements, minSwaps);
            }
            return minSwaps;
        }
    }
}
