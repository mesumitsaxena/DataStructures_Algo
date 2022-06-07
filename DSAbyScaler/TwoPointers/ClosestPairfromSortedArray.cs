using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    internal class ClosestPairfromSortedArray
    {
        public List<int> solve(List<int> A, List<int> B, int C)
        {
            int l = 0;
            int r = B.Count - 1;
            int gl = 0;
            int gr = 0;
            while (l < A.Count && r >= 0)
            {
                if (A[l] + B[r] == C)
                {
                    return new List<int>() { A[l], B[r] };
                }
                else if (A[l] + B[r] > C)
                {
                    r--;
                }
                else if (A[l] + B[r] < C)
                {
                    if (A[l] + B[r] > A[gl] + B[gr])
                    {
                        gl = l;
                        gr = r;
                    }
                    l++;
                }
            }
            return new List<int>() { A[gl], B[gr] };
        }
    }
}
