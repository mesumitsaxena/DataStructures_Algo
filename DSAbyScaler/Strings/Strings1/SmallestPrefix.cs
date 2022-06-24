using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.Strings1
{
    //Given 2 strings A and B of size N and M respectively consisting of lowercase alphabets, find the lexicographically smallest string that can be formed by concatenating non-empty prefixes of A and B (in that order).
    //Note: The answer string has to start with a non-empty prefix of string A followed by a non-empty prefix of string B.
    //Example Input
    //Input 1:

    // A = "abba"
    // B = "cdd"
    //Input 2:

    // A = "acd"
    // B = "bay"


    //Example Output
    //Output 1:

    // "abbac"
    //Output 2:

    // "ab"


    //Example Explanation
    //Explanation 1:

    // We can concatenate prefix of A i.e "abba" and prefix of B i.e "c".
    // The lexicographically smallest string will be "abbac".
    //Explanation 2:

    // We can concatenate prefix of A i.e "a" and prefix of B i.e "b".
    // The lexicographically smallest string will be "ab".
    internal class SmallestPrefix
    {
        //we have to first add first char of A, so that output should not be empty
        // now just check if value is less than B's 1st value if yes add, if no, break and take the first char from B
        // because we need minimum number of chars.
        public string smallestPrefix(string A, string B)
        {
            string output = A[0].ToString();
            int n = A.Length;
            int m = B.Length;
            int i = 1;
            while (i < n)
            {
                if (A[i] < B[0])
                {
                    output = output + A[i];
                    i++;
                }
                else
                {
                    break;
                }
            }
            return output + B[0];
        }
    }
}
