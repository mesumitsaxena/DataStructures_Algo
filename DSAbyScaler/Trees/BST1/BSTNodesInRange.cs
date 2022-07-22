using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.BST1
{
    //Given a binary search tree of integers.You are given a range B and C.

    //Return the count of the number of nodes that lie in the given range.
    //Example Input
    //Input 1:

    //            15
    //          /    \
    //        12      20
    //        / \    /  \
    //       10  14  16  27
    //      /
    //     8

    //     B = 12
    //     C = 20
    //Input 2:

    //            8
    //           / \
    //          6  21
    //         / \
    //        1   7

    //     B = 2
    //     C = 20


    //Example Output
    //Output 1:

    // 5
    //Output 2:

    // 3
    internal class BSTNodesInRange
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // we will do normal preorder or postorder traversal
        // or we can do bottom up or top down approach to check the range of each node
        public int solve(TreeNode A, int B, int C)
        {
            //lets do it in Postorder or bottom up approach
            if (A == null) return 0;
            //store the count from left subtree
            int leftCount = solve(A.left, B, C);
            //store the count of right subtree
            int rightCount = solve(A.right, B, C);
            //then check if current node is valid or not, if yes then return left+right count + 1(current node count)
            if(B<=A.val && A.val <= C)
            {
                return leftCount + rightCount + 1;
            }
            //else only return left and right subtree count
            return leftCount + rightCount;
        }
    }
}
