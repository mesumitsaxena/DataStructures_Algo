using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    //Given an integer A, generate a square matrix filled with elements from 1 to A2 in spiral order.
    internal class SpiralMatrix2
    {
        // First store 1st row values(left to right), then last column(top to bottom).
        // then last row(right to left), then first column(bottom to top). after that row and col will be on 0,0
        // Increase row and col index inorder to move inner submatrix. now row and col will be on 1,1.
        // keep on doing that until you are not left with any submatrix, means N becomes 1
        public List<List<int>> generateMatrix(int A)
        {
            // as this will be our square matrix, so store the value of A in N, so that we can use it later
            int N = A;
            // Create a matrix of A*A size
            int[,] mat = new int[A, A];
            // row and column indexes
            int row = 0;
            int col = 0;
            // this will be our value which will be store in matrix
            int c = 1;
            // continue until we are left with single submatrix
            while (A > 1)
            {
                // move on  row(left to right) till second last column, because last column will be covered when we are traversing column wise
                for (int k = 1; k <= A - 1; k++)
                {
                    mat[row, col] = c;
                    c++;
                    // next column
                    col++;
                }
                // move on  column(top to down) till second last row, becasue last row will be covered when we are traversing row rught to left
                for (int k = 1; k <= A - 1; k++)
                {
                    mat[row, col] = c;
                    c++;
                    // next row
                    row++;
                }
                // move on row(right to left) till 2nd column, becasue 1st column will be covered by column traversal bottom to top
                for (int k = 1; k <= A - 1; k++)
                {
                    mat[row, col] = c;
                    c++;
                    // decremeent column
                    col--;
                }
                // move on column(bottom to top) till 2nd cell on row, becasue 1st value is already covered
                for (int k = 1; k <= A - 1; k++)
                {
                    mat[row, col] = c;
                    c++;
                    // decrement row
                    row--;
                }
                // now reduce the traversing space, becasue we have already covered 0 to N-1 values row and column wise
                // now we will be moving 1 to N-2 space row and column wise
                A = A - 2;
                // move to next space(ex: 1,1)
                row++;
                col++;
            }
            // if we are left with only 1 space, or input is 1 only then assign the value to that cell.
            if (A == 1)
            {
                mat[row, col] = c;
            }
            // copy back the into list because it is required a return type as list
            List<List<int>> output = new List<List<int>>();
            for (int z = 0; z < N; z++)
            {
                List<int> list = new List<int>();
                for (int x = 0; x < N; x++)
                {
                    list.Add(mat[z, x]);
                }
                output.Add(list);
            }
            return output;
        }
    }
}
