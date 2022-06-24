using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.Strings1
{
    //Given two binary strings A and B, count how many cyclic permutations of B when taken XOR with A give 0.

    //NOTE: If there is a string, S0, S1, ... Sn-1 , then it is a cyclic permutation is of the form Sk, Sk+1, ... Sn-1, S0, S1, ... Sk-1
    //where k can be any integer from 0 to N-1.

    //Example Input
    //Input 1:

    // A = "1001"
    // B = "0011"
    //Input 2:

    // A = "111"
    // B = "111"


    //Example Output
    //Output 1:

    // 1
    //Output 2:

    // 3


    //Example Explanation
    //Explanation 1:

    // 4 cyclic permutations of B exists: "0011", "0110", "1100", "1001".  
    // There is only one cyclic permutation of B i.e. "1001" which has 0 xor with A.
    //Explanation 2:

    // All cyclic permutations of B are same as A and give 0 when taken xor with A.So, the ans is 3.


    internal class CyclicPermutation
    {
        // WHat is Cyclic Permutation?
        // abcde -> bcdea -> cdeab -> deabc -> eabcd -> abcde(this will not be included as it is orginal string).
        // above is cylcic permutation
        // So we need to check the each cyclic permutation and do ^ with A and if it is 0 then count++
        // Also we need to do it on binary strings.
        // Now we understood the cyclic permutation, lets understand how can we solve this.
        // do we create all permutation of B and then do A^permutations of B? No.
        // Suppose we have B= 01111 and A=11110,.
        // So Cyclic permuations are 01111 -> 11110 -> 11101 -> 11011 -> 10111 -> 01111
        // Here second cyclic permutation 11110 ^ A(11110) = 0. it means we need to check how many permutatons are same as A.
        // This is kind of String pattern matching-> 
        // How to generate permutations Just add B twice means B=B+B => if B=01111 then it will be 01111+01111 = 0111101111
        // by this we will generate cyclic permutation 01111 01111 and 0 11110 1111 and 01 11101 111 and 011 11011 11 etc
        // and if we want to check if any of the substring is equal to A then we can add A in the beggining
        // and Apply ZAlgo then count number of ZAlgo values which are equal to A's length then count++
        // example if B=01111 and A=11110 the S= 11110$0111101111, will do the seperator with $ so that we will always get length of A max if there is substring
        // Now there are two kind of values if A !=B above example is A!=B
        // another case is A==B, means A=11110 and B=11110, then if we create the string it will be 11110$1111011110
        // So when we create cyclic permutation, last permutation is always repeating the value B, example if B 011
        // then 011011 so last permutaiton is 011 for which we already calculated the Z Value and if A and B are same, then we might again count 
        // it szvalue in our answer as it will be 3 because when we match it will same,so for this case we will return one less value of count.
        // else we will return actual coutn value because if A is different, then B+B, even though we calculaye the zvalue of last permutation but 
        // if it is not equal to A, it will never will equal to A.Length so that is why we are not worried about it.
        // So if A==B then return count-1 else count
        // there is one more way to calculate which is Z[ZArrayLength-Alength]==Alength then count-1, it represent last permutation Zvalue
        // if last permutation Z value is Alength it means A and B are equal and we dont include this value 
        public int solve(string A,string B)
        {
            // Add B+B to create cyclic permution and append A to check if any permuation's pattern is same as A
            string newString = A + "$" + B + B;
            int length = newString.Length;
            // create Z Array
            List<int> Z = new List<int>();
            // first value will always be total length because maximum length of matching substring starting with index 0 array itself
            Z.Add(length);
            // define window or pink box values
            // Pink Box or window is the window containing same values as of substring starting with index 0
            int l = 0;
            int r = 0;
            // we already created 0th index value, lets start with index 0
            for(int i = 1; i < length; i++)
            {
                // if i is greater than r, it means we are outside window or pinkbox.
                // then we need to calculate its Zvalue with bruteforce.
                if (i > r)
                {
                    // initilize pink box sizes
                    l = i;
                    r = i;
                    // what will be window index values, l and r we know, but about first window?
                    // first window or pink box will always start from index 0 and last value will always be r-l, how?
                    // suppose l=9 and r=9, then corresponding value in first window will be r-l=9-9=0, right?
                    // because we always start checking the values from index 0.
                    while (r < length && newString[r] == newString[r - l])
                    {
                        // now if next value means r=10 equal to 10-9 which is equal to index 1 then expand window or pink box size, by r++
                        r++;
                    }
                    // once we found any element not equal to its corresponding value in first window, then we will calculate its Zvalue
                    // means pink box size or window size will be its length
                    Z.Add(r - l);
                    // while condition breaks when corresponding value is not equal, so r value is one step ahead, so keep it to one position back
                    r--;
                }
                // if i lies in between l and r (pink box) it means elements  till the pink box doesn't end will be same
                // as it corresponding values.
                else
                {
                    // now if its corresponding value which is i-l, because i lies in between l and r, so corresponding value of i will be i-l, how?
                    // if l=10 and i=12, then its corresponding value will be 12-10=2 which is correct
                    // so if corresponding value is less than rest of the window size, then copy the exact value
                    // because we know elements are same till r and its z value is also less than window size, means 
                    // number of same elements will be within window, so its safe to copy the value
                    if (Z[i - l] < r - i + 1)
                    {
                        Z.Add(Z[i - l]);
                    }
                    // else if value is greater than window size, it means we will take the value of rest of the window
                    // and expand the window until you can bruteforcly and calculate the new value
                    // we will create new window by placing l=i and r=r+1, keep checking
                    else
                    {
                        l = i;
                        r++;
                        while(r<length && newString[r]==newString[r - l])
                        {
                            r++;
                        }
                        Z.Add(r - l);
                        r--;
                    }
                }
            }
            int count = 0;
            // now iterate on Z array and see if any z value equal to A, means there is one permutation exist which is equal to A
            // So count++
            for(int i=0;i< Z.Count; i++)
            {
                if (Z[i] == A.Length)
                {
                    count++;
                }
            }
            // if A==B then last permutation value will be same as Alength, so count-1
            // we can also write the condition as if(A==B)
            if (Z[Z.Count - A.Length] == A.Length)
            {
                return count - 1;
            }
            return count;
        }
    }
}
