using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    //Given an array A and an integer B. A pair(i, j) in the array is a good pair if i != j and (A[i] + A[j] == B).
    //Check if any good pair exist or not.
    internal class GoodPair
    {
        public int solve(List<int> A, int B)
        {
            //N^2 Solution - Check for every pair
            /*for(int i=0;i<A.Count-1;i++){
                for(int j=i+1;j<A.Count;j++){
                    if(A[i]+A[j]==B){
                        return 1;
                    }
                }
            }
            return 0;*/
            //O(n) approach with O(n) Space Complexity
            Dictionary<int, int> hm = new Dictionary<int, int>();
            //Add each number in Map with its index
            for (int i = 0; i < A.Count; i++)
            {
                if (!hm.ContainsKey(A[i]))
                {
                    hm.Add(A[i], i);
                }
            }
            for (int i = 0; i < A.Count; i++)
            {
                // A[i]+A[j]=B, So A[j]=B-A[j], So if we have A[i], we can find A[j] by B-A[i]
                // and check if that number exist in list.
                // If we iterate over the list again to find the number, TC will be O(N) and overall will be O(n2)
                // but we can search the element from Map in O(1), that is why we added each number in map
                int k = B - A[i];
                // Example : list= 2,3,5 and B=4, for A[0], A[0]=2, k=4-2=2, and 2 exist in map, this 2 is the same 2
                // which is contradicting the condition of i!=j, that is why we are storing index in map and also 
                // checking index while finding A[j]
                if (hm.ContainsKey(k) && hm[k] != i)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
