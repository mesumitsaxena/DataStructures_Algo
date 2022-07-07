using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack1
{
    //Given an expression string A, examine whether the pairs and the orders of
    //“{“,”}”, ”(“,”)”, ”[“,”]” are correct in A.

    //Refer to the examples for more clarity.
    //Example Input
    //Input 1:

    // A = {([])}
    //Input 2:

    // A = (){
    //    Input 3:

    // A = ()[]


    //Example Output
    //Output 1:

    // 1
    //Output 2:

    // 0
    internal class ValidParenthisis
    {
        // we have to check if have valid parenthesis or not?
        // can we see some pattern in {([])}, we know this is valid, so when opening parenthisis comes
        // we can't make any decision, but when we have closing parenthesis, then we need to check.
        // Suppose we store { in something, then ( and then [ , now when } comes, if ] and ) is processed, then it is valid
        // but those were not processed then it is invalid, how do we check above condition? 
        // when } comes correspoding { should also come from DS. this looks like check the top value, so looks like a stack is going to use here.
       public bool checkOpeningBraces(char A)
        {
            switch (A)
            {
                case '(': return true;
                case '[': return true;
                case '{': return true;
                default: return false;
            }
        }
        //whenever we encountered with closing bracket, then it shoudl give me opening bracket.
        // so that we can check with stack's top
        public char getopeningbracket(char A)
        {
            switch (A)
            {
                case '}': return '{';
                case ')': return '(';
                case ']': return '[';
                default: return '0';
            }
        }
        public int solve(string A)
        {
            Stack<char> stack = new Stack<char>();
            for(int i = 0; i < A.Length; i++)
            {
                if (checkOpeningBraces(A[i]))
                {
                    stack.Push(A[i]);
                }
                else
                {
                    char backet = getopeningbracket(A[i]);
                    //if bracket matches then remove opening bracket
                    if(stack.Count>0 && stack.Peek() == backet)
                    {
                        stack.Pop();
                    }
                    // if stack is empty and we have closing bracket, means invalid bracket
                    else
                    {
                        return 0;
                    }
                }

            }
            //at the end if stack is not empty means parenthesis set is not balanced, so invalid
            if (stack.Count > 0) return 0;
            return 1;
        }
    }
}
