using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray_1
{
    internal class MaxNonNegSubArray
    {
        public List<int> maxset(List<int> A)
        {
            long sum = 0;
            long ans = 0;
            int start = -1;
            int end = 0;
            int ans_start = 0;
            int ans_end = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] < 0)
                {
                    sum = 0;
                    start = i;
                    end = i;
                }
                else
                {
                    sum = sum + (long)A[i];
                    end = i;
                }
                if (ans < sum || (ans == sum && end - start > ans_end - ans_start))
                {
                    ans = sum;
                    ans_start = start;
                    ans_end = end;
                }
            }
            List<int> MaxSumSubArray = new List<int>();
            for (int i = ans_start + 1; i <= ans_end; i++)
            {
                MaxSumSubArray.Add(A[i]);
            }
            return MaxSumSubArray;
        }
    }
}
