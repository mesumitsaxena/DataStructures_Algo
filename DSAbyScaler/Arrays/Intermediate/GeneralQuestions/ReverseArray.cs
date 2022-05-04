using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    internal class ReverseArray
    {
        //You are required to return another array which is the reversed form of the input array.
        public List<int> solve(List<int> A)
        {
            // We can create a new Array and iterate on original Array from back and store the elements and return new array.
            // Or we can just swap first and last elements of the same array and continue doing that until reached to middle
            int i = 0;
            int j = A.Count - 1;
            while (i < j)
            {
                A[i] = A[i] ^ A[j];
                A[j] = A[i] ^ A[j];
                A[i] = A[i] ^ A[j];
                i++;
                j--;
            }
            return A;
        }
    }
}
