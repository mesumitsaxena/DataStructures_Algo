using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Sorting.Sorting3
{
    internal class QuickSort
    {
        // So the idea is, we will keep all the smaller values on left and higher on right, how?
        // by swapping 1st value of the array to its correct index, how do we do that?
        // Fix the 0th index of array and take two pointers, p1 and p2, p1 will be pointing to 1st index and p2 will point to last index
        // now if A[p1] is less than A[0], it means A[p1] is on left side so all ok, then check A[p2] is greater than A[0], then also it is ok
        // because we wanted to move greater element than A[0] to its right.
        // but if A[p1] is greater than A[0] or A[p2] is smaller than A[0] it means they are not on the correct position, so lets swap them.
        // once p1 reaches out of p2, swap the 0th index element to p1-1, because after breaking the loop, p1 will be 1 position ahead.
        // So by this 0th index element is reached to its correct position, how can we do it for all?
        // As the 0th index reached to its correct position, lets break the array from where we know the element is correctly placed.
        // which is p1-1, index p1-1 will have 0th index element, so we will break the array from 0 to p1-2 and p1 to p2.
        // Apply same concept on those arrays again
        // So first place 0th index at correct positon.
        // break the array from the element which is placed at correct places
        // Apply same for left and right array
        // Concept is same like merge Sort, there we have merge function, here we are rearranging, so rearrange method
        // So order will be
        // index=reArrange(A,l,r)
        // quicksort(A, l, index-1)
        // quicksort(A, index+1, r)
        public List<int> solve(List<int> A)
        {
            quicksort(A, 0, A.Count - 1);
            return A;
        }

        private void quicksort(List<int> A, int left, int right)
        {
            if (left >= right) return;
            int placedIndex = reArrange(A, left, right);
            quicksort(A, left, placedIndex - 1);
            quicksort(A, placedIndex + 1, right);
        }

        private int reArrange(List<int> A, int left, int right)
        {
            //start with next index as we want to place left index at correct position
            int p1 = left + 1;
            int p2 = right;
            while (p1 <= p2)
            {
                // if value of p1 is lesser than A[left] or A[0] it means A[p1] is on right side of A[left]'s correct position
                // so A[p1] is also on correct position
                if (A[p1] < A[left])
                {
                    p1++;
                }
                // if value of p2 is greater than A[left] or A[0] it means A[p2] is on right side of A[left]'s correct position
                // so A[p2] is also on correct position
                else if (A[p2] > A[left])
                {
                    p2--;
                }
                // if value of A[p1] is greater than A[left] means it is not at correct position, it should be on right so swap it with A[p2]
                // if value of A[p2] is less than A[left] means it is not at correct position, becasause A[left]'s correct position will have
                // greater element on right of it and lesser elements at left of it.
                else
                {
                    int temp = A[p1];
                    A[p1] = A[p2];
                    A[p2] = temp;
                    p1++;
                    p2--;
                }
            }
            // at last just place A[left] at correct position which is p1-1, because when the loop breaks, p1 will be 1 step ahead
            int temp1 = A[left];
            A[left] = A[p1 - 1];
            A[p1 - 1] = temp1;
            return p1 - 1;
        }
    }
}
