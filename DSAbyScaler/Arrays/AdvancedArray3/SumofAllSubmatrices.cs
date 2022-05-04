using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    internal class SumofAllSubmatrices
    {
        public int Sum(List<List<int>> A)
        {
            int row = A.Count - 1;
            int col = A[0].Count - 1;
            //int ansforbruteforce = 0;
            // Most Bruteforce way is generate all submatrices and iterate on TL to BR and calculate sum
            // this include TC as O(N^3*M^3).
            /*
            //Starting point of Top Left Corner  row
            for (int tl1 = 0; tl1 <= row; tl1++)
            {
                for(int br1 = 0; br1 <= col; br1++)
                {
                    // End point of Top Left Corner -column

                    // Start point of bottom right - row
                    for (int tl2 = tl1; tl2 <= row; tl2++)
                    {
                        for(int br2 = br1; br2 <= col; br2++)
                        {
                            //End of Bottom right -column

                            // Now subarray sum
                            for(int i = tl1; i <= tl2; i++)
                            {
                                for(int j=br1; j <= br2; j++)
                                {
                                    ans+=A[i][j];
                                }
                            }
                        }
                    }
                   
                }
            }
            return ans;*/

            // Approach 2 : we can save little time complexity when we are iterating on TL to BR.
            // what we can do is generate the Prefix Sum Matrix, and calculate sum of all the subarray using prefix sum
            // Removed 2 inner loops so TC is O(n^2*m^2)
            int ansforprefixsum = 0;
            List<List<int>> Prefix = new List<List<int>>();
            //Create a Prefix Array Column wise
            for (int i = 0; i < A.Count; i++)
            {
                List<int> prefixtemp = new List<int>();
                for (int j = 0; j < A[0].Count; j++)
                {
                    if (j == 0)
                    {
                        prefixtemp.Add(A[i][j]);
                    }
                    else
                    {
                        prefixtemp.Add(prefixtemp[j - 1] + A[i][j]);
                    }
                }
                Prefix.Add(prefixtemp);
            }
            // Create a Prefix sum Row wise
            for (int j = 0; j < A[0].Count; j++)
            {
                for (int i = 1; i < A.Count; i++)
                {
                    Prefix[i][j] = Prefix[i - 1][j] + Prefix[i][j];
                }
            }
            // Generate All Submatrices
            for (int tlrow = 0; tlrow <= row; tlrow++)
            {
                for(int tlcol = 0;tlcol <= col; tlcol++)
                {
                    for(int brrow=0;brrow <= row; brrow++)
                    {
                        for(int brcol=0;brcol <= col; brcol++)
                        {
                            ansforprefixsum += Prefix[brrow][brcol];
                            if(tlrow>0) ansforprefixsum -= Prefix[tlrow-1][brcol];
                            if (tlcol > 0) ansforprefixsum -= Prefix[brrow][tlcol - 1];
                            if (tlrow > 0 && tlcol > 0) ansforprefixsum += Prefix[tlrow - 1][tlcol - 1];
                        }
                    }
                }
            }
            return ansforprefixsum;
            // Most Optimized way of Solving this problem is Contribution Technique
            // As we heard Sum of All, we should think as Contri Tech as optimized way.
            // Just like in 1 D array we need to find the contribution in each subarray, 
            // Same way we have to find the contribution for each element.
            // Most Optimized Approach , TC: O(N*M)
            int answerforContribution = 0;
            for (int i = 0; i <= row; i++)
            {
                for(int j = 0; j <= col; j++)
                {
                    //refer SumofAllSubMatrices.png for more understanding
                    int contributionintopleft=(i+1)*(j+1);
                    int contributioninbottomright=(A.Count-i)*(A[0].Count-j);
                    answerforContribution += contributionintopleft*contributioninbottomright*A[i][j];
                }
            }
            return answerforContribution;

        }
    }
}
