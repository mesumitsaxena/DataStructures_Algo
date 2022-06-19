using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given an array A of N integers, are there elements a, b, c in S such that a + b + c = 0

    //Find all unique triplets in the array which gives the sum of zero.

    //Note:Elements in a triplet (a, b, c) must be in non-descending order. (ie, a ≤ b ≤ c)
    //The solution set must not contain duplicate triplets.
    //Example Input

    //A = [-1,0,1,2,-1,4]


    //    Example Output

    //[[-1,0,1],
    //  [-1,-1,2] ]
    internal class _3SumZero
    {
        //So Solution is exactly same as pair of sum, how?
        // a+b+c=0, so a+b= -c
        // So if we just consider every element as c and apply two pointer technique for each c.
        // for index 0, check from index 1 till n, why we are not considering index 0, because a b c should be at unique index
        // Rest of the code will work same except, whole pair of sum code will run under for loop.
        // we also have to return the two elements, and they should be unique, so we will consider a hashset, and insert triplet
        // if the triplet is not unique do not insert it into answer array.// please follow the code comments to get to know more

        public List<List<int>> threeSum(List<int> A)
        {
            A.Sort();
            // take hashset for unique triplets
            HashSet<string> hs = new HashSet<string>();
            // answer 2D matrix
            List<List<int>> output = new List<List<int>>();
            for (int i = 0; i < A.Count; i++)
            {
                // consider each element as given sum B, but multiply it by -1 because, a+b= -c
                int sum = A[i] * -1;
                // always consider left pointer after the considered sum
                int l = i + 1;
                int r = A.Count - 1;
                while (l < r)
                {
                    // if we found the sum
                    if (A[l] + A[r] == sum)
                    {
                        // add all triplets into list
                        List<int> temp = new List<int>();
                        temp.Add(A[l]);
                        temp.Add(A[r]);
                        temp.Add(A[i]);
                        // and sort it as per the question provided
                        temp.Sort();
                        // now add them into hashmap as string
                        string combindedString = string.Join(",", temp.ToArray());
                        // if string not present, means unique triplet
                        if (!hs.Contains(combindedString))
                        {
                            // add to answer matrix
                            output.Add(temp);
                            // add it to hashset
                            hs.Add(combindedString);
                        }
                        l++;
                        r--;
                    }
                    //rest of the functionality remain same
                    else if (A[l] + A[r] > sum)
                    {
                        r--;
                    }
                    else
                    {
                        l++;
                    }
                }
            }
            return output;
        }
    }
}
