using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Queue.Queue1
{
    //A CPU has N tasks to be performed.It is to be noted that the tasks have to be completed in a specific order to avoid deadlock. In every clock cycle, the CPU can either perform a task or move it to the back of the queue. You are given the current state of the scheduler queue in array A and the required order of the tasks in array B.

    //Determine the minimum number of clock cycles to complete all the tasks.
    //Example Input
    //Input 1:

    //A = [2, 3, 1, 5, 4]
    //    B = [1, 3, 5, 4, 2]
    //    Input 2:

    //A = [1]
    //    B = [1]


    //    Example Output
    //Output 1:

    // 10
    //Output 2:

    // 1


    //Example Explanation
    //Explanation 1:

    //According to the order array B task 1 has to be performed first, so the CPU will move tasks 2 and 3 to the end of the queue(in 2 clock cycles).
    //Total clock cycles till now = 2
    //Now CPU will perform task 1.
    //Total clock cycles till now = 3
    //Now, queue becomes[5, 4, 2, 3]
    //Now, CPU has to perform task 3. So it moves tasks 5, 4, and 2 to the back one-by-one.
    //Total clock cycles till now = 6
    //Now all the tasks in the queue are as in the required order so the CPU will perform them one-by-one.
    //Total clock cycles = 10
    //Explanation 2:

    //Directly task 1 is completed.
    internal class TaskScheduler
    {
        // we will first of all insert every A iterm in Queue, because when the task number comes at B, we have to move
        // All the task before the current task in A to end of the list.
        // So basically first list A represents the task lists.
        // B represents the order of the task in which it needs to be executed.
        // So from B we will determine when to execute that task.
        //example: A = [2, 3, 1, 5, 4]
        //    B = [1, 3, 5, 4, 2]
        // So B will tell that first task which needs to be executed is 1 and second task would be 3.
        // Now in order to execute the task 1, we need to move 2,3 at the nack of the list of A. etc
        // what is the best DS we know which can take the element from the front and add them in rear?
        // Queue.
        // lets see the code in action
        public int solve(List<int> A, List<int> B)
        {
            // first insert the elements of A in Queue
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < A.Count; i++)
            {
                queue.Enqueue(A[i]);
            }
            // take the count and increment the count when moving elements to the rear
            int count = 0;
            // Now iterate on B to know the order of the tasks.
            for (int i = 0; i < B.Count; i++)
            {
                while (queue.Peek() != B[i])
                {
                    // take the front and insert at rear till front not equal to B[i]
                    queue.Enqueue(queue.Dequeue());
                    //increment the count as moving one element at end, take 1 unit
                    count++;
                }
                // when front equal to B[i], then remove the front as task is completed.
                queue.Dequeue();
                // when task is done, it will also take 1 unit
                count++;
            }
            return count;
        }
    }
}
