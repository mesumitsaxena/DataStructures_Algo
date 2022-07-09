using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack2
{
    //Given a 2D binary matrix of integers A containing 0's and 1's of size N x M.

    //Find the largest rectangle containing only 1's and return its area.

    //Note: Rows are numbered from top to bottom and columns are numbered from left to right.


    //Input Format

    //The only argument given is the integer matrix A.
    //Output Format

    //Return the area of the largest rectangle containing only 1's.
    //Constraints

    //1 <= N, M <= 1000
    //0 <= A[i] <= 1
    //For Example

    //Input 1:
    //    A = [   [0, 0, 1]
    //            [0, 1, 1]
    //            [1, 1, 1]   ]
    //Output 1:
    //    4

    //Input 2:
    //    A = [   [0, 1, 0, 1]
    //    [1, 0, 1, 0]    ]
    //Output 2:
    //    1
    internal class MaximumRectangle
    {
        // Here observation points are there can be zero's in between,
        // so if we try to build a Bar array like in histogram problem, how can we do that?
        // Suppose we create an Bar array adding all the column values, will it work? No, because possibilities are there must be zero in between.
        // and making an addition will include zero as well.
        // So above technique won;t work.
        // Lets discuss the next approach-
        // If we start from row=1, and calculate the area assuming we have only 1 row, create a seperate bar array and perform the action.
        // after move to row=2, and calculate the area for each bar assuming we have only row=1 and row=2.
        // here we will add the previous bar array values with current row and store in bar array, becasue we will performt the calculate area operation on bar array.
        // by this we will be able to make the bars.
        // points to be noted here, if current array has value 0, then we will not add 0 to bar array instead we will say bararray[k]=0. why?
        // it is because what ever bars we have created above had 1s that is why they have values and we were able to make bars.
        // now if there is 0 in current line, is this possible to make bar considering current line and index? no right.
        // So till this index if A[i][j]=0, then no bar for that index that is why bararray[k]=0

        // Summary: we will consider each row as bar array and calculate area.
        // while calculating area we will add previous bar array values.
        // if current value is 0 then we wont consider the current index as bar hence, mark bararray[k]=0.
        public int solve(List<List<int>> A)
        {
            // Prepare Bar Array array with size of the matrix columns
            int[] barArray = new int[A[0].Count];
            int maxArea = Int32.MinValue;
            for (int i = 0; i < A.Count; i++)
            {
                // for each column, we will check if current value is 1 then add the value in bararray
                for(int j=0;j< A[i].Count; j++)
                {
                    if(A[i][j] > 0)
                    {
                        barArray[j] += A[i][j];
                    }
                    // else reset it to zero, as by this index bar can't be formed
                    else
                    {
                        barArray[j] = 0;
                    }
                }
                // after bar array is ready, we will calculate lefMinArray and rightMinArray
                // So that we can get the index of nearest minimum element on left and right
                // and we will be able to calculate area out of it
                List<int> leftMinArray = leftMin(barArray.ToList());
                List<int> rightMinArray = rightMin(barArray.ToList());
                for (int k = 0; k < barArray.Length; k++)
                {
                    // calculate the area by (right-left-1)*element
                    int area = (rightMinArray[k] - leftMinArray[k]-1) * barArray[k];
                    // maintain maxArea
                    maxArea = Math.Max(area, maxArea);
                }

            }
            
            
            return maxArea;
        }
        public List<int> leftMin(List<int> input)
        {
            Stack<int> minLeftStack= new Stack<int>();
            List<int> output = new List<int>();
            for(int i = 0; i < input.Count; i++)
            {
                while(minLeftStack.Count>0 && input[minLeftStack.Peek()] >= input[i])
                {
                    minLeftStack.Pop();
                }
                if (minLeftStack.Count == 0) output.Add(-1);
                else output.Add(minLeftStack.Peek());
                minLeftStack.Push(i);
            }
            return output;
        }
        public List<int> rightMin(List<int> input)
        {
            Stack<int> minRightStack = new Stack<int>();
            int[] output = new int[input.Count];
            for(int i = input.Count - 1; i >= 0; i--)
            {
                while(minRightStack.Count>0 && input[minRightStack.Peek()] >= input[i])
                {
                    minRightStack.Pop();
                }
                if (minRightStack.Count == 0) output[i] = input.Count;
                else output[i]=minRightStack.Peek();
                minRightStack.Push(i);
            }
            return output.ToList();
        }
    }
}
