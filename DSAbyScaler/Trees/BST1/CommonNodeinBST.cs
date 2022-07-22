using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.BST1
{
    //    Given two BST's A and B, return the (sum of all common nodes in both A and B) % (109 +7) .

    //In case there is no common node, return 0.

    //NOTE:

    //Try to do it one pass through the trees.
    //Example Input
    //Input 1:

    // Tree A:
    //    5
    //   / \
    //  2   8
    //   \   \
    //    3   15
    //        /
    //        9

    // Tree B:
    //    7
    //   / \
    //  1  10
    //   \   \
    //    2  15
    //       /
    //      11
    //Input 2:

    //  Tree A:
    //    7
    //   / \
    //  1   10
    //   \   \
    //    2   15
    //        /
    //       11

    // Tree B:
    //    7
    //   / \
    //  1  10
    //   \   \
    //    2  15
    //       /
    //      11


    //Example Output
    //Output 1:

    // 17
    //Output 2:

    // 46


    //Example Explanation
    //Explanation 1:

    // Common Nodes are : 2, 15
    // So answer is 2 + 15 = 17
    //Explanation 2:

    // Common Nodes are : 7, 2, 1, 10, 15, 11
    // So answer is 7 + 2 + 1 + 10 + 15 + 11 = 46
    internal class CommonNodeinBST
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // Simple solution is take one node from one tree and search it in another tree
        // if doesnt exist dont add in answer, else add it in answer
        public int solve(TreeNode A, TreeNode B)
        {
            if (A == null) return 0;
            // traverse the tree in any form, Inorder, Preorder or Postorder and search it in B
            // lets go with PostOrder
            long leftAnswer = solve(A, B);
            long rightAnswer = solve(A, B);
            if (Search(A.val, B))
            {
                return (int)((leftAnswer + rightAnswer + (long)A.val)% 1000000007);
            }
            return (int)((leftAnswer + rightAnswer)% 1000000007);
        }
        public bool Search(int B, TreeNode A)
        {
            //Search in the tree, 
            TreeNode temp = A;
            // move until null doesn't come
            while (temp != null)
            {
                // if value found then return
                if(temp.val == B)
                {
                    return true;
                }
                // if value is smaller than node, then move left
                if (temp.val > B)
                {
                    temp = temp.left;
                }
                // if values is greater than node, then move right  
                else
                {
                    temp = temp.right;
                }
            }
            return false;
        }
    }
}
