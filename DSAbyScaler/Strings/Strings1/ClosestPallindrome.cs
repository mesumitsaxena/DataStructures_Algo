using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.Strings1
{
    //Groot has a profound love for palindrome which is why he keeps fooling around with strings.
    //A palindrome string is one that reads the same backward as well as forward.

    //Given a string A of size N consisting of lowercase alphabets, he wants to know if it is possible
    //to make the given string a palindrome by changing exactly one of its character.

    //Example Input
    //Input 1:

    // A = "abbba"
    //Input 2:

    // A = "adaddb"


    //Example Output
    //Output 1:

    // "YES"
    //Output 2:

    // "NO"


    //Example Explanation
    //Explanation 1:

    // We can change the character at index 3(1-based) to any other character.The string will be palindromic.
    //Explanation 2:

    // To make the string palindromic we need to change 2 characters.
    internal class ClosestPallindrome
    {
        //we will check the pallindrome, by checking first and last character. if any point characters not matching means
        // we can replace any of them with other char, and count the replacement
        // if total count is 1 it means it is possible to create closest pallindrome
        public string solve(string A)
        {
            int count = 0;
            int left = 0;
            int right = A.Length - 1;
            while (left <= right)
            {
                if (A[left] != A[right])
                {
                    count++;
                }
                left++;
                right--;
            }
            // if string length is of even size and count is 0, it means string is already pallindrome.
            // if string is even, then we can not make next string pallindrome by changing only one char.
            if (A.Length % 2 == 0 && count == 0)
            {
                return "NO";
            }
            // if count is exactly 1, then retun true, Also
            // if count is 0, means it is already pallindrome and we already checked the condition for even then it will odd.
            // So if pallindromic string is odd, then we can get another pallindrome by changing middle eleemnt
            if (count <= 1)
            {
                return "YES";
            }
            // otherwise No
            return "NO";
        }
    }
}
