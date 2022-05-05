using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    //Given a 2D integer matrix A of size N x N, find a B x B submatrix where B<= N and B>= 1,
    //such that the sum of all the elements in the submatrix is maximum.
    internal class MaximumSumSquareSubmatrix
    {
        //This problem is another variation of Max Submatrix Sum. but here we just have to consider the submatrix of size B*B
        // So what we can do differntly from Max Submatrix Sum is,
        // Instead of considering all the tr and br, we can fix the br(no need to fix tr, we can calculate tr on the fly as we know br-B=tr) then increase it till it possible
        // Same with columns as well.
        // Note: we will not use kadane's because in kadane's we dont know the subarray size and we find out by checking if (sum<0)
        // but here we are given with window size, so it is kind of Sliding window technique.
        public int solve(List<List<int>> A, int B)
        {
            //Prepare prefix sum matrix column wise
            List<List<int>> prefix = new List<List<int>>();
            for (int row = 0; row < A.Count; row++)
            {
                List<int> list = new List<int>();
                for (int column = 0; column < A[0].Count; column++)
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
            // As we know we have to find max sum for B*B matrix, so bottom row will be B
            // start with br and we can calculate tr (tr=br-B) on the fly.
            
            int maxsum = Int32.MinValue;
            for(int br = B-1; br < A.Count; br++)
            {
                int sum = 0;// for every window of B row wise, we will calculate sum so reset it to 0
                int tr = br - (B - 1); // by this we are reducing one top row loop
                //now calculate sum for first B columns
                for (int col=0; col < B; col++)
                {
                    // if top row is 0 then add the br row value
                    if (tr == 0)
                    {
                        sum += prefix[br][col];
                    }
                    //else subtract the tr-1 rowth value, because we want to calculate sum of B window matrix
                    else
                    {
                        sum += prefix[br][col] - prefix[tr - 1][col];
                    }
                }
                //Calculate max sum
                maxsum=Math.Max(sum, maxsum);
                //Now calculate sum for next B columns
                for(int col=B;col<A.Count; col++)
                {
                    int leftcolumn = col - (B - 1);
                    // if tr is 0 then only remove previous windows column value
                    // (please note that particular column will have sum of tr to br as it is prefix sum matrix)
                    if (tr == 0)
                    {
                        // remove the previous window entire column (leftcolumn-1 will have sum of tr to br of previous window)
                        sum += prefix[br][col] - prefix[br][leftcolumn - 1];
                    }
                    // else first remove previous window row value and then previous window column value
                    else
                    {
                        // Add next window value and remove previous window row value
                        sum += (prefix[br][col] - prefix[tr - 1][col]);
                        // now calculate previous window column value
                        int val = (prefix[br][leftcolumn - 1] - prefix[tr - 1][leftcolumn - 1]);
                        //and subtract it with sum
                        sum = sum - val;
                    }
                    maxsum = Math.Max(sum, maxsum);
                }
            }
            return maxsum;
        }
    }
}
