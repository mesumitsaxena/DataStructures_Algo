using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Stack1
{
    //You are given a matrix A which represents operations of size N x 2. Assume initially you have a stack-like data structure you have to perform operations on it.

    //Operations are of two types:

    //1 x: push an integer x onto the stack and return -1.

    //2 0: remove and return the most frequent element in the stack.

    //If there is a tie for the most frequent element, the element closest to the top of the stack is removed and returned.

    //A[i][0] describes the type of operation to be performed.A[i][1] describe the element x or 0 corresponding to the operation performed.
    //Example Input
    //Input 1:

    //A = [
    //            [1, 5]
    //    [1, 7]
    //    [1, 5]
    //    [1, 7]
    //    [1, 4]
    //    [1, 5]
    //    [2, 0]
    //    [2, 0]
    //    [2, 0]
    //    [2, 0]  ]
    //Input 2:

    // A =  [
    //        [1, 5]
    //    [2, 0]
    //    [1, 4]   ]
    internal class MaxFrequencyStack
    {
        // here for frequency we need to take hashmap, that is for sure and we should talk ahead of this.
        // now, we will store the data in stack and in hashmap, so whenever we pop, we will check the higher freq from hashmap
        // and print . Also reduce the freq of the eleemnt from hashmap.
        // what is the issue with this?
        // how do you get the highest freq, will iterate on the map, again and again? we can't it will increase the TC.
        // Also if two element have same freq then how do you find the most frequent element?
        // So above approach won't work.

        // Lets see the above approach.
        // lets say we will have hashmap with freq and element - this will be used to know the freq of each element.
        // Another important DS will take is another hashmap with freq and stack.
        // this will store all the frequencies and against that freq we will have Stacks - what is the purpose?
        // we will store the element tothe stack as per the freq from another map.
        // Suppose 7 comes, it has 1 freq, so we will store 7,1. in anogther stack we will store 1,<stack(7)>
        // now 3 comes, hm1 = [7,1],[3,1] and hm2= 1,stack(3,7)
        // now 7 comes again, then hm1= [7,2] and hm2=[1,stack(3,7)],[2,stack(7)] and so on.
        // by this while popping if multiple elements have same freq(max) then we will go to that freq in hm2 and give the top.
        // we will also have one variable which will keep track of maxFreq so far, and havig another stack with freq and stack
        // we solved the issue of finding the elements against max freq till now, also if freq is same then choose the most freq is also solved from this.
        public List<int> solve(List<List<int>> A)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            Dictionary<int, Stack<int>> freqStack = new Dictionary<int, Stack<int>>();
            List<int> result = new List<int>();
            int maxFreq = 0;
            for (int i = 0; i < A.Count; i++)
            {
                //Push
                if (A[i][0] == 1)
                {
                    // insert -1 while push
                    result.Add(-1);
                    // maintain the freq map to find to maintain freq of each element
                    if (freqMap.ContainsKey(A[i][1]))
                    {
                        freqMap[A[i][1]]++;
                    }
                    else
                    {
                        freqMap.Add(A[i][1], 1);
                    }
                    // by map, we will get to know the highest freq so far
                    maxFreq = Math.Max(maxFreq, freqMap[A[i][1]]);
                    // Also insert the element in the stack of corresponding freq
                    if (freqStack.ContainsKey(A[i][1]))
                    {
                        freqStack[A[i][1]].Push(A[i][1]);
                    }
                    else
                    {
                        Stack<int> temp = new Stack<int>();
                        temp.Push(A[i][1]);
                        freqStack.Add(A[i][1], temp);
                    }
                }
                else
                {
                    //pop
                    if (freqStack.ContainsKey(maxFreq))
                    {
                        int val = freqStack[maxFreq].Peek();
                        // store the top in the result
                        result.Add(val);
                        freqStack[maxFreq].Pop();
                        // decrease the maxFreq only if that stack is empty
                        if (freqStack[maxFreq].Count == 0)
                        {
                            maxFreq--;
                        }
                        // Also decrease the freq from map, as it is helping to calculate maxFreq while inserting
                        if (freqMap.ContainsKey(val))
                        {
                            freqMap[val]--;
                        }
                    }
                }
            }
            return result;
        }
    }
}
