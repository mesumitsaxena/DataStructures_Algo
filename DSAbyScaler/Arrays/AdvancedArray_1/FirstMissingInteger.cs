using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray_1
{
    //Given an unsorted integer array, A of size N. Find the first missing positive integer.
    //Note: Your algorithm should run in O(n) time and use constant space.
    internal class FirstMissingInteger
    {
        // In best case scenario, Array will have numbers from 1 to number of elements say n. so we will always search the numbers from 1 to n
        // There are many ways, Brute Force is start the loop from 1 to number of elements, find i each time, when i not found in A, return i O(N2)
        // Another way is Sort the Array and start and iterate the loop from positive number, if i!=A[i], then return i
        // Another way is take count array, and filled its index as true whenever recieved positive number from 1 to N
        // Now iterate the count array check which one is false, return that index.
        // All above cases will either have time complexity as NLogN, or Space Complexity as N
        // Optimize approach - Swap the numbers to its corresponding position. example if the number is 2 on 0th index 
        // then it should be swapped at index (2-1)=1. but then stay at 0th index untill 0th index doesn't get 1 or the number
        // which we are trying to fill can not be moved.(refer FirstMissingInteger.png) 
        public int firstMissingPositive(List<int> A)
        {
            // Swapping Approach-

            int i = 0;
            while (i < A.Count)
            {
                // If element is not in range between 1 to N, just pass
                if (A[i]<=0 || A[i]>A.Count)
                {
                    i++;
                }
                else
                {
                    //Find the right position, Example: 2 3 1 => 2 should be at index 1, so right position is A[i]-1 which is 2-1=1
                    int rightposition = A[i]-1;
                    // if A[i] is not at right position than swap, but do not increment i, because ith elemnt is moved
                    // current position, but we also need to check the element which came after swapping at ith position is 
                    // at current index or not, and we will only move forward until it is moved to current position
                    // or rightposition is already having correct number
                    if (A[rightposition] != A[i])
                    {
                        int temp = A[i];
                        A[i] = A[rightposition];
                        A[rightposition] = temp;
                        
                    }
                    // if A[i] is at right position than move to increment i
                    else
                    {
                        i++;
                    }
                }
            }
            // Now all numbers are swapped and kept at right position, iterate and if index value+1 is not equal to 
            // number at that index then return index
            for(int j =0; j < A.Count; j++)
            {
                if (j + 1 != A[j])
                {
                    return (j + 1);
                }
            }
            return A.Count - 1;

            // Count Array way
            /*bool[] countarr = new bool[A.Count];
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] > 0 && A[i] <= A.Count)
                {
                    countarr[A[i] - 1] = true;
                }
            }
            int j = 0;
            for (j = 0; j < countarr.Length; j++)
            {
                if (countarr[j] == false)
                {
                    return j + 1;
                }
            }
            return j + 1;*/

            // Sorting way
            /*A.Sort();
            int index=0;
            while(index < A.Count && A[index]<=0){
                index++;
            }
            int i=index;
            for(i=index;i<A.Count;i++){
                int val=(i-index)+1;
                if(A[i]!=val){
                    return val;
                }
            }
            return (i-index)+1;*/
        }
    }
}
