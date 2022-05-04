using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    internal class MatrixMultipication
    {
        public List<List<int>> solve(List<List<int>> A, List<List<int>> B)
        {
            List<List<int>> resultant= new List<List<int>>();
            for(int i=0; i<A.Count; i++)
            {
                List<int> list = new List<int>();
                for(int j=0; j<B[0].Count; j++)
                {
                    list.Add(0);
                }
                resultant.Add(list);
            }
            List<List<int>> finalMatrix = new List<List<int>>();
            for (int i = 0; i < A.Count; i++)
            {
                
                for (int j = 0; j < B[0].Count; j++)
                {
                    for (int k = 0; k < A[0].Count; k++)
                    {
                        int x = A[i][k];
                        int y = B[k][j];
                        resultant[i][j] += (x*y);
                    }
                }
            }
            return resultant;
        }
    }
}
