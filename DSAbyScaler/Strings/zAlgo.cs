using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings
{
    internal class zAlgo
    {
        public List<int> findzValues(string s)
        {
            //Define pink region
            int l = 0;
            int r = 0;
            List<int> zValues = new List<int>();
            zValues.Add(s.Length);
            for (int i = 1; i < s.Length; i++)
            {
                if (i > r)
                {
                    //find the value using brute force
                    while (r < s.Length && s[r] == s[r - l])
                    {
                        r++;
                    }
                    zValues.Add(r - l);
                    r--;
                }
                else
                {
                    if (zValues[i - l] < r - i + 1)
                    {
                        zValues.Add(zValues[i - l]);
                    }
                    else
                    {
                        l = i;
                        r++;
                        while(r<s.Length && s[r] == s[r - l])
                        {
                            r++;
                        }
                        zValues.Add(r - l);
                        r--;
                    }
                }
                
            }
            return zValues;
        }



    }


}

