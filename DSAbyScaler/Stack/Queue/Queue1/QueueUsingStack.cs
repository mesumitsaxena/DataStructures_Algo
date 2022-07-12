using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Queue.Queue1
{
    //https://leetcode.com/problems/implement-queue-using-stacks/
    //we know in Queue follows FIFO, means if we have to delete the element we have to delete the element which was added first
    // or we can say we have to delete from front.
    // Queue - front => 1,2,3,4,5,6 <= rear. here front is 1 and rear is 6, so if we have to add more elements, we have to add from rear.
    // and to delete the element we have to delete from front.

    // In order to implement Queues, we need 2 Stacks.
    // 1st stack will keep the reference of rear
    // 2nd stack will keep the reference of front
    // when we add the element we will add the element from the rear and rear is represented by stack1.
    // when we have to delete the element, we have to delete the element deep in the stack, the element which was added first in the stack.
    // but we dont have access to the first element, in stack we only have the access of TOP, then how can we do that?
    // we will have another stack. when delete is requested, move all the elements from stack 1 to stack 2.
    // Now stack 2 top has the first element which was added first in stack1, so we can delete itby pop stack 2.
    // Suppose multiple operations are happening.
    // we inserted 5 elements and now we want to delete, So we will mpve all 5 elements to stack2 and delete the top in stack 2
    // now we want to delete 3 more elements, as stack2 represents front and it has elements, we can pop from stack 2.
    // Now suppose we again added 5 elements, so it will be added at rear means stack1.
    // So stack 1 has 5 elements and stack 2 has 1 element left.
    // Now we want to delete 3 more element, what will happen?
    // we will delete 1 element from stack2, but when we want to delete next 2 elements, than there is no element left in stack2.
    // So we will again move all the elements from stack 1 to stack 2 and perform the action.
    // we will apply same concept for peek as well, peek will be given by front, but if stack 2 is empty then move all elements from stack 1
    // and give top of stack 2, if stack 1 is also empty then return -1

    internal class QueueUsingStack
    {
        Stack<int> stack1;
        Stack<int> stack2;

        public QueueUsingStack()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void Push(int x)
        {
            stack1.Push(x);
        }

        public int Pop()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            if (stack2.Count > 0)
            {
                return stack2.Pop();
            }
            return -1;
        }

        public int Peek()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            if (stack2.Count > 0)
            {
                return stack2.Peek();
            }
            return -1;
        }

        public bool Empty()
        {
            if (stack1.Count == 0 && stack2.Count == 0)
            {
                return true;
            }
            return false;
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */

}
