using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    // Given UnSorted Matrix which can consist -ve and +ve elements
    // find a Submatrix whose Sum is Maximum among all submatrices
    internal class MaxSubMatrixSumInUnSortedMatrix
    {
        // Brute Force Approach is we can Create All Submatrices and calculate sum and compare sum with other submatrix sum
        // We can use Prefix sum to check calculate sum faster so TC: O(N^2*M^2).

        // Optimize Approach - If we have 1D array, then we can directly apply Kadane's and we will get the max sum
        // but we have Matrix, So how can we apply Kadane's here?
        // One thing is clear that columns are fine as in 1 D Array when we apply kadane's it takes care which columns to include or not
        // , only thing we have multiple rows.
        // Suppose we have only 2 rows, so we can apply kadane's on 1st row and then 2nd row seperetly.
        // these will be max sum on each row (which are kind of submatrix only) and by kadane's we are taking care of columns
        // now we are left with submatrx with top row with 1 and bottom row with 2, so what we can do is add both row column wise and apply kadane's again
        // maintain max sum in answer variable and we are done.
        // So what we can do, we can generate multiple rows options ex: top row 0 to bottom row 0, then tr=0, br=1, tr=0, br=2
        // tr=1, br=1, tr=1,br=2, etc. so tr to br we will create sum column wise and apply kadane's.
        // for that we can create prefix sum column wise only.
        
        public int MaxSubMatrixSum(List<List<int>> A)
        {
            //create prefix sum matrix column wise
            List<List<int>> prefix= new List<List<int>>();
            for(int row=0; row<A.Count; row++)
            {
                List<int> list= new List<int>();
                for(int column=0;column<A[0].Count; column++)
                {
                    if (row == 0)
                    {
                        list.Add(A[row][column]);
                    }
                    else
                    {
                        list.Add(prefix[row - 1][column] + A[row][column]);
                    }
                }
                prefix.Add(list);
            }
            int maxSum = Int32.MinValue;
            int sum = 0;
            //Generate Top row and bottom row combinations
            for(int tr = 0; tr < A.Count; tr++)
            {
                for(int br=tr; br < A.Count; br++)
                {
                    // now Apply Kadane's, we already have prefix sum matrix, So we will calculate sum from tr to br in O(1)
                    // but we also need to iterate on columns between tr and br, so we will create a loop for columns
                    for(int col=0;col<A[0].Count; col++)
                    {
                        // if top row is 0 then we will not subtract it, because then we are calculating from row 0 to x or y
                        if (tr == 0)
                        {
                            sum += prefix[br][col];
                        }
                        //else we will subtract the tr-1 row, just like we used to do it prefix sum array
                        else
                        {
                            sum+=prefix[br][col]-prefix[tr-1][col];
                        }
                        // rest will be classic kadane's conditions
                        maxSum = Math.Max(sum, maxSum);
                        if (sum < 0)
                        {
                            sum = 0;
                        }
                    }
                }
            }
            return maxSum;
            // This O(N^2*M) - n2 for tr and br combination and m for column iteration
        }
    }
}
