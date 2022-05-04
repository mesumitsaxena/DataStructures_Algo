using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    internal class NobalInteger
    {
        //Given an integer array A, find if an integer p exists
        //in the array such that the number of integers greater than p in the array equals p.
        public int solve(List<int> A)
        {
            //Question says that, we have to find if any number is equal to number of greater elements in that array.
            // Example: 3 2 1 3, there A[1]= 2, is nobal integer, because there 2 elemnts in array which are greater than 2 ( they are 3,3).
            // Another example is -1 -3 1 1, here there is no integer found, there are two 1s but 1 is not greater than 1 so nobal integer exist.
            // brute force is pick an element and check how many greater elements it has in array and then check if count is equal to element. (O(N^2))
            // Optimize solution is if we sort the array, now we know , all the greater elements are on the right side.
            // So we can check number of elements on the right side at particular index is equal to element at that index then true. if no such element exist then false.

            A.Sort();
            // After sorting if 0 is at end, means rest all elements are -ve, and -ve elements cant give the answer.
            // And there are 0 greater elements exist on the side at the last index, so true, return 1.
            if (A[A.Count - 1] == 0) return 1;
            // we will not check last index because at last index apart from 0 (which we already checked) no other element can give answer.
            // ex:  if last index =1 then there are no element left 1 cant be an answer etc.
            for (int i = 0; i < A.Count - 1; i++)
            {
                // if two elements are equal, then we must not calculate.
                // example: -2 -1 1 1, at index 3(0 based indexing) A[2]=1 and A.Count-1-i means(4-1-2)=1, so it says 1 is noble integer.
                // but it is not 1 0 greater elements. its just duplicate which is making confusion.
                if (A[i] == A[i + 1]) continue;
                // check number of elements on the right side at particular index is equal to element at that index then true
                if ((A.Count - 1 - i) == A[i])
                {
                    return 1;
                }
            }
            // if no elements gave the answer so far, return -1
            return -1;
        }
    }
}
