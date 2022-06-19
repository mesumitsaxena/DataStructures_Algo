using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer.The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.

    //Increment the large integer by one and return the resulting array of digits.
    internal class Plus1
    {
        // This will have few edge cases-
        // if last digit is not 9 then we can directly add 1 to the number and send it back, becasue then there will be no carry thing
        // if last number is 9, then we might have to check every digit from right to left.
        // if last digit is 9, then afteradding 1 there will be carry 1, and if the next digit is also 9 then again carry will be 1 and so on
        // So we need to check every digit if last digit is 9.
        // for that if last digit is 9, we will initialize the carry with 1 and add it to the digit if it is greater than 9
        // then digit will be 0 and carry will be 1, if if it is not 10 it means there will be no carry just place the added digit
        // refer below code:
        // take example : 1 2 3 4, 1 2 3 9 and 9 8 9
        //https://leetcode.com/problems/plus-one/
        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length - 1;
            int length = digits.Length - 1;
            if (digits[n] < 9)
            {
                digits[n] += 1;
                return digits;
            }
            else
            {
                int carry = 1;
                while (length >= 0)
                {
                    int newValue = digits[length] + carry;
                    if (newValue > 9)
                    {
                        carry = 1;
                        digits[length] = 0;
                    }
                    else
                    {
                        digits[length] = newValue;
                        carry = 0;
                    }
                    length--;
                }
                if (carry == 1)
                {
                    int[] newOutput = new int[n + 2];
                    newOutput[0] = carry;
                    for (int i = 0; i < digits.Length; i++)
                    {
                        newOutput[i + 1] = digits[i];
                    }
                    return newOutput;
                }
                return digits;
            }
        }
    }
}
