using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.StringsWithHashSet_Map
{
    //Given a string A and a string B, find the window with minimum length in A, which will contain all the characters in B in linear time complexity.
    //Note that when the count of a character c in B is x, then the count of c in the minimum window in A should be at least x.

    //Note:

    //If there is no such window in A that covers all characters in B, return the empty string.
    //If there are multiple such windows, return the first occurring minimum window (with minimum start index and length )
    //Example Input
    //Input 1:

    // A = "ADOBECODEBANC"
    // B = "ABC"
    //Input 2:

    // A = "Aa91b"
    // B = "ab"


    //Example Output
    //Output 1:

    // "BANC"
    //Output 2:

    // "a91b"


    //Example Explanation
    //Explanation 1:

    // "BANC" is a substring of A which contains all characters of B.
    //Explanation 2:

    // "a91b" is the substring of A which contains all characters of B.
    internal class WindowString
    {
        // Basic intituion is clear that we need to use hashmap, inorder to store the freq and check the freq and element in A string.
        // So here we will have two pointer approach. we know inorder to get minimum length string, two elements which exist in B, will be at boundry of substring of A
        // head will denote the left boundry and tail will denote right.
        // upcoming element is denoted as right boundry as tail.
        // Now if the tail doesn't exist in the map, means it is not part of string B, so we will just increase the tail pointer
        // because this might the elemnt which comes in between the elements which we want.
        // Another thing is if head is also on element which doesn't exist in map, then increase head as this is not part of map and we know to form a valid substring an element should be at edge which exist in map
        // now if tail exist in map, then decrease freq in map, because we found the elemnt, increase length which indicate we found 1 more element from B
        // now if length becomes equal to length of B, it means all the elements which is required to form a valid substring in A now found.
        // here in order to minimize the length, we will check if head pointer contains the element which exist in B and its freq is -ve.
        // if the freq is -ve it means we have access of that element, so we should leave this element by increasing head pointer and incresing the freq in map as well.
        // because this element just left.
        // also check the length if new lenght is smaller than consider that
        public string minWindow(string A, string B)
        {
            if (A.Length < B.Length)
                return "";
            // define two pointers
            int head = 0;
            int tail = 0;
            // length of elements which exist in B, initilize it by 0 and when we found the element in B, increase the count
            // which indicate this many elements are found
            int length = 0;
            // in order to calculate minimum window length
            int windowLength = 0;
            // global minimum window start point
            int gl = 0;
            // prepare map, to store the element and frequency of string B, so that we can compare how many elements are covered in B
            // if element found in B, will decrease the count in map, which will indicate, we require one less freq of this element
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            for (int i = 0; i < B.Length; i++)
            {
                if (freqMap.ContainsKey(B[i]))
                {
                    freqMap[B[i]]++;
                }
                else
                {
                    freqMap.Add(B[i], 1);
                }
            }
            //while tail is less than A length
            while (tail < A.Length)
            {
                // if tail doesnt exist in map, means it doesnt exist in B, so we will not care and increase the tail which means include
                // this element in window, why? there is possibilty say B= ABC, and string is ADFBCEFG, so valid string is ADFBC, so here, D and F are not
                // // part of B, but inorder to find valid substring, we will include it
                if (!freqMap.ContainsKey(A[tail]))
                {
                    tail++;
                    continue;
                }
                // if tail exist in map, remove the freq by 1 as we foudn the element
                freqMap[A[tail]]--;
                // if freq is >=0 then length++, why >=0, if freq is less than 0 it means, this element already exist and extra of them also came into window
                // so we still didn't got all the elements, example: B: ABC, A= AABDC, A came so freq[A]-- and length =1, then again A came, so freq[A]--, but length is not 2
                // because length will come 2 when B or C came into window
                if (freqMap[A[tail]] >= 0)
                {
                    length++;
                }
                // once we found all the elements from B
                if (length == B.Length)
                {
                    // Check if head is not part of B,then we will exclude this element.
                    // Also if head eleemnt exist in map but its freq is -ve, means this is the extra element
                    // we are about to leave this element so increase the count in map
                    while (!freqMap.ContainsKey(A[head]) || freqMap[A[head]] < 0)
                    {
                        // if the eleemnt is extra , suppose ADBAC and B=ABC, so when tail is at A and head is at A, means
                        // window is ADBA, this contains extra A, so we will say we got the next A, so head you can leave this first A
                        // So we will increase the freq of A, so that we can do the calculation right
                        if (freqMap.ContainsKey(A[head]))
                        {
                            freqMap[A[head]]++;
                        }
                        // if DSFABC and B: ABC, suppose head is at 0th position, So D is not part of map, so leave this element, as this element is of no use 
                        head++;
                    }
                    // check if window size is less than previous size
                    if (windowLength == 0 || windowLength > tail - head + 1)
                    {
                        // update length
                        windowLength = tail - head + 1;
                        //update start point
                        gl = head;
                    }
                }
                tail++;

            }
            return A.Substring(gl, windowLength);
        }
    }
}
