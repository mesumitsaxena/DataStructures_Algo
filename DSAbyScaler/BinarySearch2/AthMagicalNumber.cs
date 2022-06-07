using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch2
{
    //You are given three positive integers, A, B, and C.

    //Any positive integer is magical if divisible by either B or C.

    //Return the Ath smallest magical number.Since the answer may be very large, return modulo 109 + 7.
    internal class AthMagicalNumber
    {
        // This Question can be solved using observation only.
        // Now, lets start with the basic approach, if we say 100 has how many factors of 2? we know its 50, 100/2
        // if we say 100 has how many facors of 3? we know its 33, 100/3
        // but what if we say 100 has how many factors of 2 or 3? then? no its not 100/2+100/3. because there are few factors which are repeating
        // because 2 and 3 can have few common factors. so how do we find it? its simple, we can take LCM of 2 and 3 which tell us common factors of 2 and 3
        // So 100 has factors of 2 or 3 are 100/2+100/3-100/LCM(2,3)
        // Now lets approach to the question, question says find Ath element which is divisble by 2 or 3
        // ex: if we say find 6th factor of 2 -> then factors of 2 are 2 4 6 8 10 12 14 16 18 ..... so 6th factor is 12(and this is magical number)
        // ex: find 6th factor of 3 -> 3 6 9 12 15 18 21 24 27.... so 6th factor is 18(magical number)
        // but if we say find 6th factor of 2 or 3 then, lets understad with an example below (factors of 2 or 3)-
        // 2(factor of 2) 3(factor of 3) 4(factor of 2) 6(factor of 2 and 3) 8(factor of 2) 9(factor of 3) 10(factor of 2) 12(factor of 2 and 3) 14(factor of 2) 15(factor of 3) 16(factor of 2) 18(factor of 2 and 3) 20(factor of 2) 21(factor of 3) .....
        // so 6th factor of 2 or 3 is 9(magical number)

        // Solution Approach
        // lets try with each number(x) from 1 till somewhere and check how many factors does x has with 2 or 3? how to check?
        // Above formula -> x/2+x/3-x/LCM(2,3), but that is long process,
        // we can do binary search to make it fast, we can find a middle number and check how many factors it has? if it is A then x is magical number
        // Now how do we decide the range?
        //Factors of  2 or 3											
        //1	2	3	4	5	6	7	8	9	10	11	12
        //2	3	4	6	8	9	10	12	14	15	16	18
        // So we can see 5th multiple of 2 is 10, but 5th multiple of 2 or 3 is 8 only,
        // this is because multiple of 3s are also added in the list with 2.
        // So Max range will be min(2,3)*5 or general term min(B,C)*A will be enough
        public long LCM(long a, long b)
        {

            long x = Math.Min(a, b);
            long y = Math.Max(a, b);

            while (x > 0)
            {
                long rem = y % x;
                y = x;
                x = rem;
            }

            long gcd = y;
            return (a * b) / gcd;
        }
        public int solve(int A, int B, int C)
        {
            long mod = 1000000007;
            long minValue = Math.Min(B, C);
            // Define minimum Range
            long minRange = minValue;
            // Define Maximum Range
            long maxRange = minValue * A;
            long LCMofBC = LCM(B, C);
            long magicalNumber = 0;
            while (minRange <= maxRange)
            {
                long mid = (minRange + maxRange) / 2;
                // Check number of factors with mid
                long numbersofFactors = (mid / B) + (mid / C) - (mid / LCMofBC);
                if (numbersofFactors == A)
                {
                    // if number of factors are equal to A, then mid can be our answer but lets check on left side for better answer, why?
                    // 	Factors of  2 or 3											
                    //                    1   2   3   4   5   6   7   8   9   10  11  12
                    //                    2   3   4   6   8   9   10  12  14  15  16  18
                    //(Factors of 2 or 3) 1   1   2   2   3   3   5   6   7   8   8   9
                    // as we can see 5th number has number of fctor of 2 or 3 is 3 but we also has 6th number also which has number of factor as 3.
                    // that is why we need to most accurate means where it is starting to get 3
                    magicalNumber = mid;
                    maxRange = mid - 1;
                }
                else if (numbersofFactors < A)
                {
                    // if number of factors with mid is <A means answer will be after mid
                    minRange = mid + 1;
                }
                else
                {
                    // if number of factors with mid is >A means answer will be before mid
                    maxRange = mid - 1;
                }

            }
            return (int)(magicalNumber % mod);
        }
    }
}
