using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack1
{
    //Given a stack of integers A, sort it using another stack.

    //Return the array of integers after sorting the stack using another stack.
    //Example Input
    //Input 1:

    // A = [5, 4, 3, 2, 1]
    //    Input 2:

    // A = [5, 17, 100, 11]


    //    Example Output
    //Output 1:

    // [1, 2, 3, 4, 5]
    //    Output 2:

    // [5, 11, 17, 100]
    internal class SortStackusingAnotherStack
    {
        // we can use 2 stacks here, so what we can do here is keep the first stack data in ascending order(higher at bottom and lower at top)
        // because then while adding in list will be easier for us
        // we will take of second stack in order to sort the data and we might have to store the data somewhere to sort the data in 1st stack
        // example: 5, 17, 100, 11. so in first stack data should be like
        /*
         * 5
         * 11
         * 17
         * 100
         */
        // So when 5 comes stack 1 is empty so we can store the data in stack 1, now 17 comes. if we store the data in stack 1, 11 will come on top of 5
        // this is what we dont want, so here 2nd stack will be helpful.
        // we will pop 5 and store it in 2nd stack then store 17 in 1st stack. now copy back the all the data from stack 2 to stack1
        // 100 comes, again same situation. 5 is smaller than 100, copy to stack 2, 17 is smaller than 100 copy to stack 2
        //now add 100 in stack 1 and copy all the eleemnts from stack 2 to 1
        // 11 comes, 5 is smaller than 11, so pop and push in stack 2, 17 is greater than 11, so dont do anything
        // push 11 and copy back 5 from stack 2 to stack 1. done
        public List<int> solve(List<int> A)
        {
            Stack<int> sortStack = new Stack<int>();
            Stack<int> helpingStack = new Stack<int>();
            for(int i = 0; i < A.Count; i++)
            {
                // remove the data from stack 1 to stack 2 if required
                while(sortStack.Count>0 && sortStack.Peek() < A[i])
                {
                    helpingStack.Push(sortStack.Pop());
                }
                // add the required data in stack 1.
                // this will work in both cases, if incoming element is greater than stack top, then above while loop
                // will add it in anotehr stack and add the data in stack 1 by below code,
                // if not then above while loop will not work and still current element will be added in stack 1 by below code
                sortStack.Push(A[i]);
                // if second stack has some element means we have done some shuffle, so add the eleemnt back in stack 1
                while (helpingStack.Count > 0)
                {
                    sortStack.Push(helpingStack.Pop());
                }
            }
            // Add all the data in list
            List<int> result = new List<int>();
            while (sortStack.Count > 0)
            {
                result.Add(sortStack.Pop());
            }
            //return list
            return result;
        }
    }
}
