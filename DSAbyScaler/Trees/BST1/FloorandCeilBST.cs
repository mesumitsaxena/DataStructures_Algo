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
    //       3   7     100
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
        // So if K is less than A.val then we will check what is the value of 
        // left of A, it can either be more than K then A.val will be floor, So that is why we need to take Min of left subtree and A.val
        // if left value is again less than K then again check min of left and its left by using recursion
        // if K>A.val, it means floor can be found at right
        // here we will be return Max of A.val and right subtree, why?
        // if K> A.val, then right can give a value which 

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
        public List<List<int>> solve(TreeNode A, List<int> B)
        {
           
        }
    }
}
