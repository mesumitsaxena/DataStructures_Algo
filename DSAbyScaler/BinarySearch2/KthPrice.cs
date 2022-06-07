using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch2
{
    //Given the price list at which tickets for a flight were purchased, figure out the kth smallest price for the flight.kth smallest price is the minimum possible n such that there are at least k price elements in the price list with value <= n.In other words, if the price list was sorted, then A[k-1] (k is 1 based, while the array is 0 based ).
    //NOTE You are not allowed to modify the price list(The price list is read only). Try to do it using constant extra space.

    internal class KthPrice
    {
        // Approach is we sort the array, and return the k-1th element from first :D
        // but we are not allowed to do sorting, so lets think of a solution which can provide atleast NLogN
        // As we know minimum value of Kth minimum number can be the minimum number of the list, means 1st minimum value, can be minimum value of the array.
        // maximum value of kth minimum number can be maximum number in the list, how?
        // think of a Sorted Array - 5 9 17 50
        // if K=1(minimum value or 1st minimum value) so it will be minimum value in the array which is 5
        // if K=4(maxmimum value or 4th minimum value) so it will be maximum value in the array which is 50
        // so as our ranges are figured out, lets see how can we check.
        // Lets check with minimum value and check if it is our answer
        // lets have an array as 9 17 50 5 and K=3, means we have to find 3rd minimum element in array which is 17
        // lets check with 5 and see if this is our answer, how?
        // check in the array how many elements are there less than or equal to 5, if number of elements are greater than or equal to 3
        // it means it can be our answer, if there are number of elements which are greater or equal to 5 are more than 3,
        // than defntly 6 and more value will also have number of elements greater than 3, so record that answer and lets check
        // values less than 5 maybe 4
        // but here in this case no there are elements which are less than equal to 5 are only 1, so this cant be my answer, lets check for 6
        // so by this we have to check 6, 7 , 8 , 9 etc untill 17 as 17 is our answer.
        // so this O(N^2) Approach. ( first will be iterative loop on range, and N will be to check how many elements >=B)
        // lets do a Binary search as we know the ranges, so N will be logn and extra N for iterative loop to check if 
        // with given predicted answer if it is giving count which is greater or equal to B( which is if number of elements are greater than Kth minimum value)
        public int solve(List<int> A,int B)
        {
            //define left range
            int leftLimit = int.MaxValue;
            //define right range
            int rightLimit = int.MinValue;
            //final kthPrice
            int kthPrice = 0;
            //calculate minimum and maximum range
            for(int i = 0; i < A.Count; i++)
            {
                leftLimit=Math.Min(leftLimit, A[i]);
                rightLimit=Math.Max(rightLimit, A[i]);
            }
            //Binary Search Logic
            while (leftLimit <= rightLimit)
            {
                //Predict the answer by taking mid range value
                int predictAnswer=(leftLimit+rightLimit)/2;
                //check if predicted kth value have number of elements greater or equal to B
                // if yes, tham it can be our answer, so lets store it and check better answer on left, becasue
                // if total number of elements which are less than equal to predictAnswer are greater than B, than
                // more greater numbers can also be greater than B , ex:  1 2 3 4 5, if predictanswer =3 has elements greater than 2,
                // than definatly 4 will have more greater count, so we will look at left
                if (check(A,predictAnswer,B)){
                    kthPrice = predictAnswer;
                    rightLimit = predictAnswer - 1;
                }
                // if number of elements which are <=predictAnswer are <B, than it cantbe even answer, becasue 12345 we say B=3 means we want 3rd
                //minimum price, and predict answer is 2, it is not having elements which are less than equal to 2 is more than equal to 3,
                //// so it cant be my answer and even less values cant be my answer, so lets look on the right side
                else
                {
                    leftLimit = predictAnswer + 1;
                }
            }
            return kthPrice;
        }

        private bool check(List<int> a, int predictAnswer, int b)
        {
            int countThanPredict = 0;
            for(int i = 0; i < a.Count; i++)
            {
                // count the elements which are less than equal to predictAnswer
                if (a[i] <= predictAnswer)
                {
                    countThanPredict++;
                }
            }
            // if count is grater than or equal to b, it can be my answer, lets return true.
            if (countThanPredict >= b) return true;
            return false;
        }
    }
}
