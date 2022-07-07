using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack1
{
    //Design a stack that supports push, pop, top, and retrieve the minimum element in constant time.
    //push(x) -- Push element x onto stack.
    //pop() -- Removes the element on top of the stack.
    //top() -- Get the top element.
    //getMin() -- Retrieve the minimum element in the stack.
    //NOTE:
    //All the operations have to be constant time operations.
    //getMin() should return -1 if the stack is empty.
    //pop() should return nothing if the stack is empty.
    //top() should return -1 if the stack is empty.
    //Example Input

    //Input 1:
    //push(1)
    //push(2)
    //push(-2)
    //getMin()
    //pop()
    //getMin()
    //top()
    //Input 2:
    //getMin()
    //pop()
    //top()
    //Example Output

    //Output 1:
    // -2 1 2
    //Output 2:
    // -1 -1
    //Example Explanation

    //Explanation 1:
    //Let the initial stack be : []
    //1) push(1) : [1]
    //2) push(2) : [1, 2]
    //3) push(-2) : [1, 2, -2]
    //4) getMin() : Returns -2 as the minimum element in the stack is -2.
    //5) pop() : Return -2 as -2 is the topmost element in the stack.
    //6) getMin() : Returns 1 as the minimum element in stack is 1.
    //7) top() : Return 2 as 2 is the topmost element in the stack.
    //Explanation 2:
    //Let the initial stack be : []
    //1) getMin() : Returns -1 as the stack is empty.
    //2) pop() :  Returns nothing as the stack is empty.
    //3) top() : Returns -1 as the stack is empty.
    internal class MinStack
    {
        // how to start,  we can maintain a single variable getminimum and when we or push the data in stack, will update
        // the variable. example: data is 4 6 3 2 10, so after pushing 4, getmin variable will have 4, now pushing 6, getmin will remain 4
        // inserted 3, getmin will update it will be 3, and so on.
        // what is the issue, suppose we pop the element at some point.
        // suppose we have to data like 4 6 3 pop 10 2 pop, so insert 4, get min =4
        // insert 6, get min=4
        // insert 3, get min=3,
        // now pop, 3 will be remove, now if someone ask what is minimum in the stack, we will say 3
        // but 3 is not even exist. we can say, after removing top will be prev min, so getmin=4, lets proceed and see if this is valid or not.
        // insert 10, get min=4.
        // insert 2, getmin=2.
        //pop, 2 will be removed, now as per our logic top will be assigned to getmin, so top is 10.
        // so is getmin=10 a valid statement? no, right
        // So above approach is not valid.

        //Approach 1: we can take help of another stack- when we insert the data in stack 1, we will insert the min value till now in stack 2
        // example:
        // insert 4 in s1, till now 4 is the min, so insert 4 in s2.
        // insert 6 in s1, still 4 is minimum, how do we check, check incoming element and top of s2, minimum of that will insert in s2.
        // insert 3 in s1, min(4,3)=3, store 3 stack .
        // pop, remove top from both s1 an s2, now s1.top=6 and s2.top=4, so by this we will be able to find the minimum value
        // at every point.

        //Approach 2: can we do this with O(1) space complexity?
        // Yes but this includes some mathematical formula.
        // Lets understand the approach. in order to have O(1) space, we still need some place to store the min? and a variable can
        // give O(1) space. So we will have a getMin variable to store the currentgetMin.
        // So what about the issue when we pop the element, how do we get the last min?
        // here, we will use below approach-
        // we will store the first element as it is and update the getmin variable as well with that value
        // then when next element which comes is less than currrent min, here we will not store the incoming value, isntead we will store 2*incoming value-currentMin.
        // if the incoming element has greater value then we will store the as it is value, why? becasue then our current min will never change
        // why storing 2*x-currmin? this value will always be less than current min, so when we pop and top is less than current min
        // then we can guess and say here is something wrong here and current min needs to change, because if current min is greater than top after pop
        // than how current min is greater, it should be this value. So by storing 2*x-currentmin we are giving indication that here current min needs to change
        // how do we get prev min? it will be 2*current_min-top

        Stack<int> minStack;
        int curr_Min;

        public MinStack()
        {
            minStack = new Stack<int>();
            curr_Min = Int32.MaxValue;
        }

        public void Push(int val)
        {
            //if value is not first value and it is less than curr_min, then we will store a manuplilated value here
            // which will be 2*val-curr_min
            // and curr min will val because val was less than curr_Min
            if (minStack.Count > 0 && val < curr_Min)
            {
                int newValue = (2 * val) - curr_Min;
                minStack.Push(newValue);
                curr_Min = val;
            }
            else
            {
                // if it is first value and then assign curr_min = first value
                if(minStack.Count == 0)
                {
                    curr_Min = val;
                }
                minStack.Push(val);
                
                
            }
        }

        public void Pop()
        {
            //pop only when stack is non empty
            if (minStack.Count > 0)
            {
                // if top is less than curr_min, it means something is fishy, because curr_min should be min, if top is min
                // curr_min should capture it, and if it is minimum it means this is the manipulated value which we stored while pushing
                // and when we pop, curr_min should be changed to 2*curr-top
                if (minStack.Peek() < curr_Min)
                {
                    curr_Min = (2 * curr_Min) - minStack.Peek();
                }
                minStack.Pop();
            }
        }

        public int Top()
        {
            // if stack is non empty then only give the top value
            if (minStack.Count > 0)
            {
                // if top is less than curr_min, it means manupilated value is stored here
                // so top will curr_min, because while pushing, if value was less than curr_min then
                // we stored the manipulated value in stack and value was stored in curr_min as it was min
                // So top will be curr_min
                if (minStack.Peek() < curr_Min)
                {
                    return curr_Min;
                }
                // if top is greater means top is actual value so return it directly
                else
                {
                    return minStack.Peek();
                }
            }
            return -1;
        }

        public int GetMin()
        {
            // if minstack is non empty then only return curr_min
            if (minStack.Count > 0)
            {
                return curr_Min;
            }
            return -1;
        }
    }
}
