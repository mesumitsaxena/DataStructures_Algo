using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    internal class SortByColor
    {
        public List<int> sortColors(List<int> A)
        {
            int red = 0;
            int white = 0;
            int blue = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] == 0)
                {
                    red++;
                }
                else if (A[i] == 1)
                {
                    white++;
                }
                else
                {
                    blue++;
                }
            }
            int j = 0;
            while (red > 0)
            {
                A[j] = 0;
                j++;
                red--;
            }
            while (white > 0)
            {
                A[j] = 1;
                j++;
                white--;
            }
            while (blue > 0)
            {
                A[j] = 2;
                j++;
                blue--;
            }
            return A;
        }
    }
}
