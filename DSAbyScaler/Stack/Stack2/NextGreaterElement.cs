using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack2
{
    //Given an array A, find the next greater element G[i] for every element A[i] in the array.
    //The next greater element for an element A[i] is the first greater element on the right side of A[i] in the array, A.
    //More formally:

    //G[i] for an element A[i] = an element A[j] such that
    //    j is minimum possible AND
    //    j > i AND
    //    A[j] > A[i]
    //Elements for which no greater element exists, consider the next greater element as -1.
    //Example Input
    //Input 1:

    // A = [4, 5, 2, 10]
    //    Input 2:

    // A = [3, 2, 1]


    //    Example Output
    //Output 1:

    // [5, 10, 10, -1]
    //    Output 2:

    // [-1, -1, -1]
    internal class NextGreaterElement
    {
        // Refer the NearestSmallerElement problem to understand the concept.
        // in that question, we had to check previous smallest element and here we have to check next smallest element.
        // So we will start from last index and apply the same concept, here instead of checking if top is greater,
        // here we will check if top is smaller than current element, than remove the top, because we need greater than A[i] element.
        // lets see this in action.
        public List<int> nextGreater(List<int> A)
        {
            Stack<int> nearestGreaterStack = new Stack<int>();
            // taking an array as we have to iterate from right and store the answers as well from right.
            int[] result= new int[A.Count];
            for(int i = A.Count - 1; i >= 0; i--)
            {
                //remove the top if it is greater than current element.
                while(nearestGreaterStack.Count > 0 && nearestGreaterStack.Peek() <= A[i])
                {
                    nearestGreaterStack.Pop();
                }
                // if stack is empty means there are no elements which are greater than current element as we are deleting all the smaller elements in above while loop
                if (nearestGreaterStack.Count == 0) result[i] = -1;
                // if stack is not empty and all the top elements which are less than A[i] is also removed, means
                // we are left with greater element from A[i] and stack is ensuring that we are getting most latest greatest element
                // it means top is next greater element
                else
                {
                    result[i]=nearestGreaterStack.Peek();
                }
                //Add the element in stack.
                nearestGreaterStack.Push(A[i]);
            }
            return nearestGreaterStack.ToList();
        }
    }
}
