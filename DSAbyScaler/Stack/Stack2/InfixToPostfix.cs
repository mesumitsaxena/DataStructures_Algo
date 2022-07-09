using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack2
{
    //Problem Description
    //Given string A denoting an infix expression.Convert the infix expression into a postfix expression.

    //String A consists of ^, /, *, +, -, (, ) and lowercase English alphabets where lowercase English alphabets are operands and ^, /, *, +, - are operators.

    //Find and return the postfix expression of A.

    //NOTE:

    //^ has the highest precedence.
    // / and* have equal precedence but greater than + and -.
    //+ and - have equal precedence and lowest precedence among given operators.
    internal class InfixToPostfix
    {
        // we will use Stack here-
        // Here, store operators in stack and if operands comes then print or add into output array.
        // while inserting if stack top has operator with higher precendence than the operator which we are going to enter
        // then pop that element. else push the operator in stack.(if top has lower precedence)
        // we know brackets have highest precendence, So if opening bracket comes then push it in stack.
        // if we encountered ), then pop all operators till we get ( operator.
        public bool isOperand(char op)
        {
            if (op != '^' && op != '+' && op != '-' && op != '*' && op != '/' && op!='(' && op!=')')
            {
                return true;
            }
            return false;
        }
        public int getPrecedence(char op)
        {
            if (op == '^')
            {
                return 3;
            }
            else if (op == '*' || op == '/')
            {
                return 2;
            }
            else if (op == '+' || op == '-')
            {
                return 1;
            }

            return 0;
        }
        public string solve(string A)
        {
            Stack<char> operatorStack = new Stack<char>();
            List<char> output = new List<char>();
            for (int i = 0; i < A.Length; i++)
            {
                if (isOperand(A[i]))
                {
                    output.Add(A[i]);
                }
                else if (A[i] == '(')
                {
                    operatorStack.Push(A[i]);
                }
                else if (A[i] == ')')
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                    {
                        output.Add(operatorStack.Pop());
                    }
                    if (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                    {
                        return "Invalid Expression";
                    }
                    else
                    {
                        operatorStack.Pop();
                    }
                }
                else
                {
                    while (operatorStack.Count > 0 && getPrecedence(operatorStack.Peek()) >= getPrecedence(A[i]))
                    {
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(A[i]);

                }
            }
            while (operatorStack.Count > 0)
            {
                output.Add(operatorStack.Pop());
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < output.Count; i++)
            {
                stringBuilder.Append(output[i]);
            }
            return stringBuilder.ToString();
        }
    }
}
