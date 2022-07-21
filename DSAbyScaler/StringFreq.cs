using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler
{
    internal class StringFreq
    {
        public void print(string A)
        {
            //aabbcccb
            //
            //
            //
            // aa
            for (int i = 0; i < A.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[i]
                        
                        == A[j]) { count++; }
                }
                Console.Write(A[i] + count);
            }
        }
    }
}
