using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch1
{
    //Given a matrix of integers A of size N x M and an integer B.Write an efficient algorithm that searches for integer B in matrix A.

    //This matrix A has the following properties:


    //Integers in each row are sorted from left to right.
    //The first integer of each row is greater than or equal to the last integer of the previous row.
    //Return 1 if B is present in A, else return 0.


    //NOTE: Rows are numbered from top to bottom, and columns are from left to right.
    internal class MatrixSearch
    {
        //Brute force approach is search for the element in Linear search approach, which would be O(N*M).
        // but we can make use of Row wise and Column wise Sorted matrix information.
        // We have 4 places to start the search, upper left and right corner, and bottom left and right corner.
        // Suppose we start with upper left corner, rows are sorted and columns are sorted, so if we want to search 12
        // upper left corner has 5,  if we go row wise, we have greater values than 5 so 12 can be available there
        // Also if we go to column wise, we again get greater values than 5 so 12 can also be available there.
        // can we make a concrete decision where to go? Answer is NO.
        // Lets check upper right corner, suppose upper right corner value is 14, can we make concrete decision, yes
        // if we choose row so all the values in row, right to left will decrease so 12 can be there, if we check column, 
        // all the values in column will be greater so we cant go there, so we will follow this process.

        // Lets understand with the code.
        public int searchMatrix(List<List<int>> A, int B)
        {
            // Set upper right row and column values
            int row = 0; // row will be 0
            int col = A[0].Count - 1; // column will be last column which makes top right corner
            // Continue until rows and columns are still accesable
            int ans = -1;
            while (row < A.Count && col >= 0)
            {
                // if found the element, return 1
                if (A[row][col] == B)
                {
                    // if found return 1
                    return 1;
                }
                // else if value in matrix is greater than B, search in same row but previous column
                else if (A[row][col] > B)
                {
                    // else search in same row
                    col--;
                }
                // else if value in matrix is less than B, search in same column but next row
                else
                {
                    // else search in same column
                    row++;
                }
            }
            // if not found return 0
            return 0;
        }
    }
}
