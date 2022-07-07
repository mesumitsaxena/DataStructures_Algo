using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack1
{
    //You are given a string A.

    //An operation on the string is defined as follows:

    //Remove the first occurrence of the same consecutive characters.eg for a string "abbcd",
    //the first occurrence of same consecutive characters is "bb".

    //Therefore the string after this operation will be "acd".

    //Keep performing this operation on the string until there are no more occurrences of the
    //same consecutive characters and return the final string.
    //Example Input
    //Input 1:

    // A = abccbc
    //Input 2:

    // A = ab


    //Example Output
    //Output 1:

    // "ac"
    //Output 2:

    // "ab"
    internal class DoubleCharacterTrouble
    {
        //Simple solution can be considered as Stack.
        // We can see when same character occurs, remove that character completly.
        // So if we add a into stack, stack is empty so we can add it.
        // Now when B comes, we will check with stack top, the value is not same so add it
        // Now c comes value of top(b) is not same, so add it in stack top
        // Now c comes again, value of top(c) is same as incoming value, so remove top.
        // Now b comes, value of top(b) is same as incoming value, so remove top
        // Now c comes, value of top(a) is not same, so store it, now take all the chars and create a string in reverse manner
        // when we see string and some operation, we immediatly think of map/set, but here requirement is different.
        // here we have to remove the chars by checking the last occurance of the same char.
        // whenever we have to work or manupulate last occuring data, it means we have to use stack and last occur data will be top.
        public string solve(string A)
        {
            Stack<char> stack = new Stack<char>();
            for(int i = 0; i < A.Length; i++)
            {
                // if incoming char is same as top, pop the stack
                if(stack.Count>0 && stack.Peek() == A[i])
                {
                    stack.Pop();
                }
                //else add the char in stack
                else
                {
                    stack.Push(A[i]);
                }
            }
            // at the end no char will be double in that order in which they came, so pop the
            // elements and prepare the string
            StringBuilder correctString = new StringBuilder();
            while (stack.Count > 0)
            {
                correctString.Append(stack.Peek());
                stack.Pop();
            }
            return reverse(correctString);
        }
        public string reverse(System.Text.StringBuilder sb)
        {
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                sb1.Append(sb[i]);
            }
            return sb1.ToString();
        }
    }
}
