using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees1
{
    //Given a binary tree, return the Postorder traversal of its nodes' values.
    //Input Format
    //First and only argument is root node of the binary tree, A.



    //Output Format
    //Return an integer array denoting the Postorder traversal of the given binary tree.



    //Example Input
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
    internal class preOrderTraversal
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // Same as Inorder, only thing is order changes

        // process node
        // Recurse left subtree
        // Recurse right subtree
        public List<int> preeorderTraversal(TreeNode A)
        {
            // we are preparing the list for each recursive call
            List<int> inOrderList = new List<int>();
            // if list is empty, return empty list
            if (A == null) return inOrderList;

            // add the current element
            inOrderList.Add(A.val);
            // Add all the left side data because left recursion call will return the list
            // example: if A is leaf node, So it will be return empty list. So current list will add no values
            // suppose if A is not leaf node, it means it will return some list of data, as we have created empty list
            // we will add all the left data into our current list
            inOrderList.AddRange(preeorderTraversal(A.left));
            
            // Add all the right side data because right recursion call will return the list
            // example: if A is leaf node, So it will be return empty list. So current list will add no values
            // suppose if A is not leaf node, it means it will return some list of data, as we have created empty list
            // we will add all the left data into our current list
            inOrderList.AddRange(preeorderTraversal(A.right));
            // return the list
            // this will return return list of data to previous function calls, which will be added in the previous function call list
            return inOrderList;
        }
    }
}
