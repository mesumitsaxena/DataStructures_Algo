using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack2
{
    //Given an array A, find the nearest smaller element G[i] for every element A[i] in the array such that the element has an index smaller than i.

    //More formally,

    //G[i] for an element A[i] = an element A[j] such that

    //j is maximum possible AND

    //j < i AND

    //A[j] < A[i]

    //Elements for which no smaller element exist, consider the next smaller element as -1.
    //Example Input
    //Input 1:

    // A = [4, 5, 2, 10, 8]
    //    Input 2:

    // A = [3, 2, 1]


    //    Example Output
    //Output 1:

    // [-1, 4, -1, 2, 2]
    //    Output 2:

    // [-1, -1, -1]
    internal class NearestSmallerElement
    {
        // for each index we have to give the previous nearest smaller element.
        // for example 1: 4, 5, 2, 10, 8. for 4 there is nothing on left so will place -1
        // for 5, there is one value which is nearest smaller to 5 is 4
        // for 2, there is no element whihc is less than 2 so -1
        // for 10, there are many smaller elements like 4,5,2 but 2 is the nearest to 10 and also samller than 10. 
        // for 10 answer is 2 and for 8, smaller elements on left are 4,5,2 but 2 is nearest so answer is 2 again.

        // Approach 1: for every element, iterate from 0 to i-1 and check nearest(with respect of index) smaller element and update
        // // this will take O(N2) time complexity

        // Approach 2: Do you think any DS which can give you previously data in O(1) (this will be useful for nearest smaller element).
        // Stack is the DS which can give us previous data in O(1) by Top.
        // Now how do we find the previous smallest element? think in this way, we will only store smaller items till now
        // lets understand with example: 4, 5, 2, 10, 8. we will store 4 in stack
        // now 5 comes, we will check if stack top is less than current element, it means nearest smallest element is Stack Top, so we will print that value
        // we will keep that value in stack as it can be nearest smaller value for other elements as well.
        // Also insert 5 in stack as this value also can be nearest smallest element for other upcoming elements
        // now 2 comes, as we know from our example, for 2 answer is -1. there is no element which is smaller than this on left
        // So in stack we will compare current value with stack top, if top is smaller it means this is the nearest smaller for this 2.
        // but if it greater than we will pop this element, seriously pop? will this element in this case 5 never be used? 
        // it might be possible it can be nearest smaller element for any other element? is it? NO. 5 will never be nearest smaller element for any element on right
        // so it is safe to pop this element.
        // How? 5 can be smaller element for other elements on right but it will never be nearest smallest element.
        // As we encountered even more smaller element than 5 (2 in this case), so nearest smaller for other element will be this element(2)
        // and that is 5 is of no use now, so pop 5 out. Now compare top of stack (4) to 2, top is again greater than incoming element
        // So remove 4 from stack, now stack is empty So we can say there is no element which is less than 2 on left. so answer for 2 is -1
        // Also add 2 to the stack as this can be nearest smallest element for elements on right.
        // 10 comes, will check stack top(2) with 10, as top is smaller than incoming element, this is the smallest nearest element to 10
        // so add 2 to the answer and 10 to the stack. next 8 comes, check top(10) with 8, it is greater, so remove 10 from stack.
        // now check again top(2), with 8 its smaller so add 2 to the answer and add 8 in stack. Now list is completed.
        // So this is the best way to solve this question
        // time complexity: here we adding an element in stack once and removing the element once only.
        // So for any element top can be answer or not the answer, Also once we remove that element, we are not processing that element again.
        // So that is why TC: O(N) -which is iteration and inserting data in stack  + O(N) - worst case can be removing all the elements from stack
        // So overall O(N).
        public List<int> prevSmaller(List<int> A)
        {
            Stack<int> prevSmallestStack = new Stack<int>();
            List<int> result = new List<int>();
            for(int i = 0; i < A.Count; i++)
            {
                // remove the top which is greater than current element
                while(prevSmallestStack.Count>0 && prevSmallestStack.Peek() >= A[i])
                {
                    prevSmallestStack.Pop();
                }
                // if stack is empty means there is no element left smaller than A[i]
                // which means there is no element on left which is smaller than A[i]
                if (prevSmallestStack.Count == 0) result.Add(-1);
                else
                {
                    // as we already removed all the elements which are greater than A[i]
                    // and we also check stack is non empty so top of stack is smallest nearest element
                    result.Add(prevSmallestStack.Peek());
                }
                // Add the current element in the stack, as it can be previous smallest element on the right
                prevSmallestStack.Push(A[i]);
            }
            // return result
            return result;
        }
    }
}
