using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    //Given an array of integers A and multiple values in B, which represents the number of times array A needs to be left rotated.

    //Find the rotated array for each value and return the result in the from of a matrix where ith row represents the rotated array for the ith value in B.
    internal class MultipleLeftRotation
    {
        // In Order to rotate a array K times in left, means data from left side will be transfered to right.
        // and we have to do it for B list times.
        // Solution would in 3 steps.
        // Example: 1 2 3 4 5 - rotate 3 times from left - output would be 4 5 1 2 3, 
        // Step 1 Reverse the Array, 5 4 3 2 1, Keep the number of rotation in limit with number of elements in Array (B%ACount)
        // Step 2 Reverse N-B[i] elements, means 5-3=2 elements - 4 5 3 2 1
        // Step 3 Reverse B[i] =3 elements, 4 5 1 2 3
        // Repeat the process for all the B list
        public List<List<int>> solve(List<int> A, List<int> B)
        {
            List<List<int>> RotatedMatrix= new List<List<int>>();
            for (int i = 0; i < B.Count; i++)
            {
                // As we have to perform Array rotation again and again on original array, thats why making a copy and perform operations on that.
                List<int> input = new List<int>();
                for(int j=0; j < A.Count; j++)
                {
                    input.Add(A[j]);
                }
                // Keep the rotation count in limit, because after rotating the array N times, it will become original array
                int rotation = B[i] % A.Count;
                //Step 1: Reverse the original Array
                input = Reverse(input, 0, input.Count - 1);
                // Step 2 Reverse N-B[i] elements
                int n = input.Count - 1 - rotation;
                input = Reverse(input, 0, n);
                // Step 3 Reverse B[i]  elements
                input = Reverse(input, n+1, input.Count-1);
                RotatedMatrix.Add(input);
            }
            return RotatedMatrix;

        }
        public List<int> Reverse(List<int> input, int startindex, int endindex)
        {
            //we can just swap start and end elements of the same array and continue doing that until reached to middle
            while (startindex < endindex)
            {
                int temp=input[startindex];
                input[startindex]=input[endindex];
                input[endindex]=temp;
                startindex++;
                endindex--;
            }
            return input;
        }
    }
}
