using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings.StringsWithHashSet_Map
{
    //You are given two strings, A and B, of size N and M, respectively.
    //You have to find the count of all permutations of A present in B as a substring.
    //You can assume a string will have only lowercase letters.
    //Example Input
    //Input 1:

    // A = "abc"
    // B = "abcbacabc"
    //Input 2:

    // A = "aca"
    // B = "acaa"


    //Example Output
    //Output 1:

    // 5
    //Output 2:

    // 2


    //Example Explanation
    //Explanation 1:

    // Permutations of A that are present in B as substring are:
    //    1. abc
    //    2. cba
    //    3. bac
    //    4. cab
    //    5. abc
    //    So ans is 5.
    //Explanation 2:

    // Permutations of A that are present in B as substring are:
    //    1. aca
    //    2. caa
    internal class PermutationofAinB
    {
        // we want to check if A present in B in any of the permutation form or not?
        // example: abc, permutation of abc will be abc, bca, cab, bac, acb, cba etc.
        // now second string B can have any of the permutation of A in B, so how can we check.
        // we can take help of hashset/map, insert all members of A in map.
        // iterate on the B for the window of size length of A, and if the element exist in map, remove the element
        // when window finishes, if map/set is empty it means permutation of A in B exist.
        // it is a Sliding window technique
        // Lets understand with an example: A=abc, B= bacabdcab.
        // insert all elements in map of A, then iterate on the first window of B of size of A length. so length of A is 3
        // we will iterate on the first window of length 3, i=0, B[0]=b, b exist in map so remove it
        // B[1]=a, a exist in map so remove it, B[2] =c, c exist in map so remove it
        // after removing we can see map or set is empty so yes permutaion of A exist in B
        // now we have to find the count of permutation exist in B.
        // we will check each window and if size of map is 0 then count++
        // so whenever we are removing the element in window, we will add the element in the map, lets understand this in different manner
        // if an element is leaving the window and element is in the map means this element is the part of A, and if the element is leaving the window
        // means we have to increase the need in the map then only when the next element which comes in window, we can cancel out from map and make our answer 0.
        // now when any element is coming into window and it is available in the map, means this element is part of A.
        // we will decrease the freq of map so that we can see if the there is freq of all element is 0 means permutation exist
        // lets understand with example:
        // A=abc, B= bacabdcab., insert A into map, and take variable need=length of A(number of elements required to match with permuation)
        // now iterate on first window(size=3) on B, first element is b, b exist in map, so decrease the freq in map also decrease the need=need-1
        // becasue we got 1 element which exist in A.
        // now next element is a, this also exist, decrease in map, decrease need variable, need=need-1, need=1,(means we need 1 element to match the permutation of A in B)
        // next element is c, again match, decrease in map, decrease in need variable=> need=0, window is also completed
        // so need =0(means all the need is fulfill) means A exist in B, count++
        // now for next window, b is going out, so we will increase the requirement in need, so need=1, also increase the freq of b to +1, so that we can cancel it out when next b comes in window
        // now next element which is coming in the window is a, same operation which we were doing before, decrease the freq of a in map, and decrease the need.
        // but here a is already in the window, so there are 2 a in the window, and freq of a will be -1, as we need only 1 a, here we have 2, so we will not decrease our need.
        // so whenever there is freq which is less than 0 then need will not decrease
        // Also when there is freq which is less than 0 then will not increase the need also in case of element is going out of window.
        // because if freq is negative, in case of removing element from window also, means there are still same element exist in window, so need cannot be increased.
        // need will only increment or decrement if the freq is +ve or 0.

        // CRUX:
        // if element is going out of window and it exist in map means it is part of A. So as it is going out of window
        // we will increase the freq and need, becasue we need that eleemnt in the window to form permutation of A
        // if eleemnt is coming in window and it exist in map means it is part of A. So as it is coming in the window
        // we will decrease the freq and need, becasue we got the element in the window which can form permutation of A
        public int solve(string A, string B)
        {
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            //requirement of the characters needed to form a permutation of A
            int need = A.Length;
            int windowSize = A.Length;
            int countofPermutation = 0;
            //create a freq map from A
            for(int i=0;i< windowSize; i++)
            {
                if (freqMap.ContainsKey(A[i]))
                {
                    freqMap[A[i]]++;
                }
                else
                {
                    freqMap.Add(A[i], 1);
                }
            }
            //create first window and check how many elements matched from map
            for(int i = 0; i < windowSize; i++)
            {
                //if and only if element from B exist in freqMap(in A)
                if (freqMap.ContainsKey(B[i]))
                {
                    //reduce the freq, because we got the element, even if it is negative, it indicates we have extra element in window
                    freqMap[B[i]]--;
                    // if freq is +ve then reduce the need as well, because we go the element, so we need one less elements in the window
                    // if it is negative, means we have extra elements(same element) in window, so need is already decreased at first occurance of element
                    // so no need to reduce the need
                    if (freqMap[B[i]] >= 0)
                    {
                        need--;
                    }
                }
            }
            //if need is 0 , means all the requirement got fulfil, so increase the count
            if (need == 0) countofPermutation++;
            // check for next window
            for(int i = windowSize; i < B.Length; i++)
            {
                //check for char which is going out
                char charGoingOut = B[i - windowSize];
                //if it exist in map, means it is part of A, so increase the need of it.
                if (freqMap.ContainsKey(charGoingOut))
                {
                    // we will check the freq is greater than 0 because if it is 0 means we got the requirement of this element and there is no requirement
                    freqMap[charGoingOut]++;
                    // if freq is not negative, then only increase the need, i.e if freq is negative means few elements are repeating
                    // in the window which are not required to form permutation of A, so we will not increase need
                    if (freqMap[charGoingOut] > 0)
                    {
                        need++;
                    }

                }
                char incomingChar = B[i];
                // if incoming element in the window is exist in the map, means it is part of A.
                //so decrease the need.becasue we got the element in the window which can form permutation of A
                if (freqMap.ContainsKey(incomingChar))
                {
                    freqMap[incomingChar]--;
                    // if freq is not negative, then only decrease the need, i.e if freq is still negative means few elements are still repeating
                    // in the window which are not required to form permutation of A, so we will not decrease need as we already decreased the need
                    // for this once in previous iterations
                    if (freqMap[incomingChar] >= 0)
                    {
                        need--;
                    }
                }
                if (need == 0) countofPermutation++;
            }
            return countofPermutation;
        }
    }
}
