using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Sorting.Sorting2
{
    //You are given an array A of N elements.You have to make all elements unique.To do so, in one step you can increase any number by one.

    //Find the minimum number of steps.
    internal class UniqueElements
    {
        // If we sort the array and check with previous element if they are equal then increement the current element, Also increment the count by 1
        // but what if by this we increment the current eleemnt but next element is still same as previous, lets understand with below example:
        // 2 3 3 4 4 4 4 5(suppose this is orginal array after sorted), we see 3 and 3 are same, so we will increment 3+1=4 and increment the count
        // 2 3 4 4 4 4 4 5(here we are at first 4 and previous is 3 so we are good, go to next step)
        // 2 3 4 4 4 4 4 5(here we are at second 4 and previous is 4 only, so replace current 4 with 4+1=5 and increment count
        // 2 3 4 5 4 4 4 5(here we see previous element is greater, as array is sorted it shouldn't be greater
        // so we will replace 4 with previous element+1, which is 5+1=6 and count will incremented by 2 because we have incremented 4,  2 times.
        // So general count equation would be current value after increment - previous value before increment
        // 2 3 4 5 6 4 4 5 (6>4 so replace 4 with 6+1=7 and count will be 7-4=3)
        // 2 3 4 5 6 7 4 5 (7>4 so replace 4 with 7+1=8 and count will be 8-4=4)
        // 2 3 4 5 6 7 8 5
        // 2 3 4 5 6 7 8 9 

        public int solve(List<int> A)
        {
            //Sort the array so that all duplicate element will be together
            A.Sort();
            int count = 0;
            for (int i = 1; i < A.Count; i++)
            {
                // if current value is smaller than previous value, which shouldn't be happened becasue array is sorted
                // this is happended becasue there were many duplicates and we incremented few of the previous value
                if (A[i] < A[i - 1])
                {
                    // store previous value to calculte count later
                    int prev = A[i];
                    // increment previous value with 1, then only it will be in sorted order and we will make sure it is unique
                    A[i] = A[i - 1] + 1;
                    // calculate count
                    count += A[i] - prev;
                }
                // if duplciate then increment current value by 1
                else if (A[i] == A[i - 1])
                {
                    A[i] = A[i] + 1;
                    count++;
                }
            }
            return count;

        }
    }
}
