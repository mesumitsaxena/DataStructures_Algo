using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    internal class TimetoEquality
    {
        //Given an integer array A of size N.In one second, you can increase the value of one element by 1.
        //Find the minimum time in seconds to make all elements of the array equal.

        public int solve(List<int> A)
        {
            // Approach is we will find the maxvalue and subtract it with other elements.
            //ex : 2,4,1,3,2 , max =4, 4-2=2,4-4=0,4-1=3,4-3=1,4-2=2, so 2+0+3+1+2=8
            int maxvalue = Int32.MinValue;
            //find maxvalue
            for (int i = 0; i < A.Count; i++)
            {
                if (maxvalue < A[i])
                {
                    maxvalue = A[i];
                }
            }
            int mintime = 0;
            for (int i = 0; i < A.Count; i++)
            {
                mintime = mintime + (maxvalue - A[i]);
            }
            return mintime;

        }
    }
}
