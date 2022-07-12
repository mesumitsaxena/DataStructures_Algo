using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Queue.Queue1
{
    //Problem Description
    //Given an array of integers A and an integer B, we need to reverse the order of the first B elements of the array, leaving the other elements in the same relative order.

    //NOTE: You are required to the first insert elements into an auxiliary queue then perform Reversal of first B elements.

    //Example Input
    //Input 1:

    // A = [1, 2, 3, 4, 5]
    //    B = 3
    //Input 2:

    // A = [5, 17, 100, 11]
    //    B = 2


    //Example Output
    //Output 1:

    // [3, 2, 1, 4, 5]
    //    Output 2:

    // [17, 5, 100, 11]


    //    Example Explanation
    //Explanation 1:

    // Reverse first 3 elements so the array becomes[3, 2, 1, 4, 5]
    //Explanation 2:

    // Reverse first 2 elements so the array becomes[17, 5, 100, 11]

    internal class ReverseQueue
    {
        // we have to first insert the elements in queue.
        // How can we reverse the elements in Queue?
        // Queue is FIFO, and want the reverse functionality means FILO or LIFO, who has this functionality?
        // Answer is STACK. So insert in stack and while popping insert in some list, which will be in reverse order.
        // but here we only have to reverse first B eleemnts.
        // So we will only insert first B elements in the queue.
        // Dequeue all the queue into a Stack.
        // replace the original array B values with stack.pop
        // example: 1, 2, 3, 4, 5 and B=3, we will add 1,2,3 into Queue.
        // Now dequeue the queue and insert into stack:
        /*
         * 3
         * 2
         * 1
         */
        // Now replace orginal array first B values from stack.pop
        // 3 will be palced at index 0 of orginal array : so 3 2 3 4 5
        // 2 will be placed at index 1 of original array : 3 2 3 4 5
        // 1 will be placed at index 2 of original array: 3 2 1 4 5, array is sorted now
        public List<int> solve(List<int> A, int B)
        {
            //Take the queue and insert first B elements
            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < B; i++)
            {
                queue.Enqueue(A[i]);
            }
            // Take Stack and Dequeue all elemetns in Stack
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }
            //copy back all stack elements in original array starting from index 0
            int j = 0;
            while (stack.Count > 0 && j < B )
            {
                A[j] = stack.Pop();
                j++;
            }
            // by above code, we are not taking extra array
            return A;
        }
    }
}
