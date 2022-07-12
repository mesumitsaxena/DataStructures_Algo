using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Stack.Queue.Queue2
{
    //Given a string A denoting a stream of lowercase alphabets, you have to make a new string B.
    //B is formed such that we have to find the first non-repeating character each time a character is inserted to the stream and append it at the end to B. If no non-repeating character is found, append '#' at the end of B.
    //Example Input
    //Input 1:

    // A = "abadbc"
    //Input 2:

    // A = "abcabc"


    //Example Output
    //Output 1:

    //"aabbdd"
    //Output 2:

    //"aaabc#"

    internal class Firstnon_repeatingcharacter
    {
        // when we see these kind of string questions, we directly think of hashmap and hashset.
        // and yes map can be used in order to store the frequency of the elements, then only we will be able to know 
        // if till now any character is repeating or not.
        // Lets understand with an example: abadbc, so for a, non repeating first char is a, now b comes, first non repeating char is a again
        // now a again comes, first non repeating char is b, as curr string is aba, so first non repeating char is b.
        // d comes, now string is abad, so first non repeating char is b again.
        // when any new char comes, we will store it in map, and then iterate on the array till i and check each char from beginning
        // if that element is repeating then move to next and so on, add to answer if the element is not repeating.
        // this approach is O(N^2) as we are iterating on the stream again and again

        // Second approach, while iterating, after we add the data/freq in map, we need to give the first non repeating char.
        // for the we are iterating from left, insead of iterating again and again, check if first element is repeating(we can check from map)
        // delete the data from stream, and check for next char, if that is also repeating delete it. 
        // now if the elementis not repeating then add that element in the output.
        // So we are only checking the first element if it is repeating than delete the element, and now next char will be first element
        // if that is also repeating then delete that as well.
        // Deleting the first element in array is difficult, as we may have to shift the whole array to the right
        // which will take O(N) time just to shift.

        // Optimized Approach: Do we know any DS by which we have the access of first element and
        // can delete the first char in O(1).
        // Also add the element in the end in O(1)?
        // Queue. Queue can delete the first element from array O(1) and have the access to the first element(front)
        // we can also add the element in O(1) at the end (rear).
        // if there is no duplicate element then add #
        public string solve(string A)
        {
            Queue<char> nonDuplicateQueue = new Queue<char>();
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            for(int i = 0; i < A.Length; i++)
            {
                if (freqMap.ContainsKey(A[i]))
                {
                    freqMap[A[i]]++;
                }
                else
                {
                    freqMap.Add(A[i], 1);
                }
                nonDuplicateQueue.Enqueue(A[i]);
                // if front element is repeating then dequeue until we found front as non repeating
                while (nonDuplicateQueue.Count>0 && freqMap.ContainsKey(nonDuplicateQueue.Peek()) && freqMap[nonDuplicateQueue.Peek()] > 1)
                {
                    nonDuplicateQueue.Dequeue();
                }
                // if queue is non empty means front will be non repeating, as in above code we have removed 
                // all the non repeating chars from front
                if (nonDuplicateQueue.Count > 0)
                {
                    output.Append(nonDuplicateQueue.Peek());
                }
                // if queue is empty means till now all the chars were repeating
                else
                {
                    output.Append("#");
                }
            }
            return output.ToString();
        }
    }
}
