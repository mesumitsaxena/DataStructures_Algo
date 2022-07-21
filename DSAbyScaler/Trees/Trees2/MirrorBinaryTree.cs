using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Given a binary tree, check whether it is a mirror of itself(i.e., symmetric around its center).
    //Example Input
    //Input 1:

    //    1
    //   / \
    //  2   2
    // / \ / \
    //3  4 4  3
    //Input 2:

    //    1
    //   / \
    //  2   2
    //   \   \
    //   3    3


    //Example Output
    //Output 1:

    // 1
    //Output 2:

    // 0
    internal class MirrorBinaryTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // If we store these nodes in list as Inorder traversal, then first half will be same as reverse of second half
        // So just do the inorder traversal and store the values in list.
        // check the elements of 0th index with last index, 1st index with second last index and so on.
        // Why InOrder? will preorder and postorder work? No, as Inorder, first we visit the left subarray then node and then right subarray
        // in order to place the root at the middle of the list, left of root should be in the array, for that Inorder is the perfect traversal
        // because in order will process root after traversing left subtree of root.
        // and if the root is middle, then we can check left of root is equal to right of root, (means reverse of right).
        // as we are doing recursion, this property will apply to each node on left and same on right.

        //Prepare Inorder list
        public List<int> inorderTraversal(TreeNode A)
        {
            List<int> list = new List<int>();
            if (A == null) return list;
            list.AddRange(inorderTraversal(A.left));
            list.Add(A.val);
            list.AddRange(inorderTraversal(A.right));
            return list;
        }
        public int isSymmetric(TreeNode A)
        {
            // prepare inorderList
            List<int> inorderList = inorderTraversal(A);
            for(int i = 0; i < inorderList.Count; i++)
            {
                // check if first half element is not equal to last half then return 0
                if (inorderList[i] != inorderList[inorderList.Count - i-1])
                {
                    return 0;
                }
            }
            // else retrun 1
            return 1;
        }
    }
}
