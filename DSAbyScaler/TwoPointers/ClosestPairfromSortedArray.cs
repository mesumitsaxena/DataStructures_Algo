using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given two sorted arrays of distinct integers, A and B, and an integer C, find and return the pair whose sum is closest to C and the pair has one element from each array.

    //More formally, find A[i] and B[j] such that abs((A[i] + B[j]) - C) has minimum value.

    //If there are multiple solutions find the one with minimum i and even if there are multiple values of j for the same i then return the one with minimum j.

    //Return an array with two elements { A [i], B [j]}.
    //Example Input

    //Input 1:

    // A = [1, 2, 3, 4, 5]
    //    B = [2, 4, 6, 8]
    //    C = 9
    //Input 2:

    // A = [5, 10, 20]
    //    B = [1, 2, 30]
    //    C = 13


    //Example Output

    //Output 1:

    // [1, 8]
    //    Output 2:

    // [10, 2]
    internal class ClosestPairfromSortedArray
    {
        // Lets focus on getting exact sum, it is possible that we will get the exact sum, we will get to closest sum later
        // First of all we will sort both the list.
        // to check the sum, we applied 2pointers in 1 Array, here we have two arrays, so how to work around that?
        // in single array we put the p1 and starting and p2 at end, so we will do the same here in this question as well.
        // we can put p1 on starting of 1st array and p2 at the end of 2nd array and as per the sum move the pointer, just like pair sum
        // but on different arrays
        // why are we placing p1 on first and p2 on second? it should be like p1 should be on minimum of both array and p2 on other.
        // but here it doesn't matter, because one case can be minimum and maximum among both arrays are in 1 array only.
        // Also, when we make a sum and try find the move the pointer, we will never miss the element by which we will get the sum
        // example :
        // A = [5, 9, 20]
        //    B = [1, 2, 30]
        //    C = 10
        // now as per our observation, we can place p1 at min means 1 and max on other means 20, now lets move.
        // 20+1=21> 10, so move right, 9+1=10, now try other approach, put p1 on 5 and p2 on 30, 5+30=35>10, move right,
        // so p2 moves to 2, now 5+2=7<10, now move p1 to 9=> 9+2=11, greater, p2--, p2 moves to 1, 9+1=10.
        // So we can put pointers at any place, but it should be on minimum of any array and p2 on the max of other array where we have not put p1
        // now lets come to closest, we can have to variables, localp1, localp2, then global p1 and global p2.
        // now when sum less than C, then update the global p1 and p2. because that is the closest one.
        // Also check the new sum is closest to C than only update else leave it
        public List<int> solve(List<int> A, List<int> B, int C)
        {
            int left = 0;
            int right = B.Count - 1;
            int globalleft = 0;
            int globalright = B.Count - 1;
            int closestDiff = Int32.MaxValue;
            while(left<A.Count && right>=0)
            {
                // check if closestdifference becomes more small then update diff and global indexes
                if (Math.Abs(A[left] + B[right] - C) < closestDiff)
                {
                    globalleft = left;
                    globalright = right;
                    closestDiff = Math.Abs(A[left] + B[right] - C);
                }
                // this is the special case because if we have 10 and there is sum 9 then diff is 1 also if we have sum 11, then also diff is 1
                // So we need to check if left is same then only update right
                // becasue of this condition mentioned in question-
                //If there are multiple solutions find the one with minimum i and even if there are multiple values of j for the same i then return the one with minimum j.
                else if (Math.Abs(A[left] + B[right] - C) == closestDiff && A[left] == A[globalleft])
                {
                    globalright = right;
                }
                //if sum is exact match, return the elements
                if (A[left] + B[right] == C)
                {
                    return new List<int>() { A[left], B[right] };
                }
                // if sum is less, then move to right to increase the sum
                else if(A[left] + B[right] < C)
                {
                    left++;
                }
                // if Sum is greater move p2 to right
                else if(A[left]+B[right]>C)
                {
                    right--;
                }
            }
            return new List<int>() { A[globalleft], B[globalright] };
        }
    }
}
