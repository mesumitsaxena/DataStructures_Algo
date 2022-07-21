using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees1
{
    //Given a binary tree, return the Postorder traversal of its nodes' values.
    //    Example Input
    //Input 1:

    //   1
    //    \
    //     2
    //    /
    //   3
    //Input 2:

    //   1
    //  / \
    // 6   2
    //    /
    //   3


    //Example Output
    //Output 1:

    // [3, 2, 1]
    //    Output 2:

    // [6, 3, 2, 1]


    //    Example Explanation
    //Explanation 1:

    // The Preoder Traversal of the given tree is [3, 2, 1].
    //Explanation 2:

    // The Preoder Traversal of the given tree is [6, 3, 2, 1].
    internal class PostOrderTreversal
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // Same as Inorder, only thing is order changes


        // Recurse left subtree
        // Recurse right subtree
        // process node
        public List<int> postorderTraversal(TreeNode A)
        {
            // we are preparing the list for each recursive call
            List<int> inOrderList = new List<int>();
            // if list is empty, return empty list
            if (A == null) return inOrderList;

            // Add all the left side data because left recursion call will return the list
            // example: if A is leaf node, So it will be return empty list. So current list will add no values
            // suppose if A is not leaf node, it means it will return some list of data, as we have created empty list
            // we will add all the left data into our current list
            inOrderList.AddRange(postorderTraversal(A.left));

            // Add all the right side data because right recursion call will return the list
            // example: if A is leaf node, So it will be return empty list. So current list will add no values
            // suppose if A is not leaf node, it means it will return some list of data, as we have created empty list
            // we will add all the left data into our current list
            inOrderList.AddRange(postorderTraversal(A.right));

            // add the current element
            inOrderList.Add(A.val);
            // return the list
            // this will return return list of data to previous function calls, which will be added in the previous function call list
            return inOrderList;
        }
    }
}
