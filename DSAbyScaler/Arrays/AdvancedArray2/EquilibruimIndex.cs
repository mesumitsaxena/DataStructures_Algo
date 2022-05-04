using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray2
{
    internal class EquilibruimIndex
    {
        public int solve(List<int> A)
        {
            List<int> leftPrefixSum = new List<int>();
            List<int> rightPrefixSum = new List<int>();
            leftPrefixSum.Add(A[0]);
            for (int i = 1; i < A.Count; i++)
            {
                leftPrefixSum.Add(leftPrefixSum[i - 1] + A[i]);
            }
            rightPrefixSum.Add(A[A.Count - 1]);
            for (int i = A.Count - 2; i >= 0; i--)
            {
                rightPrefixSum.Add(rightPrefixSum[A.Count - 2 - i] + A[i]);
            }
            for (int i = 0; i < A.Count; i++)
            {
                if (leftPrefixSum[i] == rightPrefixSum[A.Count - 1   - i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
