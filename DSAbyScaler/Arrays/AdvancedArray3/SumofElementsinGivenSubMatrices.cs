using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray3
{
    internal class SumofElementsinGivenSubMatrices
    {
        public List<int> SumofSubmatrices(List<List<int>> A, List<List<KeyValuePair<int,int>>> queries)
        {
            List<int> SumofSubmatrices= new List<int>();
            List<List<int>> Prefix = new List<List<int>>();
            //Create a Prefix Array Column wise
            for(int i = 0; i < A.Count; i++)
            {
                List<int> prefixtemp = new List<int>();
                for(int j = 0; j < A[0].Count; j++)
                {
                    if (j == 0)
                    {
                        prefixtemp.Add(A[i][j]);
                    }
                    else
                    {
                        prefixtemp.Add(prefixtemp[j-1]+A[i][j]);
                    }
                }
                Prefix.Add(prefixtemp);
            }
            // Create a Prefix sum Row wise
            for(int j = 0; j < A[0].Count; j++)
            {
                for(int i = 1; i < A.Count; i++)
                {
                    Prefix[i][j] = Prefix[i - 1][j] + Prefix[i][j];
                }
            }
            // Calcualte Sum of Submatrices with given Indexes
            for(int i=0;i< queries.Count; i++)
            {
                int ans = 0;
                // determine Indexes
                int topleftrow = queries[0][i].Key;
                int topleftcolumn = queries[0][i].Value;
                int bottomrightRow = queries[1][i].Key;
                int bottomrightColumn = queries[1][i].Value;
                // Calculate total sum at bottom right corner
                ans += Prefix[bottomrightRow][bottomrightColumn];
                // if topleft column is greater than 0, means we have to remove that portion
                if (topleftcolumn > 0) ans -= Prefix[bottomrightRow][topleftcolumn - 1];
                // if topleft row is greater than 0, means we have to remove that portion as well
                if (topleftrow > 0) ans -= Prefix[topleftrow - 1][bottomrightColumn];
                // if both are greater than 0, means we have deleted  common portion twice, so add it one more time
                if (topleftrow > 0 && topleftcolumn > 0) ans += Prefix[topleftrow - 1][topleftcolumn - 1];
                SumofSubmatrices.Add(ans);
            }
            return SumofSubmatrices;
        }
    }
}
