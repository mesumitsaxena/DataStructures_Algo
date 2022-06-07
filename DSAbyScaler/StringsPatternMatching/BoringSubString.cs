using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.StringsPatternMatching
{
    internal class BoringSubString
    {
        public int solve(string A)
        {
            List<char> even = new List<char>();
            List<char> odd = new List<char>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    even.Add(A[i]);
                }
                else
                {
                    odd.Add(A[i]);
                }
            }
            int smallestOdd=int.MaxValue;
            int largestOdd=int.MinValue;
            int smallesEven=int.MaxValue;
            int largestEven=int.MinValue;
            for (int i = 0; i < odd.Count; i++)
            {
                smallestOdd = Math.Min(smallestOdd, odd[i]);
                largestOdd = Math.Max(largestOdd, odd[i]);
            }
            for (int i = 0; i < even.Count; i++)
            {
                smallesEven = Math.Min(smallesEven, even[i]);
                largestEven = Math.Max(largestEven, even[i]);
            }
            if (Math.Abs(smallesEven-smallestOdd)>1)
            {
                return 1;
            }
            else if(Math.Abs(smallesEven - largestOdd) > 1) 
            {
                return 1;
            }
            else if (Math.Abs(smallestOdd - smallesEven) > 1) 
            {
                return 1;
            }
            else if (Math.Abs(smallestOdd - largestEven) > 1) 
            {
                return 1;
            }
            return 0;
            /*for(int i=even.Count-1;i>=0;i--){
                for(int j=0;j<odd.Count;j++){
                    int val=Math.Abs(even[i]-odd[j]);
                    if(val>1){
                        return 1;
                    }
                }
            }
            return 0;*/
        }
    }
}
