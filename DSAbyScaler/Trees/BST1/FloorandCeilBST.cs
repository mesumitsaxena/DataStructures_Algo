using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.BST1
{
    //Given a Binary Search Tree rooted at A.

    //Given an integer array B of size N.Find the floor and ceil of every element of the array B.

    //Floor(X) is the highest element in the tree <= X, while the ceil(X) is the lowest element in the tree >= X.

    //NOTE: If floor or ceil of any element of B doesn't exists, output -1 for the value which doesn't exists.
    //Example Input

    //Input 1:

    //Given Tree A:
    //           10
    //         /    \
    //        4      15
    //       / \
    //      1   8
    //B = [4, 19]
    //    Input 2:

    //Given Tree A:
    //            8
    //          /   \
    //         5     19
    //        / \     \
    //       4   7     100
    //B = [1, 11]


    //    Example Output

    //Output 1:

    //[
    //    [4, 4]
    //    [15, -1]
    //]
    //Output 2:

    //[
    //    [-1, 4]
    //    [8, 19]
    //]
    internal class FloorandCeilBST
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // we need to create Floor and Ceil methods first
        // Floor : 
        // So floor of the value will be calculated as - 
        // 1.) we will start from the root, if K is less then root then go on left
        // 2.) if K is greater than root then go right
        // 3.) if K is equal to root return K
        // Continue this process until K is not found or we reach to null
        // what if we reach to null? it means the value is not found in the BST, 
        // then what to return how do we decide that?
        // That will be decided when we return the values from recursive calls.
        // if node is null then return -1, because node not found, Now how to manage to return the floor?
        // when we are returning the value from left subtree, then take Min of node and value which is returned by previous 
        // recursive calls, and if we are returning from right subtree, then Max of node and value which is returned by previous 
        // recursive calls, why? becasue we need a value which is just less than or equal to K
        // As we know left has min than root and right.
        // Lets take an example and understand the concept-
        // Given Tree A:
        //            8
        //          /   \
        //         6     19
        //        / \     \
        //       3   9     100
        // B = [7, 11]
        // So 7 is less than 8, So we will go to left, but 7 is greater than 6.
        // So we will go to right, now right of 6 can have more greater value than 7(here in this case this is 9).
        // So, That is why we will take minimum of (root(8), left of 8(6,9))= 6
        // Same way we will take max from right, take an example of 11, 
        // we are on 8(root node), 11 is greater than 8, So move to right, As right can have values greater than 8(root).
        // but less than K(11), here 19 in this case, Now it will check on left of 19, which will return -1, and as it -1 is returned
        // from left and minimum of -1 and 19 is -1 and -1 will be returned to 8 from right, So max(-1,8)= 8.

        // Ceil:
        // So in Ceil, we need to give the next greater or equal to K value
        // Lets take the above example again
        // Given Tree A:
        //            8
        //          /   \
        //         6     19
        //        / \     \
        //       3   9     100
        // B = [7, 11]
        // we will do same thing only diff will be instead of -1 we will return IntMax, why? because
        // we need min value in floor so we return -1 which is minium of all, but we need greater value in Ceil
        // So we return max value, So that we can determine if the greatest value
        // when we return any value either from left and right IntMax will help, how?
        // when there is no node(null), then we will send most greteast value, and when we need the value which is just greater

        // Simple way to learn -
        // for Floor - Steps:
        // Check if A.val==K
        // if K<A.val, go to left of root and the get the minimum of A.val with value returned from left and return
        // else, go to right of root and get the maxmimum of A.val with value returned from right and return
        // if A is null return -1, as we need to check the just minimum value of K

        // Simple way to learn -
        // for Ceil - Steps:
        // Check if A.val==K
        // if K<A.val, go to left of root and the get the minimum of A.val with value returned from left and return
        // else, go to right of root and get the maxmimum of A.val with value returned from right and return
        // if A is null return InTMax, as we need to check the just greater value of K

        // Another Observation: Returning -1 in Floor means there is no value on left or right
        // how -1 will help us? if K is the value which does not exist in BST but also doesnt come in between of any of the node
        // then returning -1 from left and then taking min will lead to -1 itself till root.
        // but what if K does exist in between of any of the two nodes, then definetly we will go to right at any point of time
        // then will take min(-1, right node)=-1 and returning -1 from right and taking max(parentnode, -1)= parent node
        // it means if node is the floor then we will not go on left becasue its value will be smaller than K
        // So we will move to right and its value can also be larger than k, so that is why some how we will move to right
        // and then Math.Min will do its trick
        // Same with ceil

        public int Floor(TreeNode A, int K)
        {
            if (A == null) return -1;
            if (A.val == K) return K;
            else if (K < A.val)
            {
                return Math.Min(A.val, Floor(A.left, K));
            }
            return Math.Max(A.val,Floor(A.right, K));
        }
        public int Ceil(TreeNode A, int K)
        {
            if (A == null) return Int32.MaxValue;
            if (A.val == K) return K;
            else if (K < A.val)
            {
                return Math.Min(A.val, Ceil(A.left, K));
            }
            return Math.Max(A.val, Ceil(A.right, K));
        }
        public List<List<int>> solve(TreeNode A, List<int> B)
        {
            List<List<int>> ans = new List<List<int>>();
            for (int i = 0; i < B.Count; i++)
            {
                int floor = Floor(A, B[i]);
                int ceil = Ceil(A, B[i]);
                if (ceil == Int32.MaxValue)
                {
                    ceil = -1;
                }
                ans.Add(new List<int>() { floor, ceil });
            }
            return ans;
        }
    }
}
