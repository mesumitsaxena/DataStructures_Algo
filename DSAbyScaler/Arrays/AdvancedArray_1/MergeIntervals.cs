using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.AdvancedArray_1
{
    // first argumnet is list of intervals in which A[i][0] denotes start time and A[i][1] denotes end time of 'i' interval.
    // second argument denotes start time of merge interval and 
    // third argument denotes end time of merge interval
    // must condition (B<C) 
    // You  have to return list of intervals 
    internal class MergeIntervals
    {
        // Iterate on the Intervals and check if Current Interval is not overlaping with new Interval.
        // Also check if new Interval range lies before current interval and after interval.
        // There are 3 steps to check if new Interval is overlapping with current interval or not
        // 1.) Check if new Interval is before current interval, If yes then Add new Interval in answer array and Add rest of the intervals as well
        // 2.) if new Interval range comes after the current interval, if yes than Add current interval in result array and move to next interval
        // 3.) if both the cases does not fulfilled than it means they are overlapping
        public List<List<int>> solve(List<List<int>> A, int B, int C)
        {
            // Initialize Answer Array
            List<List<int>> MergeredList= new List<List<int>>();
            List<int> newInterval=new List<int>() { B,C };
            int i = 0;
            for( i=0; i<A.Count; i++)
            {
                List<int> currentinterval = A[i];
                //Check if new Interval's Range lies before current Interval
                //Currentinterval[0] is Start and Currentinterval[1] is end of interval, similiarly for new Interval
                if (currentinterval[0] > newInterval[1])
                {
                    // new Interval's range lies before current interval, it means we can safely add new interval
                    // Also rest of the other intervals as well into Answer Array.
                    // We will break the loop and do it after this loop
                    break;
                }
                // If new Interval's Start Index does not lies after currentinterval's end it means it is overlapping
                // We are checking the condition if new interval's end is not overlapping in above condition
                else if (!(newInterval[0] > currentinterval[1]))
                {
                    //If overlapped, then Merge these two intervals by updating newIntervals range.
                    //Starting index should be minimum of both's starting index
                    newInterval[0] = Math.Min(currentinterval[0], newInterval[0]);
                    //End index should be maximum of both's end index
                    newInterval[1] = Math.Max(currentinterval[1], newInterval[1]);
                    //At final we will not insert this newInterval in our answer, because there might be cases if
                    // Other intervals are now overlapping with the new Interval, so we will continue the process.
                }
                // if above both conditions are not satisfied, it means current interval is not overlapping and new interval
                // will be added some where after this interval, so it is safe to add current interval to the answer
                else
                {
                    // Add current interval to the answer array
                    MergeredList.Add(currentinterval);
                }
            }
            // This will execute when new Interval comes before current interval(currentinterval[0] > newInterval[1]), After loop breaks
            // Means add new Interval in Answer and rest of the intervals as well.
            // Add new Interval in Answer
            MergeredList.Add(newInterval);
            // Add rest of the Intervals in Answer Array, when loop breaks, we will capture the ith value and insert all intervals after i till n
            for (int j = i; j < A.Count; j++)
            {
                MergeredList.Add(A[j]);
            }
            return MergeredList;
        }
    }
}
