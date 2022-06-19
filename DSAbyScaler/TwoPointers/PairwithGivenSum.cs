using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given a sorted array of distinct integers A and an integer B,
    //find and return how many pair of integers(A[i], A[j] ) such that i != j have sum equal to B.
    internal class PairwithGivenSum
    {
        // So we can use two pointers technique. But where can I put my two pointers.
        // Should I keep them as 0,0 or 0,1 or both pointers at end or middle. lets see,
        // please make a note that array is sorted
        // if we keep both pointers at starting, suppose p1=0, p2=1, then if we make a sum, we will compare it with B
        // if sum is lesser than B, it means we need to move to the element which is greater, p1 and p2 both can move to right to get greater element
        // but we can not move both elements, because it is possible that p1 can make a combination with other element on right, so we cant skip it
        // So we are not able to make concrete decision here.
        // if sum is smaller than B, both p1 and p2 can move backwards to get smaller elements, same ambiguity came.
        // but if we place 1 pointer at startiing point p1 on smaller elment side and p2 at end (greater element side).
        // I think we can make a decision there, how?
        // if sum of p1 and p2 is greater than B, we need to move to the smaller element so that we get lesser sum, we can say we will move p2 to right
        // because currently p2 is at maximum element, and if smaller element is giving greater sum with maximum element, it means
        // this p2(max element) can not make a pair with any other element, so we will skip this element and p2--
        // if sum of p1 and p2 is smaller than B, it means we need to add little greater elements, from where we can add greater elements?
        // from starting, because p1 is smallest element and if it is giving smaller sum with maximum element than it cannot give sum with any other element
        // because they will be more smaller than max element, so p1++
        public int solve(List<int> A, int B)
        {
            // Initialize P1 and p2
            int l = 0;
            int r = A.Count - 1;
            int count = 0;
            while (l < r)
            {
                // if we found the sum, than count++ 
                // and look for sum with other elements
                if (A[l] + A[r] == B)
                {
                    count++;
                    l++;
                    r--;
                }
                // if sum is greater, move p2--
                else if (A[l] + A[r] > B)
                {
                    r--;
                }
                // if sum is lesser, move p1++
                else if (A[l] + A[r] < B)
                {
                    l++;
                }
            }
            return count;
        }
    }
}
