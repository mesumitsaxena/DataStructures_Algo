using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.StringsPatternMatching
{
    internal class PeriodOfString
    {
        public int solve(string A)
        {
            int n = A.Length;
            int[] zArray = new int[n];
            zArray[0] = n;
            int l = 0;
            int r = 0;
            for (int i = 1; i < n; i++)
            {
                if (i > r)
                {
                    l = i;
                    r = i;
                    while (r < n && A[r] == A[r - l])
                    {
                        r++;
                    }
                    zArray[i] = (r - l);
                    r--;
                }
                else
                {
                    int j = i - l;
                    if (zArray[j] < r - i + 1)
                    {
                        zArray[i] = zArray[j];
                    }
                    else
                    {
                        l = i;
                        r++;
                        while (r < n && A[r] == A[r - l])
                        {
                            r++;
                        }
                        zArray[i] = r - l;
                        r--;
                    }
                }
            }
            int max = Int32.MaxValue;
            // need to understand
            // try watching the video again
            for (int i = 1; i < n; i++)
            {
                if (i + zArray[i] == n)
                {
                    return i;
                }
            }
            return n;
        }
    }
}
