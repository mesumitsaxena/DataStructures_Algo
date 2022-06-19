using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    //Given a number A, find if it is COLORFUL number or not.

    //If number A is a COLORFUL number return 1 else, return 0.

    //What is a COLORFUL Number:

    //A number can be broken into different contiguous sub-subsequence parts. 
    //Suppose, a number 3245 can be broken into parts like 3 2 4 5 32 24 45 324 245. 
    //And this number is a COLORFUL number, since product of every digit of a contiguous subsequence is different.
    //Example Input
    //Input 1:

    // A = 23
    //Input 2:

    // A = 236


    //Example Output
    //Output 1:

    // 1
    //Output 2:

    // 0
    //Example Explanation
    //Explanation 1:

    // Possible Sub-sequences: [2, 3, 23] where
    // 2 -> 2 
    // 3 -> 3
    // 23 -> 6  (product of digits)
    // This number is a COLORFUL number since product of every digit of a sub-sequence are different.
    //Explanation 2:

    // Possible Sub-sequences: [2, 3, 6, 23, 36, 236] where
    // 2 -> 2 
    // 3 -> 3
    // 6 -> 6
    // 23 -> 6  (product of digits)
    // 36 -> 18  (product of digits)
    // 236 -> 36  (product of digits)
    // This number is not a COLORFUL number since the product sequence 23  and sequence 6 is same.
    internal class ColorfulNumber
    {
        // So first of all we will be needing an array to store the numbers, so that we can check subsequence
        // We need to generate subsequence, calculate product of subsequence, then check if we have any duplicate product or not.
        // Generating subsequence will be O(N^2), because we need to check each subarray, if we create prefix product array
        // then also it wont help, because then we will always have product of subarray starting from index 0, in order to check 
        // other subarray, we need to iterate which will lead to again O(N^2) time complexity
        // So we will create subarray using 2 loops, and then check if any product has duplicates using hashset
        public int colorful(int A)
        {
            // create hashset to check duplicates in the list
            HashSet<int> checkDuplicates=new HashSet<int>();
            List<int> numberList = new List<int>();
            //create number array
            while (A > 0)
            {
                numberList.Add(A % 10);
                A = A / 10;
            }
            // create subsequences
            for(int i = 0; i < numberList.Count; i++)
            {
                int product = 1;
                for(int j = i; j < numberList.Count; j++)
                {
                    //check if the product exist in set or not
                    product=product* numberList[j];
                    if (checkDuplicates.Contains(product))
                    {
                        // if yes return 0
                        return 0;
                    }
                    else
                    {
                        checkDuplicates.Add(product);
                    }
                }
            }
            // after checking all the product if still 0 is not returned it means there are no duplicate product, so 
            // return 1
            return 1;
        }
    }
}
