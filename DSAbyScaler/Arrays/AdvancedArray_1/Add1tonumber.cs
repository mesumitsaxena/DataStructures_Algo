using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray_1
{
    internal class Add1tonumber
    {
        public List<int> plusOne(List<int> A)
        {
            int carry = 0;
            //  when we add 1 If last value is 9 means, we are going to have a carry and its value will be 0
            if (A[A.Count - 1] == 9)
            {
                A[A.Count - 1] = 0;
                carry = 1;
            }
            // else just increase the number and return
            else
            {
                A[A.Count - 1]++;
            }
            //lets start with second last position as we already took care of last position
            int i = A.Count - 2;
            // continue untill carry is 1
            while (carry > 0 && i >= 0)
            {
                // if current value is 9 and carry is 1 then make current value as 0 and carry remains 1
                if (A[i] == 9)
                {
                    A[i] = 0;
                    carry = 1;
                }
                // else add the number and make carry 0 and stop the loop
                else
                {
                    A[i] = A[i] + carry;
                    carry = 0;
                }
                i--;
            }
            // if all the elements are done but carry is still left then we will insert the carry at first place
            if (carry > 0)
            {
                A.Insert(0, carry);
            }
            // if there are still 0 at beginneing remove them all
            while (A[0] == 0)
            {
                A.RemoveAt(0);
            }
            return A;
        }
    }
}
