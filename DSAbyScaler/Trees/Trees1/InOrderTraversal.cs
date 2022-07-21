using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees1
{
    //Given a binary tree, return the inorder traversal of its nodes' values.
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

    // [1, 3, 2]
    //    Output 2:

    // [6, 1, 3, 2]


    //    Example Explanation
    //Explanation 1:

    // The Inorder Traversal of the given tree is [1, 3, 2].
    //Explanation 2:

    // The Inorder Traversal of the given tree is [6, 1, 3, 2].
    internal class InOrderTraversal
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // In order traversal is 3 step process.
        // Recurse on the left side 
        // process the node
        // Recurse on the right side.

        // When we reach the leaf node, then start returning the answers.
        // So first thing, we will recurse until we reach null on left side
        // then process the leaf node
        // then recurse untill we reach null on right side
        // one recursion call is completed and pointer will move to previous recursion stack.
        // then previous node will be process
        // and then based on side(left or right call is coming) it will move to other side.
        // Lets see with an example:
        //   1
        //  / \
        // 6   2
        //    /
        //   3
        // will call the left recursive call and will stop at 6. process left of 6 which is null so dont do anything
        // process the 6 by adding 6 into answer list
        // process right of 6 which is null so dont do anything
        // now 6 is completed, So move back to previous function call, where node is 1, now 1's left is done
        // So process 1.
        // and now move to right of 1 and continue the above process
        // 
        // lets see that in action
        public List<int> inorderTraversal(TreeNode A)
        {
            // we are preparing the list for each recursive call
            List<int> inOrderList = new List<int>();
            // if list is empty, return empty list
            if (A == null) return inOrderList;
            // Add all the left side data because left recursion call will return the list
            // example: if A is leaf node, So it will be return empty list. So current list will add no values
            // suppose if A is not leaf node, it means it will return some list of data, as we have created empty list
            // we will add all the left data into our current list
            inOrderList.AddRange(inorderTraversal(A.left));
            // add the current element
            inOrderList.Add(A.val);
            // Add all the right side data because right recursion call will return the list
            // example: if A is leaf node, So it will be return empty list. So current list will add no values
            // suppose if A is not leaf node, it means it will return some list of data, as we have created empty list
            // we will add all the left data into our current list
            inOrderList.AddRange(inorderTraversal(A.right));
            // return the list
            // this will return return list of data to previous function calls, which will be added in the previous function call list
            return inOrderList;

        }
    }
}
