using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Hashing
{
    internal class CheckPallindrome2
    {
        public int solve(string A)
        {
            Dictionary<char, int> hm = new Dictionary<char, int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (hm.ContainsKey(A[i]))
                {
                    hm[A[i]]++;
                }
                else
                {
                    hm.Add(A[i], 1);
                }
            }
            int odd = 0;
            foreach (var item in hm)
            {
                if (item.Value%2 > 0)
                {
                    odd++;
                }
            }
            if (A.Length % 2 == 0 && odd == 0)
            {
                return 1;
            }
            else if (A.Length % 2 > 0 && odd  == 1)
            {
                return 1;
            }
            return 0;
        }
    }
}
