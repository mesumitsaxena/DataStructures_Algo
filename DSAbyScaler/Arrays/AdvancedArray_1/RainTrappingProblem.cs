using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray_1
{
    //Given a vector A of non-negative integers representing an elevation map where the width of each bar is 1,
    //compute how much water it is able to trap after raining.
    internal class RainTrappingProblem
    {
        // Observation is for a given bar(Refer RainTrappingProblem.PNG), we have to max building on left
        // and max building on right total water accumalated on the building would be minimum of those max building - height of buidling.
        // how? from a given bar picture, if we take max building from left and right then extra water from maximum will spilled over(refer image).
        // That is why minimum from the maximums from left and right will be the water level and when subtract current building, we will get the answer.
        // For that, we can prepare left max prefix array, and right max prefix array (refer image),
        // Then Water[i] = Min(leftmax(i),rightmax(i))-A[i]
        // Optimization is, we can use carry forward technique to maintain left max and we can work with only right max prefix array.
        public int trap(List<int> A)
        {
            //Prepare right max prefix array.
            int[] rightMaxPrefix= new int[A.Count];
            rightMaxPrefix[A.Count-1]=A[A.Count-1];
            for(int i=A.Count-2; i>=0; i--)
            {
                rightMaxPrefix[i]=Math.Max(A[i],rightMaxPrefix[i+1]);
            }
            int totalWaterAccumalated = 0;
            //Initial Value of left max would be first value of Array
            int leftMax = A[0];
            for(int i = 1; i < A.Count; i++)
            {
                //Calculate left max at ith index
                leftMax=Math.Max(leftMax,A[i]);
                // Calculate Total water accumilated at particular building
                totalWaterAccumalated+=Math.Min(leftMax,rightMaxPrefix[i])-A[i];
            }
            return totalWaterAccumalated;
        }
    }
}
