using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given a string B, find if it is possible to re-order the characters of the string B so that it can be represented as a concatenation of A similar strings.

    //Eg: B = aabb and A = 2, then it is possible to re-arrange the string as "abab" which is a concatenation of 2 similar strings "ab".

    //If it is possible, return 1, else return -1.
    //Example Input

    //Input 1:

    // A = 2
    // B = "bbaabb"
    //Input 2:

    // A = 1
    // B = "bc"


    //Example Output

    //Output 1:

    // 1
    //Output 2:

    // 1


    //Example Explanation

    //Explanation 1:

    // We can re-order the given string into "abbabb".
    //Explanation 2:

    // String "bc" is already arranged.
    internal class ReplicatingSubstring
    {
        // In Order to check if it is possible to create equal substring of size B
        // we need to check if any character's count is not multiple of B, then it is not possible
        // example: baabbbb, and B=2, then as we can see, we can create abbabb but still we left with 1 b
        // so it is never possible to create equal subtring if char count is not multiple of B
        public int solve(int A, string B)
        {
            Dictionary<int,int> charCount= new Dictionary<int,int>();
            for(int i = 0; i < B.Length; i++)
            {
                if (charCount.ContainsKey(B[i]))
                {
                    charCount[B[i]]++;
                }
                else
                {
                    charCount.Add(B[i], 1);
                }
            }
            foreach(var charcount in charCount)
            {
                if (charcount.Value % A > 0)
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
