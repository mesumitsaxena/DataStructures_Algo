using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.StringsWithHashSet_Map
{
    //You are given a string A of lowercase English alphabets. Rearrange the characters of the given string A such that there is no boring substring in A.

    //A boring substring has the following properties:

    //Its length is 2.
    //Both the characters are consecutive, for example - "ab", "cd", "dc", "zy" etc.(If the first character is C then the next character can be either(C+1) or(C-1)).
    //Return 1 if it is possible to rearrange the letters of A such that there are no boring substrings in A else, return 0.
    //Example Input
    //Input 1:

    // A = "abcd"
    //Input 2:

    // A = "aab"


    //Example Output
    //Output 1:

    // 1
    //Output 2:

    // 0


    //Example Explanation
    //Explanation 1:

    // String A can be rearranged into "cadb" or "bdac" 
    //Explanation 2:

    // No arrangement of string A can make it free of boring substrings.
    internal class BoringSubstring
    {
        //Crux of the question says, no odd chars or no even chars should be togther.
        // so first solution is, arrange all the odd characters at one string or array, and all even chars in another array or string
        // then check the char of odd string with all the char with even string if any of the char is not giving char=char+1,
        // then yes we can make string which is not boring.

        // another solution is find the max and min odd elements in the string. Also find the max and min even elements in the string.
        // now if any of the combination is forming a diff greater than 1 means they can form a string which is not boring
        // if any of the combination not forming means what?
        // smallest odd and largest even not forming means? there are only 1 element in odd and 1 eleemnt in even they are adjecent
        // example: ab (ab, ba) cant find anystring which is not boring, smallest odd a, largest even b
        // smallest even and largest odd not forming means? same thing as above
        // example: bc (bc cb) cant make any string which is not boring
        // smallest even and smallest odd not forming? same thing, smallest even and largest even are same, or smallest odd and largest odd are same
        // largest even and largest odd not forming? same thing.
        // so which thing will not fail?
        // example smallest even and largest odd is forming, example : odd: ace, even : bd, so we can form with a nd d togther, so ceadb
        // example smallest odd and largest even is forming, example: odd: ace, even: bd, so we can form bdace
        // smallest even with smallest odd, example: odd: ace, even: df, so we can form ceadf
        // largest even with largest even with largest odd, example: ace, even: dh, so acehd
        // if apart from above conditions not forming, means it cannot form
        // possible cases are, smallest even with largest odd, both are far away, if not matching means they are next to each other and smallest adn largest are same
        // smallest odd with smallest even, means we have elements in odd that is why smallest odd and smallest even are far away
        // largest odd with largest even, means we have elements in even that is why largest odd and largest even and far away
        public int solve(string A)
        {
            //prepare odd and even lists
            List<char> oddList = new List<char>();
            List<char> evenList = new List<char>();
            for(int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    evenList.Add(A[i]);
                }
                else
                {
                    oddList.Add(A[i]);
                }
            }
            int smallestOdd = Int32.MaxValue;
            int largestOdd = Int32.MinValue;
            //find smallest odd and largest odd
            for(int i = 0; i < oddList.Count; i++)
            {
                smallestOdd=Math.Min(smallestOdd, oddList[i]);
                largestOdd=Math.Max(largestOdd, oddList[i]);
            }
            int smallestEven = Int32.MaxValue;
            int largestEven = Int32.MinValue;
            for(int i = 0; i < evenList.Count; i++)
            {
                smallestEven = Math.Min(smallestEven, evenList[i]);
                largestEven=Math.Max(largestEven, evenList[i]);
            }
            //example smallest even and largest odd is forming, example: odd: ace, even: bd, so we can form with a nd d togther, so ceadb
            if (Math.Abs(smallestEven - largestOdd) > 1)
            {
                return 1;
            }
            // smallest even with smallest odd, example: odd: ace, even: df, so we can form ceadf
            else if (Math.Abs(smallestEven - smallestOdd) > 1)
            {
                return 1;
            }
            // largest even with largest even with largest odd, example: ace, even: dh, so acehd
            else if (Math.Abs(largestOdd - largestEven) > 1)
            {
                return 1;
            }
            // example smallest odd and largest even is forming, example: odd: ace, even: bd, so we can form bdace
            else if (Math.Abs(smallestOdd - largestEven) > 1)
            {
                return 1;
            }
            return 0;
        }
    }
}
