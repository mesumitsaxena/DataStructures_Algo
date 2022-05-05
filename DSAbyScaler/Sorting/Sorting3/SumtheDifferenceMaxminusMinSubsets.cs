using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Sorting3
{
    internal class SumtheDifferenceMaxminusMinSubsets
    {
        public  long power(long x, int y)
        {
            long result = 1;
            int mod = 1000000007;
            while (y > 0)
            {

                // y is even
                if (y % 2 == 0)
                {
                    x = (x * x)%mod;
                    y = y / 2;
                }

                // y isn't even
                else
                {
                    result = (result * x)%mod;
                    y = y - 1;
                }
            }
            return result;
        }
        public int solve(List<int> A)
        {
            int mod = 1000000007;
            A.Sort();
            long ans = 0;
            int length = A.Count - 1;
            for (int i = 0; i < A.Count; i++)
            {
                long maxcontri = power(2, i);
                long mincontri = power(2, length - i);
                ///long val = ((A[i] * (1 << i)) % mod - (A[i] * (1 << A.Count - i - 1)) % mod) % mod;

                long maxminusmin = (maxcontri - mincontri) * A[i];
                ans += maxminusmin;
            }
            return (int)((ans+mod) % mod);
        }
    }
}
