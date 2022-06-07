using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    internal class PairsWithGivenSum_Duplicates
    {
        public int solve(List<int> A, int B)
        {
            int mod = 1000000007;
            int l = 0;
            int r = A.Count - 1;
            long ans = 0;
            while (l < r)
            {
                if (A[l] + A[r] == B)
                {
                    if (A[l] == A[r])
                    {
                        long count = r - l + 1;
                        count = ((count % mod) * ((count - 1) % mod) / 2) % mod;
                        ans += count;
                        l++;
                        r--;
                    }
                    else
                    {
                        long count0 = 0;
                        int x = A[l];
                        while (l < r && x == A[l])
                        {
                            count0++;
                            l++;
                        }
                        long count1 = 0;
                        int x1 = A[r];
                        while (l <= r && x1 == A[r])
                        {
                            count1++;
                            r--;
                        }
                        long count = (count0 % mod * count1 % mod) % mod;
                        ans += count;
                    }
                }
                else if (A[l] + A[r] > B)
                {
                    r--;
                }
                else if (A[l] + A[r] < B)
                {
                    l++;
                }
            }
            return (int)(ans % mod);
        }
    }
}
