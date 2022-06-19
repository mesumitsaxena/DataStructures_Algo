using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given a string A consisting of lowercase characters.

    //Check if characters of the given string can be rearranged to form a palindrome.

    //Return 1 if it is possible to rearrange the characters of the string A such that it becomes a palindrome else return 0.
    //Example Input
    //Input 1:

    // A = "abcde"
    //Input 2:

    // A = "abbaee"


    //Example Output
    //Output 1:

    // 0
    //Output 2:

    // 1
    internal class CheckPallindrome2
    {
        // To check the pallindrome, there are 2 cases-
        // if length of string is even or odd.
        // if length of string is even, and all the characters count is even then we can form a pallindrome
        // example: aaaabb => aabbaa(pallindrome), aabb=>abba, aaaabbcc=>aabbccaa, so if length is even and all character count is even
        // then palindrome is possible
        // if length of string is odd, then there will different case, example:
        // aacbb= abcba, aaabb => ababa etc=> so here we can observer that if if length is Odd, there must be only one character
        // whose count should be odd, then pallindrome is possible
        // else pallindrome is not possible
        public int solve(string A)
        {
            Dictionary<char, int> frequencyMap = new Dictionary<char, int>();
            for(int i = 0; i < A.Length; i++)
            {
                if (frequencyMap.ContainsKey(A[i]))
                {
                    frequencyMap[A[i]]++;
                }
                else
                {
                    frequencyMap.Add(A[i], 1);  
                }
            }
            int numberofOdd = 0;
            //check number of odd elements in all frequecies
            foreach(var freq in frequencyMap)
            {
                if (freq.Value % 2 > 0)
                {
                    numberofOdd++;
                }
            }
            //check even case, if length is even and odd is 0 means frequencies are also even, then pallindrome possible
            if(A.Length%2==0 && numberofOdd == 0)
            {
                return 1;
            }
            //else check if length is odd and odd =1, means we only have 1 element whose frequency is odd, then
            //also pallindome is possible
            else
            {
                return 1;
            }
            // if these two condition doesn't satisfy then pallindrome is not possible
            return 0;
        }
    }
}
