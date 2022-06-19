using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given three sorted arrays A, B and Cof not necessarily same sizes.

    //Calculate the minimum absolute difference between the maximum and minimum number from the triplet a, b, c such that a, b, c belongs arrays A, B, C respectively.i.e.minimize | max(a, b, c) - min(a, b, c) |.

    //Example :

    //Input:

    //A : [ 1, 4, 5, 8, 10 ]
    //B : [ 6, 9, 15 ]
    //C : [ 2, 3, 6, 6 ]
    //Output:

    //1
    //Explanation: We get the minimum difference for a= 5, b= 6, c= 6 as | max(a, b, c) - min(a, b, c) | = | 6 - 5 | = 1.
    internal class MinimizetheAbsDifference
    {
        // Again we can see we need to calculate the difference, So we will put all the pointers at one end, So that
        // We can make concreate decision where to move. refer PairwithGivenDifference problem to understand this concept
        // Now check the max and min among all the array, calculate the difference.
        // Now in order to minimize the difference we will move the minimimum value index, because it can give us higher difference
        // if we choose any other element.
        // Continue this process and maintain minimum diff in variable
        public int solve(List<int> A, List<int> B, List<int> C)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int minDifference = Int32.MaxValue;
            while(i < A.Count && j< B.Count && k< C.Count)
            {
                //Calculate min and max of both array with current pointers
                int minOf3Array=Math.Min(A[i],Math.Min(B[j],C[k]));
                int maxOf3Array = Math.Max(A[i], Math.Max(B[j], C[k]));
                // Calculate the difference
                int difference=maxOf3Array-minOf3Array;
                // Take the minimum difference
                minDifference = Math.Min(difference, minDifference);
                // As we need to minimize the difference, move the index with minimum value
                if (minOf3Array == A[i])
                {
                    i++;
                }
                else if(minOf3Array == B[j])
                {
                    j++;
                }
                else
                {
                    k++;
                }
            }
            return minDifference;
        }
    }
}
