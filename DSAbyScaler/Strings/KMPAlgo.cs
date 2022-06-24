using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Strings
{
    
    internal class KMPAlgo
    {
        public int[] PrepareLPA(string s)
        {

            int[] LPA = new int[s.Length];
            LPA[0] = 0;
            int i = 0;
            int j = 1;
            while (j < s.Length)
            {
                // if i and j match then assign LPA[j]=i+1, give the value of prefix length which is also a suffix till now, how?
                // example: abcdabc, suppose i=0 and j=4, so A[i]=A[j]=a, so till j=4, prefix which is also a suffix is 'a'
                // and its length is 1 (i=0+1)=1,now i=1 and j=5 still matching means lpa[j]=i+1, 2 and we can see ab(0 to 1) is
                // matching with ab(4 to 5). so prefix is ab(01) and suffix is ab(45) which is same, so length is 2.
                // 2 is not kind of length but gives the location or index till when the strings are matching so till index i-1 strings are matching
                // and we check with prefix and i is prefix.
                // check for next match, so i++, j++
                if (s[i] == s[j])
                {
                    LPA[j] = i + 1;
                    i++;
                    j++;
                }
                // if it is not matching
                else
                {
                    // if i=0, we can not go before 0 so assign 0 to lpa and check for next char, j++
                    if (i == 0)
                    {
                        LPA[j] = 0;
                        j++;
                    }
                    //if A[i]!=A[j], then reset i till which strings were matching and that was till i-1, (that is how we are skipping comparing whole string)
                    // so that is why i=LPA[i-1]
                    else
                    {
                        i = LPA[i - 1];
                    }
                }
            }
            return LPA;

        }
        public bool SolveKMP(string source, string target)
        {
            //prepare LPA
            int[] LPA=PrepareLPA(target);
            int i = 0;
            int j = 0;
            // while both i and j stays in boundry
            while (i<source.Length && j < target.Length)
            {
                // if source and target are same, then move forward
                if (source[i] == target[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    // else if target value is at 0 then go ahead with i
                    if (j == 0)
                    {
                        i++;
                    }
                    // else go back to the index which has same elements till now and we have to check from starting so 
                    // we will not move i.
                    else
                    {
                        j = LPA[j - 1];
                    }
                }
            }
            // if j passes and through with target it means true all chars matches in sequence
            // else it will remain inside boundry because we are resetting j back to the position of last matched value
            if (j < target.Length) return false;
            return true;
        }
    }
}
