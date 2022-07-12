using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Queue.Queue1
{
    //Given an integer, A.Find and Return first positive A integers in ascending order containing only digits 1, 2, and 3.

    //NOTE: All the A integers will fit in 32-bit integers.
    //Example Input
    //Input 1:

    // A = 3
    //Input 2:

    // A = 7


    //Example Output
    //Output 1:

    // [1, 2, 3]
    //    Output 2:

    // [1, 2, 3, 11, 12, 13, 21]


    //    Example Explanation
    //Explanation 1:

    // Output denotes the first 3 integers that contains only digits 1, 2 and 3.
    //Explanation 2:

    // Output denotes the first 3 integers that contains only digits 1, 2 and 3.
    internal class NthNumberContains1or2or3
    {
        // first number is 1, next 2, next is 3, next 11, next 12, next 13, next 21, next 22, next 23, next 31.
        // So if we want 10th number which contains 1 or 2 or 3. is 31.
        // brute force is check each number starting from 1, and check if that number is contains 1 or 2 or 3 if yes then count++
        // now check if count=10 then return that number, ex: check for 1, count=1,then chec for 2, count=2, then check for 3, count=3, check for 4. no count increment, also 5 no count inc, 6 no count inc, 7, 8 and so on . and on 31 count will be 10 so return 31.
        // but this is very brute to our complier.

        // Optimize approach:
        // take 1, 2 and 3 and insert into queue, now take 1 from front, dequeue and then append 1, 2 and 3 after 1, means
        // 11, 12 and 13 and add these number to queue, now take 2 from front, dequeue and then 1, 2 and 3 after 2, means
        // 21, 22, 23 and insert into queue rear. and so on.
        // note: while inserting into queue check if the count of the number if it is N then return that number.
        public List<int> solve(int A)
        {
            Queue<int> nNumberQueue = new Queue<int>();
            int count = 0;
            List<int> output = new List<int>();
            for(int i = 1; i <= 3; i++)
            {
                // Add the elements (1,2,3) in queue
                nNumberQueue.Enqueue(i);
                //increment the count, so that if A= 1 or 2 we can return the list
                count++;
                // add (1,2,3) in output, as we have to return this output
                output.Add(i);
                // if count is equal to Ath number, then return the list
                if (count == A)
                {
                    return output;
                }
            }
            while (count != A)
            {
                // Dequeue front(ex: dequeue 1 and then make combinations as 11, 12, 13
                int number=nNumberQueue.Dequeue();
                for(int i = 1; i <= 3; i++)
                {
                    // insert combinations with dequeue element and isnert in queue
                    // how to make combiantion: example: dequeue element is 1, then 1*10+1, 1*10+2, 1*10+3
                    nNumberQueue.Enqueue(number * 10 + i);
                    // add combination which is made in output, as we have to return this output
                    output.Add(number * 10 + i);
                    //increment the count, so that if any point of time count beocmes A, then return
                    count++;
                    if (count == A)
                    {
                        return output;
                    }

                }
            }
            return output;
        }
    }
}
