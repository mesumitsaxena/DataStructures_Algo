using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Given a binary tree of integers.Return an array of integers representing the left view of the Binary tree.

    //Left view of a Binary Tree is a set of nodes visible when the tree is visited from Left side

    //NOTE: The value comes first in the array which have lower level.
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

    // [1, 2, 4, 8]
    //    Output 2:

    // [1, 2, 4, 5]


    //    Example Explanation
    //Explanation 1:

    // The Left view of the binary tree is returned.
    internal class LeftViewofBinaryTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // In order to get the left view of the tree, we need elements which are first element of every level.
        // As soon as we see, levels, cant we think of level order traversal and add the first element of each level.

        // So we can create a 2D array and store all levels into it, and then create another 1d array and store 1st element of each level.
        // is it not wasting memory?

        // Optimizse memory approach, is there any way by which we can check this is the 1st element of the level?
        // if we observe while doing level order traversal using queue, when the level is done, we insert null into it.
        // So can we use this information?
        // when the level started, we knew previous element in the queue was null. null represents level end so next element will be starting element of next level.
        // So what we can do to have previous pointer and always store previous node's value.
        // and before processing the current value, check if prev is null then only add current value in 1d array otherwise do the same thing as in level order

        public List<int> solve(TreeNode A)
        {
            Queue<TreeNode> leftViewTree = new Queue<TreeNode>();
            List<int> result = new List<int>();
            leftViewTree.Enqueue(A);
            leftViewTree.Enqueue(null);
            TreeNode prev = null;
            while(leftViewTree.Count > 1)
            {
                TreeNode node = leftViewTree.Peek();
                // if prev is null, means node is first node of this level
                if(prev == null)
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
                // add left child
                if (node.left != null) leftViewTree.Enqueue(node.left);
                // add right child
                if (node.right != null) leftViewTree.Enqueue(node.right);
                // assign current node to previous so that we can verify if last is null or not
                prev = node;
                // fianlly remove front
                leftViewTree.Dequeue();
            }
            return result;
        }
    }
}
