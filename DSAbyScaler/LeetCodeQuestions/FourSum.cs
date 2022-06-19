using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    internal class FourSum
    {
        public IList<IList<int>> Foursum(int[] nums, int target)
        {
            Array.Sort(nums);
            // take hashset for unique triplets
            HashSet<string> hs = new HashSet<string>();
            // answer 2D matrix
            IList<IList<int>> output = new List<IList<int>>();
            for (int j = 0; j < nums.Length; j++)
            {


                for (int i = j + 1; i < nums.Length; i++)
                {
                    // consider each element as given sum B, but multiply it by -1 because, a+b= -c
                    int sum = target-nums[i]-nums[j];
                    // always consider left pointer after the considered sum
                    int l = i + 1;
                    int r = nums.Length - 1;
                    while (l < r)
                    {
                        // if we found the sum
                        if (nums[l] + nums[r] == sum)
                        {
                            // add all triplets into list
                            List<int> temp = new List<int>();
                            temp.Add(nums[l]);
                            temp.Add(nums[r]);
                            temp.Add(nums[i]);
                            temp.Add(nums[j]);
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
                        else if (nums[l] + nums[r] > sum)
                        {
                            r--;
                        }
                        else
                        {
                            l++;
                        }
                    }
                }
            }
            return output;
        }
    }
}
