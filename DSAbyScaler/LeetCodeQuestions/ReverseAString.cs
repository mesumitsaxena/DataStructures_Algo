using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    internal class ReverseAString
    {
        public string ReverseWords(string s)
        {
            int i = -1;
            int j = 0;
            char[] charArray = s.ToCharArray();
            for (int k = 0; k < charArray.Length; k++)
            {
                if (charArray[k] == ' ' || k == charArray.Length - 1)
                {
                    int l = i + 1;
                    int r = k - 1;
                    if (k == charArray.Length - 1)
                    {
                        r = k;
                    }
                    while (l < r)
                    {
                        char temp = charArray[l];
                        charArray[l] = charArray[r];
                        charArray[r] = temp;
                        l++;
                        r--;
                    }
                    i = k;
                }
            }
            return new string(charArray);
        }
    }
}
