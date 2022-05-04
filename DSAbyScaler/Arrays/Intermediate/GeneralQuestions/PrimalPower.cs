using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    //"Primal Power" of an array is defined as the count of prime numbers present in it.

    //Given an array of integers A of length N, you have to calculate its Primal Power.
    internal class PrimalPower
    {

        // Check each number is prime number or not.
        public bool prime(int num)
        {
            // In this question, 1 is not a prime number, so if number is less than 2, result will be false.
            if (num < 2) return false;
            // we will check if the number is divisible by any number between 2 to Sqrt of number than it will not be prime number.
            // why sqrt root. ex: num =16, its factors are 2*8, 4*4 8*2, so we can see that if we check till sqrt which is 4.
            // if the number is divisble by 2 than it will be definetly divisble by 8 as well, so no need to check after sqrt
            for(int i = 2; i <= Math.Sqrt(num); i++)
            {
                if(num % i == 0) return false;
            }
            // if the number is not divisible till sqrt than it means it is not divisble by any number but itself, hence prime number
            return true;
        }
        public int solve(List<int> A)
        {
            int count = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] >= 0)
                {
                    if (prime(A[i]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
