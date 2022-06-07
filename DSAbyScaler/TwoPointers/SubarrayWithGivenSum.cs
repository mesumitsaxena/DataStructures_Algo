using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    internal class SubarrayWithGivenSum
    {
        public List<int> solve(List<int> A, int B)
        {
            int l = 0;
            int r = 0;
            List<int> ans = new List<int>() { -1 };
            List<int> pf = new List<int>();
            pf.Add(A[0]);

            for (int i = 1; i < A.Count; i++)
            {
                pf.Add(pf[i - 1] + A[i]);

            }
            while (l<A.Count && r < A.Count)
            {
                if ((pf[r] - pf[l] + A[l]) == B)
                {
                   
                    break;
                }
                else if ((pf[r] - pf[l] + A[l]) > B)
                {
                    l++;

                }
                else if ((pf[r] - pf[l] + A[l]) < B)
                {
                    r++;
                }
            }
            if (l < A.Count && r < A.Count)
            {
                ans = new List<int>();
                for (int i = l; i <= r; i++)
                {
                    ans.Add(A[i]);
                }
            }
            return ans;
        }
    }
}
