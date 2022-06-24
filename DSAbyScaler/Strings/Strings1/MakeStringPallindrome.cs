using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.Strings1
{
    //Given a string A of size N consisting only of lowercase alphabets. The only operation allowed is to insert characters in the beginning of the string.

    //Find and return how many minimum characters are needed to be inserted to make the string a palindrome string.

    //Example Input
    //Input 1:

    // A = "abc"
    //Input 2:

    // A = "bb"


    //Example Output
    //Output 1:

    // 2
    //Output 2:

    // 0


    //Example Explanation
    //Explanation 1:

    // Insert 'b' at beginning, string becomes: "babc".
    // Insert 'c' at beginning, string becomes: "cbabc".
    //Explanation 2:

    // There is no need to insert any character at the beginning as the string is already a palindrome.
    internal class MakeStringPallindrome
    {
        // Basic bruteforce way is remove the last element and check if the string is pallindrome or not?
        // then again remove last element and check if the string is pallindrome or not, remove the last element untill you dont fidn the pallindrome
        // whenever you remove element from last count++ and when we found string which is pallindrome number of elements to remove is answer means count
        // ex: abc, remove c, count=1, => ab (string is not pallindroem), remove b, count=2=> a(string is pallindrome)
        // So answer is 2, how? number of elements to be removed will be the elements required to make the string pallindrome
        // in above example: abc, we removed b and c and if append c and b in the beggining it will be pallindrome
        // also stop removing the elements when it is already pallindrome, so we only required number of elements from last which needs to be removed until it is not a pallindrome(so that when we add it becomes pallindrome)
        // example: babac, so we know bab is pallindrome, so if remove ca from and (so that if add in beggining becomes pallindrome).
        // we add ca in beghining it will become pallindrome, how do we get this?
        // we will remove the element c from end and check if it becomes pallindrome, no its not , so remove b, now it is pallindrome
        // so that is why we are using this approach of removing from end.
        // but hecking if string is pallindrome or not after removing element from end gives us O(N^2) time compexity

        // Use of KMP algo approach. using LPS(longest prefix which is also a suffix)
        // So if we know somehow longest prefix length which is also a suffix it means that is pallindrome.
        // example : babac, bab is prefix and bab is also a suffix(suffix is also left to right)
        // example of prefix and suffix: s= abcdea, so prefix will be a ab abc abcd abcde abcdea, suffix will be a, ea, dea, cdea, bcdea, abcdea(left to right)
        // after checking max length of prefix which is also a suffix. it means that is pallindromic length.
        // So in order to get the elements which needs to be added to form pallindrome will be => total length of string - longest prefix length which is also suffix(pallindromic length)
        // how do we check that in given string.
        // So we know pallindrome will formed from prefix(beggining) side after removing elements from end.
        // So we will add string and reverse of string using seperater(why seperator? so that there will no overlap answer considered)
        // why reverse? so that we will get to know about the suffix and if suffix is same as prefix it means it is pallindromic
        // example : babaa$aabab, we know bab and reverse of bab is same so prefix is bab which is also suffix so that is why reverse.

        // how do we calculate prefix which is also suffix?
        // create an array, take first pointer at index 0 and second pointer at 1, if A[i] ==A[j], then j=i+1, and i++ and j++
        // if i and j not matched, then i=LPA(i-1) and check again, if i==0 then A[i]!=A[j] then j++
        // how are we calculating above thing and how it is calculting length of prefix which is suffix
        // when A[i]==A[j] then j=i+1, which means length of prefix till i(elements are same till i)
        // and if they are not same, then move i to LPA[i-1], why?
        // As i represnts prefix till i and j represents suffix till j, so if say not matching it means we have already checked LPA
        // and we know how many chars are matching in LPA, so reset to LPA[i-1] because 0 to i-2 chars might be same
        public int solve(string A)
        {
            char[] charA = A.ToCharArray();
            Array.Reverse(charA);
            string s = A + "$" + new string(charA);
            int[] LPA = new int[s.Length];
            LPA[0] = 0;
            int i = 0;
            int j = 1;
            while (j < s.Length)
            {
                // if i and j match then assign LPA[j]=i+1, give the value of prefix length which is also a suffix till now, how?
                // example: abcdabc, suppose i=0 and j=4, so A[i]=A[j]=a, so till j=4, prefix which is also a suffix is 'a'
                // and its length is 1 (i=0+1)=1,now i=1 and j=5 still matching means lpa[j]=i+1, 2 and we can see ab(0 to 1) is
                // matching with ab(4 to 5). so prefix is ab(01) and suffix is ab(45) which is same, so length is 2.
                // 2 is not kind of length but gives the location or index till when the strings are matching so till index i-1 strings are matching
                // and we check with prefix and i is prefix.
                // check for next match, so i++, j++
                if (s[i] == s[j])
                {
                    LPA[j] = i + 1;
                    i++;
                    j++;
                }
                // if it is not matching
                else
                {
                    // if i=0, we can not go before 0 so assign 0 to lpa and check for next char, j++
                    if (i == 0)
                    {
                        LPA[j] = 0;
                        j++;
                    }
                    //if A[i]!=A[j], then reset i till which strings were matching and that was till i-1, (that is how we are skipping comparing whole string)
                    // so that is why i=LPA[i-1]
                    else
                    {
                        i = LPA[i - 1];
                    }
                }
            }
            // we will get the value of longest prefix which is suffix at last index because we have reversed the string 
            // and we know pallindrome will always be formed from beginning of the original string which means end of reversed string
            // so we got to know the prefix which is also suffix length so subtract it with original string length and we have our count.
            return A.Length - LPA[LPA.Length - 1];
        }
        // we can also do this using ZAlgo, in Zalgo we will create z values which will tell number of elements which are same from prefix
        // So we will find max number in the zalgo, which will tell us length of elements which are same and after reversing if same eleemnts length is coming, then max 
        // length will be pallindromic length
    }
}
