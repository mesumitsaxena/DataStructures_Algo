using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack2
{
    //An arithmetic expression is given by a character array A of size N.Evaluate the value of an arithmetic expression in Reverse Polish Notation.

    //Valid operators are +, -, *, /. Each character may be an integer or an operator.
    //Example Input
    //Input 1:
    //    A =   ["2", "1", "+", "3", "*"]
    //    Input 2:
    //    A = ["4", "13", "5", "/", "+"]


    //    Example Output
    //Output 1:
    //    9
    //Output 2:
    //    6
    internal class EvaluateExpression
    {
        // Basically expression is given in postfix and we need to calculate the value of the expression.
        // In order to calculate the postfix expression, we will use stack.
        // if top is operand, push the values in stack, and when operator comes, pop last values from stack.
        // perform operation on last two values and push it back into stack.
        // and continue this until list is iterated completly.
        public int evalRPN(List<string> A)
        {
            Stack<string> postfixStack = new Stack<string>();
            for(int i=0;i<A.Count; i++)
            {
                if(A[i]!="+" && A[i]!="-" && A[i]!="*" && A[i] != "/")
                {
                    postfixStack.Push(A[i]);
                }
                else
                {
                    if (A[i] == "+")
                    {
                        int val1 = int.Parse(postfixStack.Pop());
                        int val2=int.Parse(postfixStack.Pop());
                        int result = val1 + val2;
                        postfixStack.Push(result.ToString());
                    }
                    else if (A[i] == "-")
                    {
                        int val1 = int.Parse(postfixStack.Pop());
                        int val2 = int.Parse(postfixStack.Pop());
                        int result = val1 - val2;
                        postfixStack.Push(result.ToString());
                    }
                    else if (A[i] == "*")
                    {
                        int val1 = int.Parse(postfixStack.Pop());
                        int val2 = int.Parse(postfixStack.Pop());
                        int result = val1 * val2;
                        postfixStack.Push(result.ToString());
                    }
                    else if(A[i] == "/")
                    {
                        int val1 = int.Parse(postfixStack.Pop());
                        int val2 = int.Parse(postfixStack.Pop());
                        int result = val1 / val2;
                        postfixStack.Push(result.ToString());
                    }
                }
            }
            if (postfixStack.Count > 0) return int.Parse(postfixStack.Peek());
            return 0;

        }
    }
}
