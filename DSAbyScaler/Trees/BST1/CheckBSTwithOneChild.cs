using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.BST1
{
    //Given preorder traversal of a binary tree, check if it is possible that it is also a preorder traversal of a Binary Search Tree(BST),
    //where each internal node(non-leaf nodes) have exactly one child.
    //Example Input

    //Input 1:

    // A : [4, 10, 5, 8]
    //    Input 2:

    // A : [1, 5, 6, 4]


    //    Example Output

    //Output 1:

    // "YES"
    //Output 2:

    // "NO"


    //Example Explanation

    //Explanation 1:

    // The possible BST is:
    //            4
    //             \
    //             10
    //             /
    //             5
    //              \
    //              8
    //Explanation 2:

    // There is no possible BST which have the above preorder traversal.
    internal class CheckBSTwithOneChild
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // Basic solution is construct a BST and then check if BST is valid or not
        public string solve(List<int> A)
        {
            TreeNode root = new TreeNode(A[0]);

            TreeNode temp = root;
            for (int i = 1; i < A.Count; i++)
            {
                TreeNode node = new TreeNode(A[i]);
                if (A[i - 1] > A[i])
                {
                    temp.left = node;
                    temp = node;
                }
                else
                {
                    temp.right = node;
                    temp = node;
                }
            }
            if (isValid(root, Int32.MinValue, Int32.MaxValue))
            {
                return "YES";
            }
            return "NO";
        }
        public bool isValid(TreeNode A, int l, int r)
        {
            if (A == null) return true;
            if (l <= A.val && A.val <= r)
            {
                bool leftValid = isValid(A.left, l, A.val - 1);
                bool rightValid = isValid(A.right, A.val + 1, r);
                return leftValid && rightValid;
            }
            return false;
        }
    }
}
