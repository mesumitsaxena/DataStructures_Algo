using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given an one-dimensional integer array A of size N and an integer B.
    //Count all distinct pairs with difference equal to B
    //Here a pair is defined as an integer pair(x, y), where x and y are both numbers in the array and their absolute difference is B.
    // if there duplicate values then only unique pair will be counted
        //    Input 1:

        // A = [1, 5, 3, 4, 2]
        // B = 3
        //Input 2:

        // A = [8, 12, 16, 4, 0, 20]
        // B = 4
        //Input 3:

        // A = [1, 1, 1, 2, 2]
        // B = 0


        //Example Output
        //Output 1:

        // 2
        //Output 2:

        // 5
        //Output 3:

        // 2
    internal class PairWithGivenDifference
    {
        // We will definetly use two pointer technique as questions says given pair
        //only thing is placing our pointers right
        // to get the difference, we will have to put the pointers on index 0 and 1, then only we can make a concrete 
        // decision where to go if difference is large or small.
        // if the difference is smaller than B, then we have to increase the difference, how can we increase the diff?
        // As the array will be sorted, if we increase right pointer we will move to larger values and larger value with smaller value will give larger difference
        // So we can say we go farthest to achieve more difference
        // if the difference is greater than move left pointer because we move close to p2, difference will decrease.
        // how this works, if diff is smaller, we move p2 to right, why p2? because p2 as larger element is giving difference smaller with smallest elemetn(p1)
        // then it can not give larger difference with any other element on left, becasue if we move left, difference will decrease more, so we will increase 
        // Also if we increase p1 then also diff will decrease
        // and same with p1 as well
        public int solve(List<int> A, int B)
        {
            // define two pointers
            int left = 0;
            int right = 1;
            // suppose B =-5, will this matter if we have pair as 15, 20 or 20, 15, its same right, so that is why
            // we will sort the array and always assume, difference is positive
            A.Sort();
            B=Math.Abs(B);
            int count = 0;
            // while right doesn't reach till end go ahead, left will never reach till end before right
            // you can see in below code
            while(right< A.Count)
            {
                // if we found the exact difference
                if (A[right] - A[left] == B)
                {
                    // if we have duplicate then we will only count the pair once
                    // so consider the element as once and increase the count also, move to the next distinct element
                    // from either side either from left or right
                    int leftElement = A[left];
                    while(left<A.Count && leftElement == A[left])
                    {
                        left++;
                    }
                    int rightElement=A[right];
                    while(right<A.Count && rightElement == A[right])
                    {
                        right++;
                    }
                    count++;
                }
                // if difference is greater, decrease the difference, increase left pointer
                // means move to greater element from left so that we will get less difference
                else if(A[right]-A[left] > B)
                {
                    left++;
                    // if after moving left pointer left and right becomes same, we will increase right pointer//
                    // because we are considering distinct pair, 5-5=0 is not allowed if 5 is same element
                    // Also there might be issues if left pointer passes right pointer, because then left will point two
                    // greater element and right will point to smaller
                    if (left == right)
                    {
                        right++;
                    }
                }
                // if difference is smaller, increase the difference, increase right pointer
                // means move to greater eleemnt from right so that we will get greater difference
                else if (A[right] - A[left] < B)
                {
                    right++;
                }
            }
            return count;
        }
    }
}
