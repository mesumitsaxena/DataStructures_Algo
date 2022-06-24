using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.Strings1
{
    //You are given a string A. Find the number of substrings that start and end with 'a'.
    //Example Input
    //Input 1:

    // A = "aab"
    //Input 2:

    // A = "bcbc"


    //Example Output
    //Output 1:

    // 3
    //Output 2:

    // 0


    //Example Explanation
    //Explanation 1:

    // Substrings that start and end with 'a' are:
    //    1. "a"
    //    2. "aa"
    //    3. "a"
    //Explanation 2:

    // There are no substrings that start and end with 'a'.
    internal class CountA
    {
        //count total number of a, then give the total substrings formed with count a.
        // if a is 3 then we can have
        // first a
        // second a
        // 3rd a
        // first a other elements second a
        // second a other elements third a
        // first a other elements second a other elements third a
        // so count of subtrings= count*count+1/2
        public int solve(string A)
        {
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 'a')
                {
                    count++;
                }
            }
            int substring = (count * (count + 1)) / 2;
            return substring;
        }
    }
}
