using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //You are given 3 sorted arrays A, B and C.

    //Find i, j, k such that : max(abs(A[i] - B[j]), abs(B[j] - C[k]), abs(C[k] - A[i])) is minimized.

    //Return the minimum max(abs(A[i] - B[j]), abs(B[j] - C[k]), abs(C[k] - A[i])).
    //Example Input
    //Input 1:

    //    A = [1, 4, 10]
    //    B = [2, 15, 20]
    //    C = [10, 12]
    //    Input 2:

    // A = [3, 5, 6]
    //    B = [2]
    //    C = [3, 4]


    //    Example Output
    //Output 1:

    // 5
    //Output 2:

    // 1
    internal class Array3Pointer
    {
        // As we worked on difference between pairs problem, we choose from one side, so that we will have distinct idea where to move.
        // So we will choose to go ahead from index 0.
        // Now generate the difference and capture the maximum among all, now in order to minimize the difference
        // we will move from smallest among all the pointers, because if we keep the min value, difference can be increased.
        // and with this  maximum difference between the pairs will be maximizmed, we need to minimized the max diff
        // So for this we will move minimum value, so the difference will be minimized
        public int minimize(List<int> A, List<int> B, List<int> C)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int minOfMaxDiff = Int32.MaxValue;
            while(i<A.Count && j<B.Count && k < C.Count)
            {
                int ABDiff = Math.Abs(A[i] - B[j]);
                int BCDiff = Math.Abs(B[j] - C[k]);
                int CADiff = Math.Abs(C[k] - A[i]);
                // Get the Maximum Diff
                int maxDiff = Math.Max(ABDiff, Math.Max(BCDiff, CADiff));
                // get the Min of max diff for iteration
                minOfMaxDiff = Math.Min(maxDiff, minOfMaxDiff);
                //Check for minimum among all 3 for this iteration
                int minOfAll = Math.Min(A[i], Math.Min(B[j], C[k]));
                // and we will move that minimum as per the reason defined above.
                //(because min value can give max diff and we want to minimize the diff)
                if (A[i] == minOfAll)
                {
                    i++;
                }
                else if (B[j] == minOfAll)
                {
                    j++;
                }
                else
                {
                    k++;
                }
            }
            return minOfMaxDiff;
        }
    }
}
