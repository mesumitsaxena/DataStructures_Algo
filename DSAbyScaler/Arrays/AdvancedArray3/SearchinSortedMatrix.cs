using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    //Given a matrix of integers A of size N x M and an integer B.
    //In the given matrix every row and column is sorted in increasing order.Find and return the position of B in the matrix in the given form:
    //If A[i][j] = B then return (i* 1009 + j)
    //If B is not present return -1.

    //Note 1: Rows are numbered from top to bottom and columns are numbered from left to right.
    //Note 2: If there are multiple B in A then return the smallest value of i*1009 +j such that A[i][j]=B.
    internal class SearchinSortedMatrix
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
        public int solve(List<List<int>> A, int B)
        {
            // Set upper right row and column values
            int row = 0; // row will be 0
            int col=A[0].Count - 1; // column will be last column which makes top right corner
            // Continue until rows and columns are still accesable
            int ans = -1;
            while(row<A.Count && col >= 0)
            {
                // if found the element, return the neccasary element
                if (A[row][col] == B)
                {
                    // if found store the answer and look for another answer in same row, why?
                    // we have to give the first occurance of that element, so go to previous column and see if we have same
                    // duplicate value or not, then we will calculate the value again and return when different value came
                    ans=(row+1)*(1009)+(col+1);
                    col--;
                }
                // else if value in matrix is greater than B, search in same row but previous column
                else if(A[row][col] > B)
                {
                    // if ans is not -1 means we have found answer just return updted answer
                    if (ans != -1) return ans;
                    // else search in same row
                    col--;
                }
                // else if value in matrix is less than B, search in same column but next row
                else
                {
                    // if ans is not -1 means we have found answer just return updted answer
                    if (ans != -1) return ans;
                    // else search in same column
                    row++;
                }
            }
            // if not found return -1
            return ans;
        }
    }
}
