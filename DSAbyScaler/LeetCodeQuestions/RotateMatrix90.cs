using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
    //You have to rotate the image in-place, which means you have to modify the input 2D matrix directly.
    //DO NOT allocate another 2D matrix and do the rotation.
    //https://leetcode.com/problems/rotate-image/
    internal class RotateMatrix90
    {
        // To Rotate the matrix 90 degree, there are two steps
        // 1. Transpose the matrix, what is transpose, keep the diagnonal, and replace elements of upper right of diagonal
        // with bottom left of diagonal.
        //2. reverse each row
        public void Rotate(int[][] matrix)
        {
            //Transpose the matrix first
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
            // reverse each array
            for (int i = 0; i < matrix.Length; i++)
            {
                reverseRow(matrix[i]);
            }

        }
        public void reverseRow(int[] A)
        {
            int i = 0;
            int j = A.Length - 1;
            while (i < j)
            {
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
                i++;
                j--;
            }
        }
    }
}
