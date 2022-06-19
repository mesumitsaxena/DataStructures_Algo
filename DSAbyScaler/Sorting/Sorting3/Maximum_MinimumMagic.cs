using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Sorting.Sorting3
{
    //Given an array of integers A of size N where N is even.

    //Divide the array into two subsets such that

    //1.Length of both subset is equal.
    //2.Each element of A occurs in exactly one of these subset.
    //Magic number = sum of absolute difference of corresponding elements of subset.

    //Note: You can reorder the position of elements within the subset to find the value of the magic number.

    //For Ex:- 
    //subset 1 = { 1, 5, 1}, 
    //subset 2 = {1, 7, 11}
    //Magic number = abs(1 - 1) + abs(5 - 7) + abs(1 - 11) = 12
    //Return an array B of size 2, where B[0] = maximum possible value of Magic number modulo 109 + 7, B[1] = minimum possible value of a Magic number modulo 109 + 7.
    internal class Maximum_MinimumMagic
    {
        // here we need maximum sum by dividing two subsets.
        // How do we get maximum difference, when we subtract highest value with smallest value
        // How do we get minimum difference, when we subtract two closest values.
        // so this is the main idea, in order to get max and minimum, just Sort the array
        // Then subtract two fardest eleemnts and get maximum magic number 
        // and subtract adjecent element and get minimum magic number
        public List<int> solve(List<int> A)
        {
            int mod = 1000000007;
            A.Sort();
            int p1 = 0;
            int p2 = A.Count - 1;
            long max = 0;
            // Get max by subtracting fardest elements
            while (p1 < p2)
            {
                max += (Math.Abs(A[p2] - A[p1])) % mod;
                p1++;
                p2--;
            }
            long min = 0;
            p1 = 0;
            p2 = 1;
            // get min by subtracting adjecent elements
            while (p2 < A.Count)
            {
                min += (Math.Abs(A[p2] - A[p1])) % mod;
                p1 += 2;
                p2 += 2;
            }
            max = max % mod;
            min = min % mod;
            return new List<int>() { (int)max, (int)min };
        }
    }
}
