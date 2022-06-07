using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch3
{
    //The government wants to set up B distribution offices across N cities for the distribution of food
    //ackets.The population of the ith city is A[i]. Each city must have at least 1 office,
    //and people can go to an office of their own city.We want to maximize the minimum number of people who can
    //get food in any single office.
    internal class FoodPacketsDistribution
    {
        //Lets understand this, So there are N Cities and each city has some population
        // we need to find open at least 1 office in each cities so that minimum number of people goes to office is maximum.
        // we are given with B offices to be open across all cities

        // Lets understand few scenario, we can open 1 office in each city but we have to open B number of offices in all the city
        // So if number of offices which can open is < B then it is a invalid situation, we have to open atleast B offices.
        // Now what do we mean by maximum number of people goes to one office should be minimum?
        // Lets say we open 9 office in 5 cities and goverment wants to open 6 offices, then it is a valid situation because number of people
        // will be ditributed among extra offices, but we have to minimize the offices and maximimze the number of people goes to office
        // Suppose we say K is the minimum number of people goes to B offices, so we will check we have to maximize the K.
        // how to calculate number of offices we can open if K people goes to each city, simple, A[0]/k+A[1]/k+A[2]/k=number of offices we can open with K people in each city
        // so if the number of offices are 7 with K but we need to open 8 offices, then its not valid lets take K little less so that we can open little more offices
        // other wise 1 city will not be able to serve peoples
        // if number of offices are 9 with k people and we need to open 8 offices, it means we are able to feed every people, so that can be my answer and lets check for better answer with little more people per city

        // now what could be minimum number of people and what could be maximum number of people?
        // minimum number of people can be 1 because if we have to open 1 office in each city and people are also 1 then minimum number can be 1
        // maxmimum number of people can be minimum population in all cities
        // because if we can open more offices than B than maximum number of people can go to 1 office would be minimum of any city

     
        public int solve(List<int> A, int B)
        {
            int upperRange = Int32.MaxValue;
            for (int i = 0; i < A.Count; i++)
            {
                if (upperRange > A[i])
                {
                    upperRange = A[i];
                }
            }
            // Initiaze minimum and maximum range
            int l = 1;
            int r = upperRange;
            int numberofpeople = 0;
            // Check while we get minimum number if people go to office to take food
            while (l <= r)
            {
                // check with middle
                int mid = (l + r) / 2;
                // if given mid is number of people, can we open valid offices?
                // If yes than that could be our answer but maximize the answer we will look for better answer on little more population
                if (check(A, B, mid))
                {
                    numberofpeople = mid;
                    l = mid + 1;
                }
                // if given mid of number of people, we can not even open required offices, than we should try with less population per city
                else
                {
                    r = mid - 1;
                }
            }
            return numberofpeople;
        }
        public bool check(List<int> A, int B, int mid)
        {
            // Calculate total number of offices we can open with given population per city
            int numberofoffices = 0;
            for (int i = 0; i < A.Count; i++)
            {
                // Calculate number of office per city
                numberofoffices += A[i] / mid;
            }
            // if total number of offices which we can open are greater than we want, than great we can feed all number of people in all citties
            if (numberofoffices >= B) return true;
            // if total number of offices which we can open among all cities are lesser than we want then definetly we cant feed the populations of atleast 1 city or where we didn't opent the office
            return false;
        }
    }
}
