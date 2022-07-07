using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack2
{
    //Problem Description
    //Given an array of integers A.

    //A represents a histogram i.e A[i] denotes the height of the ith histogram's bar. Width of each bar is 1.

    //Find the area of the largest rectangle formed by the histogram.



    //Problem Constraints
    //1 <= |A| <= 100000

    //1 <= A[i] <= 1000000000



    //Input Format
    //The only argument given is the integer array A.



    //Output Format
    //Return the area of the largest rectangle in the histogram.



    //Example Input
    //Input 1:

    // A = [2, 1, 5, 6, 2, 3]
    //Input 2:

    // A = [2]


    //Example Output
    //Output 1:

    // 10
    //Output 2:

    // 2


    //Example Explanation
    //Explanation 1:

    //The largest rectangle has area = 10 unit.Formed by A[3] to A[4].
    //Explanation 2:

    //Largest rectangle has area 2.
    internal class LargestRectangleInHistogram
    {
        // We have to find the rectangle area.
        // if we can somehow find min value of bar on left and right for a particular bar, we will calculate the area.
        // we can say for a bar, find the nearest min bar on left and right, that would be the area we would like to consider
        // and area will be right-left-1, why -1, 
        // because we dont want to include the bars which are minimum.
        // we will use the same appraoch of nearest min element concept
        public List<int> leftMin(int[] input)
        {
            Stack<int> leftMinStack = new Stack<int>();
            List<int> output = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                while (leftMinStack.Count > 0 && input[leftMinStack.Peek()] >= input[i])
                    leftMinStack.Pop();
                if (leftMinStack.Count == 0) output.Add(-1);
                else output.Add(leftMinStack.Peek());
                leftMinStack.Push(i);
            }
            return output;
        }
        public List<int> rightMin(int[] input)
        {
            Stack<int> leftMinStack = new Stack<int>();
            int[] output = new int[input.Length];
            for (int i = input.Length - 1; i >= 0; i--)
            {
                while (leftMinStack.Count > 0 && input[leftMinStack.Peek()] >= input[i])
                    leftMinStack.Pop();
                if (leftMinStack.Count == 0) output[i] = input.Length;
                else output[i] = leftMinStack.Peek();
                leftMinStack.Push(i);
            }
            return output.ToList();
        }
        public int LargestRectangleArea(int[] heights)
        {
            List<int> leftMinArray = leftMin(heights);
            List<int> rightMinArray = rightMin(heights);
            int maxAnswer = Int32.MinValue;
            for (int i = 0; i < heights.Length; i++)
            {
                int val = rightMinArray[i] - leftMinArray[i];
                val = val * heights[i];
                maxAnswer = Math.Max(val, maxAnswer);
            }
            return maxAnswer;
        }
    }
}
