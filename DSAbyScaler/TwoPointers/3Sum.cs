using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given an array A of N integers, find three integers in A such that the sum is closest to a given number B.Return the sum of those three integers.

    //Assume that there will only be one solution.
    internal class _3Sum
    {
        // When we have to find the pair of sum equal to a number, then it is easy, if Array is sorted than fine, else sort the array
        // next just place two pointers on each corner and check sum, if it is equal than good, if it is greater than move to lesser element with given 
        // two pointers configuration, here lesser value can be found when we move right to left, because array is sorted
        // all sum is less than move left to right, that is basic two pointer problem

        // here there 2 Additions - 1. sum of triplet, 2. sum can be equal if not then given nearest sum possible.
        // lets discuss of triplet first - 1.) sum of triplet - > if we just fix 1 element then we can apply 2 pointer to check other two element
        // and check of each fixed element.
        // example: x+y+z and we want sum as B, desired output is X+Y+Z=B, so if we fix Z then desired output is X+Y=B-Z.
        // so we can fix Z by iterating on array one by one and calculate updated sum each time and check if it is equal to X+Y by two pointer
        // X+Y can be checked with two pointers
        public int threeSumClosest(List<int> A, int B)
        {
            //fix one index and apply difference of two numbers equal/closest to B
            //Array is not Sorted, so lets sort the Array
            A.Sort();
            //Take diff variable inorder to store minimum difference between the actual answer and the answer we got
            int diff = Int32.MaxValue;
            // store sum of all three chosen values
            int nearestSum = 0;
            // fix one element and apply two pointers on rest of the element on the right
            for (int i = 0; i < A.Count; i++)
            {
                // we ae taking range as i+1 to N because eventually we would be already checking the pairs before i with rest of the elements 
                int left = i + 1;
                int right = A.Count - 1;
                //X+Y+Z=B => So X+Y=B-Z=> So we just need to check X+Y which is equal to B-Z and
                // we are already iterating on Z 
                int sum = B - A[i];
                while (left < right)
                {
                    // Calculate minimum difference possible then only we could say nearest to a number
                    if (Math.Abs(A[left] + A[right] - sum) < diff)
                    {
                        diff = Math.Abs(A[left] + A[right] - sum);
                        nearestSum = A[left] + A[right] + A[i];
                    }
                    // if we found exact answer
                    if (A[left] + A[right] == sum)
                    {
                        return A[left] + A[right] + A[i];
                    }
                    //if sum of element is greater than what we require than choose the next lesser element
                    // we can only find lesser value from right to left  with given left and right configurations
                    else if (A[left] + A[right] > sum)
                    {
                        right--;
                    }
                    // if sum of element is lesser than choose the next greater element// we can only find greater element
                    // from left to right with given left and right configurations 
                    else
                    {
                        left++;
                    }
                }
            }
            // finally return the nearestsum
            return nearestSum;
        }   
    }
}
