using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    // Given a Row wise and Column wise Sorted Matrix, find maximum Submatrix Sum
    internal class MaxSubMatricesSuminSortedMatrix
    {
        // Most Brute Force Approach is Generate All Submatrices and traverse to the submatrix and calculate Sum, Maintain Max, O(n^3*m^3)
        // Brute Force Approach is create a Prefix matrix then generate All Submatrices with prefix sum approach(refer SumofAllMatrices), maintain Max O(n^2*m^2)
        // Optimized Approach-
        // Observation 1: Rows and Columns are sorted, make use of this information, if rows and columns are sorted, max element will be at A[N][M]
        // Observation 2: if all the elements are -ve, then maximum value will A[N][M] and max submatrix sum will be A[N][M]
        // Observation 3: If all the elements in matrix are +ve, then maximum submatrix sum will sum of complete matrix.
        // Observation 4: if we make a prefix Sum of Sorted row and column matrix, we can return A[N][M} for observation 3
        // Final Observation: in Prefix sum, submatrix of maximum sum will always have bottom right row. why? because it has maximum value
        // So if we make prefix sum matrix as well, we can get submatrix by eliminating -ve sum submatrixes and fix our bottom right as last index.
        // ex: 
        // -5 -2 0 3 4
        // -4  0 2 4 5
        //  0  1 3 5 6
        // So if we create prefix sum also we can take bottom right matrix by eleminating top left corners.
        // So we can fix our bottom right as A[N][M] and we can consider top left as every element and subtract it from BR and maintain max
           
        public int MaxSubMatrixSum(List<List<int>> A)
        {
            int bottomrightrow = A.Count - 1;
            int bottomrightcolumn = A[0].Count - 1;
            int maxSubmatrixSum = Int32.MinValue;
            List<List<int>> Prefix = new List<List<int>>();
            //Create a Prefix Array Column wise
            for (int i = 0; i < A.Count; i++)
            {
                List<int> prefixtemp = new List<int>();
                for (int j = 0; j < A[0].Count; j++)
                {
                    if (j == 0)
                    {
                        prefixtemp.Add(A[i][j]);
                    }
                    else
                    {
                        prefixtemp.Add(prefixtemp[j - 1] + A[i][j]);
                    }
                }
                Prefix.Add(prefixtemp);
            }
            // Create a Prefix sum Row wise
            for (int j = 0; j < A[0].Count; j++)
            {
                for (int i = 1; i < A.Count; i++)
                {
                    Prefix[i][j] = Prefix[i - 1][j] + Prefix[i][j];
                }
            }
            int sum = 0;
            // Generate All top lefts considering all the elements
            for(int topleftrow=0; topleftrow < A.Count; topleftrow++)
            {
                for(int topleftcolumn=0; topleftcolumn < A[0].Count; topleftcolumn++)
                {
                    sum += Prefix[bottomrightrow][bottomrightcolumn];
                    if (topleftrow > 0) sum -= Prefix[topleftrow - 1][bottomrightcolumn];
                    if (topleftcolumn > 0) sum -= Prefix[bottomrightrow][topleftcolumn - 1];
                    if (topleftcolumn > 0 && topleftcolumn > 0) sum += Prefix[topleftrow - 1][topleftcolumn - 1];
                    maxSubmatrixSum=Math.Max(sum, maxSubmatrixSum);
                }
            }
            return maxSubmatrixSum;
        }
    }
}
