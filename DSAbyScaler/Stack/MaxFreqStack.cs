using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack
{
    internal class MaxFreqStack
    {
        public List<int> solve(List<List<int>> A)
        {
            List<int> output = new List<int>();
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            Dictionary<int, Stack<int>> freqStackMap = new Dictionary<int, Stack<int>>();
            int maxFreq = Int32.MinValue;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i][0] == 1)
                {
                    output.Add(-1);
                    if (freqMap.ContainsKey(A[i][1]))
                    {
                        freqMap[A[i][1]]++;
                    }
                    else
                    {
                        freqMap.Add(A[i][1], 1);
                    }
                    maxFreq = Math.Max(maxFreq, freqMap[A[i][1]]);
                    if (freqStackMap.ContainsKey(freqMap[A[i][1]]))
                    {
                        freqStackMap[freqMap[A[i][1]]].Push(A[i][1]);
                    }
                    else
                    {
                        Stack<int> temp = new Stack<int>();
                        temp.Push(A[i][1]);
                        freqStackMap.Add(freqMap[A[i][1]], temp);
                    }
                }
                else
                {
                    if (freqStackMap.ContainsKey(maxFreq))
                    {
                        int val = freqStackMap[maxFreq].Peek();
                        output.Add(val);
                        freqStackMap[maxFreq].Pop();
                        if (freqMap.ContainsKey(val))
                        {
                            freqMap[val]--;
                        }
                        if (freqStackMap[maxFreq].Count == 0)
                        {
                            maxFreq--;
                        }
                    }
                }
            }
            return output;
        }
    }
}
