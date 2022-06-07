using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.BinarySearch3
{
    //Given 2 integers A and B and an array of integers C of size N.Element C[i] represents the length of ith board.
    //You have to paint all N boards [C0, C1, C2, C3 … CN-1]. There are A painters available and each of them takes B units of time to paint 1 unit of the board.


    //Calculate and return the minimum time required to paint all boards under the constraints that any painter will only paint contiguous sections of the board.
    //NOTE:
    //1. 2 painters cannot share a board to paint.That is to say, a board cannot be painted partially by one painter, and partially by another.
    //2. A painter will only paint contiguous boards.This means a configuration where painter 1 paints boards 1 and 3 but not 2 is invalid.

    //Return the ans % 10000003.
    internal class PainterPartitionProblem
    {
        // N boards has to be painted, this is mandatory to paint all the boards
        // we are given with A workers, find minimum time required to paint all the boards with given workers
        // time can be find as unit of board(C[i])*time taken per unit of board(B)
        // what can be maximum time , if there is only 1 worker and he has to paint all the boards, so maximum time will be sum of all units of board *B
        // what can be minimum time, if there are N workers for N boards, so minimum time will be maximum unit of board * B
        // we can apply binary search with minimum time and maximum time and check if it is possible to paint all the boards in mid amount of time with given worker or not?
        // suppose we are not able to paint all the board with given worker, it means we are not giving enough boards to workers that is why boards are left
        // so we can try giving more boards to workers
        // if we are able to paint all the boards with given workers, it means now we got the answer, but lets check if we give little lesser time to workers
        // and still they are able to complete all the boards or not? as we have to minimize the time
        // So basically we need to find the minimum time by painters to complete all the boards, so minimum time will the time which was taken by a painter which took maximum time.
        // because all the other painter can paint the boards simulteously
        // its like FFFFFTTTTTTTTT, we have to find first T
        public int paint(int A, int B, List<int> C)
        {
            //define minimum number of time
            long minimumTime = Int32.MinValue;
            //define maximum number of time
            long maximumTime = 0;
            for(int i=0; i<C.Count; i++)
            {
                //as minimum number if unit will be maximum of the board, because if there are N worker for N Boards
                // then minimum unit taken to complete whole job will be to paint maximum unit of board
                minimumTime=Math.Max(minimumTime, C[i]);
                // maximum unit will be sum of all unit of board becasue of only 1 worker is there then he will haev to paint all the boards
                maximumTime += C[i];
            }
            
            // now minimum time will be minimum unit to paint all the boards * time to paint each board
            long left = minimumTime * B;
            // now maximum time will be maximum unit to paint all the boards * time to paint each board
            long right = maximumTime * B;
            // if there is only 1 painter than he will be doing all the job
            if (A == 1) return (int)(right % 10000003);
            long minimumTimeToPaint = 0;
            while (left <= right)
            {
                long mid=(left+right)/2;
                //check if we are able to paint all the boards with mid amount of time
                // if yes then it can be out answer but also check for little minimum time
                if (checkPainter(C,A,B,mid)){
                    minimumTimeToPaint = mid;
                    right = mid - 1;
                }
                // if we are not able to paint all the boards with mid amount of time with A workers
                // it means we are not giving enough boards to workers, give little more boards(units) so that time can also increase
                else
                {
                    left = mid + 1;
                }
            }
            return (int)(minimumTimeToPaint% 10000003);
        }
        public bool checkPainter(List<int> C,int A,int B, long mid)
        {
            //start with painter 1
            long painter = 1;
            long currentboard = 0;
            for(int i = 0; i < C.Count; i++)
            {
                // addition of next board, if  time is greater than the time we expected than 
                // assign next board to next painter
                if (currentboard + C[i]*B > mid)
                {
                    currentboard = C[i]*B;
                    painter++;
                }
                // if time which we expected is greater than addition of next board, means we can assign this board to 
                // current painter
                else
                {
                    currentboard += C[i]*B;
                }
            }
            // if total painters took to complete the task with mid time is less than or equal to A than it is possible
            if (painter <= A) return true;
            // if number of painter is used more it means which can not complete the task with given painter with mid amount of time
            return false;

        }
    }
}
