using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray_1
{
    //You are given an array of N integers, A1, A2, …. AN.
    //Return the maximum value of f(i, j) for all 1 ≤ i, j ≤ N.f(i, j) is defined as |A[i] - A[j]| + |i - j|,
    //where |x| denotes absolute value of x.

    

    internal class MaximumAbsoluteDifference
    {
        // Observations 1: Suppose we only have one condition which is |A[i]-A[j]|
        // Then, inorder to find maximum difference between a pair would be maximum value in the array and minimum value in the array.
        // In Another word: MaxDifference=MaxinArray-MininArray

        //Observation 2: Actual equation can be written in 4 possible ways if we want maximum answer-
        // way1: when A[i]>A[j] and i>j then => A[i]-A[j] + (i-j) => (A[i]+i) - (A[j]+j)
        // way2: when A[i]>A[j] and i<j then => A[i]-A[j] + (j-i) => (A[i]-i)-(A[j]-j)
        // way3: when A[i]<A[j] and i>j then => A[j]-A[i] + (i-j) => (A[j]-j)-(A[i]-i)
        // way4: when A[i]<A[j] and i<j then => A[j]-A[i] + (j-i) => (A[j]+j)-(A[i]+i)
        // Now if you can see way1 and way4, way2 and way 3 are same because in question we have to take absolute difference.
        // So we can pick way1 and way2, calculate and return the maximum out of it.
        // Now apply observation 1 in this suppose in way 1 (A[i]+i) - (A[j]+j) => x-y.(x=(A[i]+i) and y=(A[j]+j))
        // Same way way 2, (A[i]-i)-(A[j]-j) => x-y. (x=(A[i]-i) and y=(A[j]-j))
        // here x can we maximum value in array and y can be minimum value in array and we will get the maximum answer.
        public int maxArr(List<int> A)
        {
            // variable to maintain maximum value of A[i]+i or we can say x
            int way1Maximum = Int32.MinValue;
            // variable to maintain minimum value of A[i]+i or we can say y
            int way1Minimum = Int32.MaxValue;
            // variable to maintain maximum value of A[i]-i or we can say x
            int way2Maximum = Int32.MinValue;
            // variable to maintain minimum value of A[i]-i or we can say y
            int way2Minimum = Int32.MaxValue;
            for (int i = 0; i < A.Count; i++)
            {
                // Calculate maximum and minimum value of A[i]+i
                way1Maximum = Math.Max(way1Maximum, A[i] + i);
                way1Minimum = Math.Min(way1Minimum, A[i] + i);

                // Calculate maximum and minimum value of A[i]-i
                way2Maximum = Math.Max(way2Maximum, A[i] - i);
                way2Minimum = Math.Min(way2Minimum, A[i] - i);
            }
            // Return maximum difference between both ways.
            return Math.Max(way1Maximum-way1Minimum,way2Maximum-way2Minimum);
        }
    }
}


