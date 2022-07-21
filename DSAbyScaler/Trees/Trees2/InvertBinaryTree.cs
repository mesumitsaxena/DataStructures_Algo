using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Given a binary tree A, invert the binary tree and return it.

    //Inverting refers to making the left child the right child and vice versa.
    //Example Input
    //Input 1:


    //     1
    //   /   \
    //  2     3
    //Input 2:


    //     1
    //   /   \
    //  2     3
    // / \   / \
    //4   5 6   7


    //Example Output
    //Output 1:


    //     1
    //   /   \
    //  3     2
    //Output 2:


    //     1
    //   /   \
    //  3     2
    // / \   / \
    //7   6 5   4
    internal class InvertBinaryTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // Invert the binary tree means we have to make left node as right node if node and right node as left node of node
        // we can use swap functionality to perform this. swap left with right
        // we need to first of all swap all the leaf nodes and then go up.
        // which traversal help us here?
        // will inorder help? in order will go on left, once leaf is there it will come back and then process the node
        // processing the node means swap the left and right, here without traversing the right we are swapping, 
        // will this work? after swapping, left becomes right and we have already traverse left which becomes right.
        // So by this right will never get traverse.

        // lets try post order, first of all we will go till the end of left, we found null, then will go on right
        // and then swap the left and right for node, then we will go up, for above node, it will go to right and perform same
        // and then it will come back to node and then swap left and right, So this will work.
        // this is bottom up approach, as we will first go till bottom and then start swapping left and right

        // lets try pre order, first will swap left and right, then it will go to left and swap its left and right
        // then further left untill found null. then it will come to right and do the same
        // So this approach will also work, but this kind of top down approach, first swap left and right of root, then go to left
        // and swap its left and right and so on.
        public TreeNode swap(TreeNode A)
        {
            TreeNode node = A.left;
            A.left = A.right;
            A.right = node;
            return node;
        }
        public TreeNode invertTree(TreeNode A)
        {
            if (A == null) return null;
            //preorder - Top to bottom approach
            // first swap left and right
            A=swap(A);
            // left becomes right of tree, So swap left and right of node's left
            // after swapping node's left's left and right, return the left and attach it to left of node's left
            A.left=invertTree(A.left);
            // right becomes left of tree, So swap left and right of node's right,
            // after swapping node's right's left and right, return the right of node and attach it to right of node's right
            A.right=invertTree(A.right);
            return A;

            //postorder
            //A.left=invertTree(A.left);
            //A.right=invertTree(A.right);
            //A=swap(A);

            //return A;
        }
    }
}
