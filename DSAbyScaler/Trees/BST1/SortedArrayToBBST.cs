using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.BST1
{
    //Given an array where elements are sorted in ascending order, convert it to a height Balanced Binary Search Tree(BBST).

    //Balanced tree : a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
    //Example Input
    //Input 1:

    // A : [1, 2, 3]
    //    Input 2:

    // A : [1, 2, 3, 5, 10]


    //    Example Output
    //Output 1:

    //      2
    //    /   \
    //   1     3
    //Output 2:

    //      3
    //    /   \
    //   2     5
    //  /       \
    // 1         10


    //Example Explanation
    //Explanation 1:

    // You need to return the root node of the Binary Tree.
    internal class SortedArrayToBBST
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // Few things to know before starting the questions
        // BST properties - left subtree node value is less than root and right subtree node value is greater than root and so on
        // So if we iterate the BST with InOrder (Left Root and Right) then list will be in Sorted order
        
        // In this question, we have to convert the Sorted List to BST, So think when a BST is converted into List, what will be root position?
        // In InOrder, we always traverse left then root and then right
        // So for Root, all the left element of the root will be added in the list, then root will be added and after that all the right elements will be added
        // So Root will always be in the middle position of the list.
        // and this is applicable on all the sub BST's
        // Lets see the code in action

        public TreeNode Generate(List<int> A, int left, int right)
        {
            // if there are no subtrees left, means no element to access return null
            if (left > right) return null;
            // get middle element
            int mid = left + right / 2;
            // create node from middle element
            TreeNode node = new TreeNode(A[mid]);
            // continue the process to generate left the node 
            node.left = Generate(A, left, mid - 1);
            // and right of the node
            node.right = Generate(A, mid + 1, right);
            return node;
        }
        public TreeNode sortedArrayToBST(List<int> A)
        {
            return Generate(A, 0, A.Count - 1);
        }
    }
}
