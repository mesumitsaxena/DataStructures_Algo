using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Queue.Queue1
{
    //Given an integer A, you have to find the Ath Perfect Number.

    //A Perfect Number has the following properties:

    //It comprises only 1 and 2.

    //The number of digits in a Perfect number is even.

    //It is a palindrome number.

    //For example, 11, 22, 112211 are Perfect numbers, where 123, 121, 782, 1 are not.
    //Example Input
    //Input 1:

    // A = 2
    //Input 2:

    // A = 3


    //Example Output
    //Output 1:

    // 22
    //Output 2:

    // 1111


    //Example Explanation
    //Explanation 1:

    //First four perfect numbers are:
    //1. 11
    //2. 22
    //3. 1111
    //4. 1221
    //Explanation 2:

    //First four perfect numbers are:
    //1. 11
    //2. 22
    //3. 1111
    //4. 1221
    internal class PerfectNumber
    {
        // Can you observe the pattern, for any pallidrome number, it is of two parts aa`.
        // if we somehow generate a, can't we generate a`? we can right, as we have to generate pallindrome?
        // Just reverse the string and append into a.
        // example: we have to find 1st digit, we know 1st digit which contains 1 or 2 is 1 and its reverse is also 1, so append 1 with 1 =11
        // if we have to find 3rd? how can we generate first half?
        // its same as NthNumberContains1or2or3 question, but here we have only 2 numbers instead of 3.
        // So just generate the numbers till count becomes A and then reverse the number and append with original and return.
        public string solve(int A)
        {
            Queue<string> queue = new Queue<string>();
            int count = 0;
            for(int i = 1; i <= 2; i++)
            {
                // Add the elements (1,2) in queue
                queue.Enqueue(i.ToString());
                //increment the count, so that if A= 1 or 2 we can return the current value+reverse of current value
                count++;
                // if count is equal to Ath number, then current value + reverse of current value
                if (count == A)
                {
                    return i.ToString() + i.ToString();
                }
            }
            while (count != A)
            {
                // Dequeue front(ex: dequeue 1 and then make combinations as 11, 12)
                string front = queue.Dequeue();
                for(int i = 1; i <= 2; i++)
                {
                    // insert combinations with dequeue element and isnert in queue
                    // how to make combiantion: example: dequeue element is 1, then 1*10+1, 1*10+2, 1*10+3
                    // as we are working with strings here so adding number at the end easy by just +
                    string output = front + i.ToString();
                    queue.Enqueue(output);
                    //increment the count, so that if any point of time count beocmes A, then return
                    // current value + reverse of current value
                    count++;
                    if(count == A)
                    {
                        // output is current value
                        char[] reverse = output.ToCharArray();
                        Array.Reverse(reverse);
                        // and reverse is reverse of current value
                        return output + new string(reverse);
                    }
                }
            }
            return "1";
        }
    }
}
