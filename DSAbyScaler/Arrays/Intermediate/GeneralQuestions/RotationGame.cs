using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Arrays.Intermediate.GeneralQuestions
{
    /*  Given an integer array A and an integer B, you have to print the same array after rotating it B times towards the right.
        NOTE: You can use extra memory.
     * */
    internal class RotationGame
    {
       
        public List<int> rotate(List<int> list, int k)
        {
            // in order to rotate the list rotationcount times towards right, there are two steps-
            //Reverse the array
            //reverse the first K elements in list
            //reverse rest of the elements in list

            //Reverse the Array
            int leftindex = 0; //First Index
            int rightindex = list.Count-1;//Last Index
            while(leftindex < rightindex)
            {
                //Swap left and right index value and move increment towards left, also move one step from right
                Swap(leftindex, rightindex, list);
                leftindex++;
                rightindex--;
            }
            //Catching point - If K is more than List count, then we can use K%listcount
            k=k%list.Count;
            //reverse the first K elements in list
            leftindex = 0;
            rightindex =  (k-1);
            while (leftindex < rightindex)
            {
                //Swap left and right index value and move increment towards left, also move one step from right
                Swap(leftindex, rightindex, list);
                leftindex++;
                rightindex--;
            }

            //reverse rest of the elements in list
            leftindex = k;
            rightindex = list.Count - 1;
            while (leftindex < rightindex)
            {
                //Swap left and right index value and move increment towards left, also move one step from right
                Swap(leftindex, rightindex, list);
                leftindex++;
                rightindex--;
            }

            //list is now rotated k times, return the list
            return list;
        }
        public void Swap(int fromindex, int toIndex, List<int> list)
        {
            int temp = list[fromindex];
            list[fromindex] = list[toIndex];
            list[toIndex] = temp;
        }
    }
}
