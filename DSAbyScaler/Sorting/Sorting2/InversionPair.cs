using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Sorting.Sorting2
{
    //Given an array of integers A.If i<j and A[i]> A[j], then the pair (i, j) is called an inversion of A.
    //Find the total number of inversions of A modulo (109 + 7).
    internal class InversionPair
    {
        // Brute force Approach - check for every pair if i<j and A[i]>A[j] incremenet the count - O(N^2) Approach
        // Two for loops i and j - j starting with i, so that we dont have to check i<j, we can directly check A[i]>A[j]
        // Optimize Approach - Concept of Merge Sort
        // Divide the array in two parts -> Somehow sort both the arrays now set start the pointer for both the array at initial index
        // check if A[p1]>A[p2] it means we have a pair so count ++.
        // Also we will sort the array(why sorting?  will explain in a while.) in temp array by checking if A[p1]<=A[p2] then we will directly place the element from p1 and put it in temp array
        // but do not increment count because its not a inversion count. 
        // If A[p1]>A[p2] - if that is the case and we know both the arrays are sorted, it means A[p2] will be smaller with all the elements on the left array(p1 wala array)
        // So count will be count=count+(m-p1) here m is seperator between array 1 and array 2.
        // Now to answer the previous question why are we sorting? remember we are appying this concept on 2 arrays which we somehow sorted.
        // So this is the way we sorted and will use it further, 
        // So basically we will be breaking the array in half untill we have 1 element left and will apply above concept on two elements.
        // Count the number of pairs on left half and right half(which will be initially 0 in case of 1 element) and then count to merge the two sorted list
        // Kind of Carry forward while taking the count forward
        // So basic 4 steps,
        // step 1: break the array in 2 halfs untill it is possible
        // step 2: count inversion pair on left side, while counting sort the left side
        // step 3: count inversion pair on right side, while counting sort the right side
        // step 4: count inversion pairs among left and right side of array by merging them, also while counting, sort the array
        // continue the process
        public int InversionCount(List<int> A)
        {
            return Inversion(A, 0, A.Count - 1);
        }
        public int Inversion(List<int> A, int l, int r)
        {
            int mod = 1000000007;
            //Base condition
            // when we are left with single element after breaking into half, number of count will be 0,
            // becasue we cant make the comparison with any one to check A[i]>A[j]
            if (l == r) return 0;
            // Calculate Middle
            int mid = (l + r)/2;
            // Do a recursive calls to calculate left side count.(eg. left side we have 2 elements so, we will calculate
            // count of inversion pairs of two elements with Merge function(recursivly) and it will give us the count
            // Note: this will be sorted
            int countfromleft = Inversion(A, l, mid);
            // Do a recursive calls to calculate right side count.(eg. right side we have 2 elements so, we will calculate
            // count of inversion pairs of two elements with Merge function(recursivly) and it will give us the count
            // Note: this will be Sorted
            int countfromright = Inversion(A, mid+1, r);
            // After getting the counts of (eg. 2 elements) from left and 2 elements from right, we will calculate the inversion
            // count pairs by merging these arrays 
            int countwhilemerge = Merge(A,l, mid + 1, r); // Merge the array from l to m and m+1 to r
            // return addition of all the count to previous function call( this will be like carry forwarding the count).
            // note: by this only we are getting the count in countfromleft and countfromright
            return (countfromleft + countfromright + countwhilemerge)%mod;
        }
        public int Merge(List<int> A, int l, int mid, int r)
        {
            int mod = 1000000007;
            // note: l to mid-1 is sorted and mid to r is sorted
            // basically left array range will be l to mid-1   
            int p1 = l;
            // basically left array range will be mid to r   
            int p2 = mid;
            long count = 0;
            // temp array to sore the sorted array
            List<int> tempArray = new List<int>();
            // p1 should be less than mid, becasue left array range is l to mid-1
            // p2 should be less than equal to r, because r is in range of right array
            while(p1<mid && p2 <= r)
            {
                // if A[p1]  is less than = to A[p2], than it can not make any inversion pairs with
                // right array because both arrays are sorted and if A[p1] is samller than A[p2], then A[p1] can not 
                // have lesser value after A[p2]. So just take the minimum of p1 or p2 into temparray becasue we have to sort the array as well
                // Also A[p1] to check counts within left is already counted in countfromleft variable, so we will assume its been already calculated
                if (A[p1] <= A[p2])
                {
                    tempArray.Add(A[p1++]);
                }
                // if A[p1]  is greater than A[p2], than it can  make inversion pairs right array
                // because both arrays are sorted and if A[p1] is greater than A[p2], then A[p2] can have all the left side elements greater than p2
                // which we can calulate by (m-p1) here m will be starting point of second array
                // Also A[p2] to check counts within right array is already counted in countfromright variable, so we will assume its been already calculated
                //Also we will take the minimum of p1 or p2 into temparray becasue we have to sort the array as well
                else
                {
                    tempArray.Add(A[p2++]);
                    //(m-p1) here m will be starting point of second array
                    count = (count%mod + (mid - p1)%mod)%mod;
                }
            }
            // if any element is left in left array than copy them in temp
            while (p1 < mid) tempArray.Add(A[p1++]);
            // if any element is left in right array than copy them in temp
            while(p2<=r) tempArray.Add(A[p2++]);
            // copy back the sorted data in original array
            for(int i = 0; i < tempArray.Count; i++)
            {
                // i +l will give the exact position of orginal starting index
                A[i+l]=tempArray[i];
            }
            // return the count to calculate inversion pairs between left and right sorted arrays.
            return (int)(count%mod);
        }
    }
}
