using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.Strings1
{
    //You are given a string A of length N consisting of lowercase alphabets. Find the period of the string.

    //Period of the string is the minimum value of k(k >= 1), that satisfies A[i] = A[i % k] for all valid i.
    //Example Input
    //Input 1:

    // A = "abababab"
    //Input 2:

    // A = "aaaa"


    //Example Output
    //Output 1:

    // 2
    //Output 2:

    // 1


    //Example Explanation
    //Explanation 1:

    // Period of the string will be 2: 
    // Since, for all i, A[i] = A[i % 2].
    //Explanation 2:

    // Period of the string will be 1.
    internal class PeriodOfString
    {
        public List<int> CalculateZValues(string S)
        {
            
            string newString = S;
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
            for (int i = 1; i < length; i++)
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
                        while (r < length && newString[r] == newString[r - l])
                        {
                            r++;
                        }
                        Z.Add(r - l);
                        r--;
                    }
                }
            }
            return Z;
        }
        // Take some example: ababab, period of the string is 2. how? after 2 chars string is repeating
        // how to check that? it is like a string pattern matching righ?
        // So we will create Z Values. now we might thing value will repeat as 2, but no.
        // ababab index=2, Z value will be 4, how? because abab pattern is matching.
        // So how can we find the period?
        // see carefully, for i=2, z=4, for i=4, z=2 etc, so for a position if z value is rest of the element in the array
        // means rest of the values are same from beginning, and windows are overlapped and the index where it overlapped will be its period.
        // try with some example you will understand
        public int solve(string A)
        {
            List<int> zValue=CalculateZValues(A);
            for(int i = 0; i < zValue.Count; i++)
            {
                if (i + zValue[i] == zValue.Count)
                {
                    return i;
                }
            }
            // if there is no intersection it means whole string is period
            return zValue.Count;
        }
    }
}
