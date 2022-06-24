using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.StringsWithHashSet_Map
{
    //Given a string A, find the length of the longest substring without repeating characters.

    //Note: Users are expected to solve in O(N) time complexity.
    //Example Input
    //Input 1:

    // A = "abcabcbb"
    //Input 2:

    // A = "AaaA"


    //Example Output
    //Output 1:

    // 3
    //Output 2:

    // 2


    //Example Explanation
    //Explanation 1:

    // Substring "abc" is the longest substring without repeating characters in string A.
    //Explanation 2:

    // Substring "Aa" or "aA" is the longest substring without repeating characters in string A.
    internal class LongestSubstringwithoutRepeat
    {
        //Solution is below-
        // maintain two pointer left and right, which will tell us the range, starting point will be 0 for both.
        // we will move right pointer and will keep left if we found any duplicate
        // if element not exist in set, add the element in set and increase r++
        // if element exist in set, then there are many cases,
        // 1.) element s[r] might be s[l]
        // 2.) element s[r], can be any element between s[l] and s[r]
        // so for 1st point directly remove s[l].
        // but for point 2, we will remove every element till the duplicate element is not removed from the set
        // by this we will always have unique element range.
        // example : abcdcbadgh - so will add abcd, now c comes, now l=0 and r=4, so will remove s[l] from set and l++
        // do nogt increment r++, so again try if s[r] still exist in set, it means it is not yet removed from set and can be further ahead that is why we are doing l++
        // keep on deleting the elements untill you found the duplicate, once we found, remove it and then add rth element
        public int LengthOfLongestSubstring(string s)
        {
            if (s == "") return 0;
            HashSet<int> duplicateSet = new HashSet<int>();
            int l = 0;
            int r = 0;
            int maxCount = Int32.MinValue;
            while (r < s.Length)
            {
                // if element exist in set, delete the element and l++, for next check
                if (duplicateSet.Contains(s[r]))
                {
                    duplicateSet.Remove(s[l]);
                    l++;
                }
                // if not then add the element and r++
                else
                {
                    duplicateSet.Add(s[r]);
                    r++;
                }
                // check for max count
                maxCount = Math.Max(maxCount, duplicateSet.Count);
            }
            return maxCount;
        }
    }
}
