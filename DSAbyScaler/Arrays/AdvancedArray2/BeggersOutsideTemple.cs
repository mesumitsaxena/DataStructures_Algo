using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray2
{
    //There are A beggars sitting in a row outside a temple.Each beggar initially has an empty pot.
    //When the devotees come to the temple, they donate some amount of coins to these beggars.
    //Each devotee gives a fixed amount of coin(according to their faith and ability) to some K beggars
    //sitting next to each other.
    internal class BeggersOutsideTemple
    {
        public List<int> solve(int A, List<List<int>> B)
        {
            //Brute Force Approach is Add amounts donated to beggers from given index to given index.
            //Repeat this process each time.O(N2) Approach.

            // Optimize solution would be Apply concept of Prefix Array.
            // 1.) Create beggers List. initiaze with 0
            // 2.) Add the amount at from index and deduct the amount at to+1 index. (ex: 0 0 0 0 0 and it says add 10 from index 1 to 3
            // So beggers array would be 0 10 0 0 -10. we are doing this so that when we take prefix sum, amount will be added to all the beggers
            // and after the to index again it will reset to 0.
            // Apply the same for rest of the queries.
            // Take the prefix some, and return prefix sum
            List<int> beggers = new List<int>();
            for (int i = 0; i < A; i++)
            {
                // Initialize beggers list to 0.
                beggers.Add(0);
            }
            for (int i = 0; i < B.Count; i++)
            {
                // Add the amount at from index
                beggers[B[i][0] - 1] += B[i][2];
                // Remove the element at to+1 index, if to+1 is beyond the range then leave
                if (B[i][1] < A)
                {
                    beggers[B[i][1]] -= B[i][2];
                }
            }
            // Take Prefix Array Sum
            for (int i = 1; i < beggers.Count; i++)
            {
                beggers[i] = beggers[i] + beggers[i - 1];
            }
            return beggers;
        }
    }
}
