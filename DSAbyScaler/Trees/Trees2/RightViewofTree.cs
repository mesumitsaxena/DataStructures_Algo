using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Problem Description
    //Given a binary tree of integers denoted by root A.Return an array of integers representing the right view of the Binary tree.

    //Right view of a Binary Tree is a set of nodes visible when the tree is visited from Right side.
    //Example Input
    //Input 1:


    //            1
    //          /   \
    //         2    3
    //        / \  / \
    //       4   5 6  7
    //      /
    //     8 
    //Input 2:


    //            1
    //           /  \
    //          2    3
    //           \
    //            4
    //             \
    //              5


    //Example Output
    //Output 1:

    // [1, 3, 7, 8]
    //    Output 2:

    // [1, 3, 4, 5]


    //    Example Explanation
    //Explanation 1:

    //Right view is described.
    //Explanation 2:

    //Right view is described.
    internal class RightViewofTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        //it is same as left view, only thing is, when adding the children.
        // Instead of adding left children first, add righ child first
        public List<int> solve(TreeNode A)
        {
            Queue<TreeNode> leftViewTree = new Queue<TreeNode>();
            List<int> result = new List<int>();
            leftViewTree.Enqueue(A);
            leftViewTree.Enqueue(null);
            TreeNode prev = null;
            while (leftViewTree.Count > 1)
            {
                TreeNode node = leftViewTree.Peek();
                // if prev is null, means node is first node of this level
                if (prev == null)
                {
                    // we can access node as node can not be null if prev is null
                    result.Add(node.val);
                }
                if (node == null)
                {
                    // if node is null, then same process as level order
                    // remove null from front
                    leftViewTree.Dequeue();
                    // add null into rear as it represents all the childrens are added into queue
                    leftViewTree.Enqueue(null);
                    // assign current node to previous
                    prev = node;
                    // do not process next code as node is null so null cant have next and right
                    continue;
                }
                // add right child first instead of left
                if (node.right != null) leftViewTree.Enqueue(node.right);
                // add left child
                if (node.left != null) leftViewTree.Enqueue(node.left);
                // assign current node to previous so that we can verify if last is null or not
                prev = node;
                // fianlly remove front
                leftViewTree.Dequeue();
            }
            return result;
        }
    }
}
