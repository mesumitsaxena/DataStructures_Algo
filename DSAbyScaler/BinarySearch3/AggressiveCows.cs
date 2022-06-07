using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch3
{
    //Farmer John has built a new long barn with N stalls.Given an array of integers A of size N
    //where each element of the array represents the location of the stall and an integer B which
    //represents the number of cows.

    //His cows don't like this barn layout and become aggressive towards each other once put into
    //a stall. To prevent the cows from hurting each other, John wants to assign the cows to the stalls,
    //such that the minimum distance between any two of them is as large as possible. What is the largest
    //minimum distance?
    internal class AggressiveCows
    {
        // As we want B cows to be places in N stalls such that minimum distance between two cows should be maximum
        // what do we mean by minimum distance should be maximum? it means we have to keep the cows as far away as we can
        // So that all cows should be placed in the stall.
        // why do we call minimum distance then? because that would be minimum distance: not more than that
        // So Approach : we will try with minimum distance as 1 and check if all the cows can be placed with 1 distance apart?
        // if yes then, as we need minmimum distance should be maximize so we will look for better large answer, so we can try large distances
        // so that would be linear approach becasue we are checking from 1 then 2 ,3 4 .... N(maxmimum distance last stall from first stall)
        // We can try binary search and search space we already know l=1, r=last stall-first stall
        public bool check(List<int> A, int mid, int B)
        {
            // we will always put first cow and first stall then only we will be able to place all the cows maximum distance apart
            // if do not put on first index, its kind of we are wasting that distance which if we include can maximum distance
            int cow = 1;
            int currentstall = A[0];
            for(int i = 1; i < A.Count; i++)
            {
                //if current place-previous stall is greater or equal to distance we are calculating, then we can 
                // place the cow
                if (A[i]-currentstall >= mid)
                {
                    currentstall = A[i];
                    cow++;
                    // check if the all the cows are placed, then we can place all cows at min dist mid
                    if(cow == B)
                    {
                        return true;
                    }

                }
            }
            // if not then return false
            return false;

        }
        public int solve(List<int> A, int B)
        {
            //Sort the stalls first
            A.Sort();
            //lets define search space
            int left = 1;
            // maximum distance can be last stall -first stall, first cow at first stall and other at last
            int minDistance = 0;
            int right = A[A.Count - 1] - A[0];
            while(left <= right)
            {
                int mid= (left + right) / 2;
                //check if we can place cows mid distance apart
                // if yes than, as we need to maximize the answer we will check for better answers on right side(larger distances)
                if (check(A, mid, B))
                {
                    minDistance = mid;
                    left = mid + 1;
                }
                // if we can not place cows with mid distance apart, than lets check with smaller distances, so go to left
                else
                {
                    right = mid - 1;
                }
            }
            return minDistance;
        }
    }
}
