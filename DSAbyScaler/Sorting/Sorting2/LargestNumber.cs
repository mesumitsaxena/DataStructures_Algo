using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Sorting.Sorting2
{
    //Given an array A of non-negative integers, arrange them such that they form the largest number.

    //Note: The result may be very large, so you need to return a string instead of an integer.
    internal class LargestNumber
    {
        // Here we will use comparitor function, we will try all different combination using comparitor function and
        // which ever is giving us maximum value, array will be sorted accordingly
        // convert it to string and return
        public string largestNumber(List<int> A)
        {
            bool iszero = true;
            for(int i=0;i<A.Count; i++)
            {
                if (A[i] != 0)
                {
                    iszero = false;
                    break;
                }
            }
            if (iszero) return "0";
            // As concatinating numbers with integer would be difficult, we will convert it to string.
            // then it will compare and Sort the array
            A.Sort((int element1, int element2) =>
            {
                // suppose if two elements are 3 and 30, then a ="330" and b="303".
                string a = element1.ToString() + element2.ToString();
                string b = element2.ToString() + element1.ToString();
                // as we know 330 is greater so it will return 330, it will do the same for other elements as well.
                return b.CompareTo(a);
            });
            // As now Array is sorting, lets create a string out of it.
            // As string is mutable type, so adding elements into it will lead to create a new string each time,
            // lets take string builder to append the values.
            System.Text.StringBuilder LargestNumber= new System.Text.StringBuilder();
            for(int i = 0; i < A.Count; i++)
            {
                LargestNumber.Append(A[i].ToString());
            }
            return LargestNumber.ToString();
        }
    }
}
