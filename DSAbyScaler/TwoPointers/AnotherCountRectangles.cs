using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.TwoPointers
{
    //Given a sorted array of distinct integers A and an integer B, find and return how many rectangles with distinct configurations can be created using elements of this array as length and breadth whose area is lesser than B.

    //(Note that a rectangle of 2 x 3 is different from 3 x 2 if we take configuration into view)



    //Problem Constraints

    //1 <= |A| <= 100000
    //1 <= A [i] <= 109
    //1 <= B <= 109
    //Example Input

    //Input 1:

    // A = [1, 2]
    //    B = 5
    //Input 2:

    // A = [1, 2]
    //    B = 1


    //Example Output

    //Output 1:

    // 4
    //Output 2:

    // 0
    internal class AnotherCountRectangles
    {
        // As we needed to calculate the area, we can also include same elements as well. like 2*2=4<3 something like this
        // So first of all calculate the area of all individual elements and then compoistion of elements.
        // what do we mean by composition of elmenets -> example: 1 2 3 4 5, and B is 8, so we need to find the number of rectangles can be 
        // form with area less than 8, so first of all 1*1<8, 2*2<8, but 3*3 not less than 8 so will not count
        // now lets come to composition elements 1*2<8, 1*3<8, 1*4<8, 1*5<8, 2*3<8, 2*4 not less than 8 etc
        // How to calculate composition, if we know 1 and 5 can make area <8, it means 1 with the greatest element can form the area<8
        // So it can also form the area with less than 5 elements as well, so instead of iterate and check, we know array is sorted
        // So we will calculate number of elements i.e count between left and right pointer by (right-left), now try with next greater element from left
        // and 1*5 is not able to find, then we will decrease the right
        // As in the question it is mentioned, that 2*3 and 3*2 is not same, so we will multiply compostecount by 2
        public int solve(List<int> A, int B)
        {
            int mod = 1000000007;
            int aloneCount = 0;
            //Calculate Alone Count, example: 1 2 3, and B=5, so 1*1<5, 2*2<5, etc 
            for(int i = 0; i < A.Count; i++)
            {
                long element = A[i];
                long area=element*element;
                if (area < B)
                {
                    aloneCount++;
                }
            }
            int compositeCount = 0;
            int left = 0;
            int right=A.Count - 1;
            // now for composite count, we will put out pointers at opposite end.
            // So that we can the idea, if area is possible between 2 elmenets, it means it will also be possible with 
            // other elements between them, example : 1 2 3 4, B=3, so 1*4<3, it means 1 with 2 and 3 also possible.
            // so we will include their count with calculating them.
            while(left < right)
            {
                long leftElement = A[left];
                long rightElement = A[right];
                long area=leftElement*rightElement;
                if (area < B)
                {
                    compositeCount += (right - left);
                    left++;
                }
                else
                {
                    right--;
                }
            }
            long answer = (aloneCount % mod + (2 * compositeCount) % mod) % mod;
            return (int)answer;
        }
    }
}
