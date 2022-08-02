using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.BST2
{
    //Two elements of a binary search tree(BST), represented by root A are swapped by mistake.Tell us the 2 values swapping which the tree will be restored.


    //A solution using O(n) space is pretty straightforward.Could you devise a constant space solution?
    //Example Input
    //Input 1:


    //         1
    //        / \
    //       2   3
    //Input 2:


    //         2
    //        / \
    //       3   1



    //Example Output
    //Output 1:

    // [2, 1]
    //    Output 2:

    // [3, 1]


    //    Example Explanation
    //Explanation 1:

    //Swapping 1 and 2 will change the BST to be
    //         2
    //        / \
    //       1   3
    //which is a valid BST
    //Explanation 2:

    //Swapping 1 and 3 will change the BST to be
    //         2
    //        / \
    //       1   3
    //which is a valid BST
    internal class RecoverBST
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // both culprit can not be higher or both culprit will never be smaller.
        // Also first culprit will be higher and second culprit will be smaller, why?
        // we are doing in order traversal, so all smaller values will be on left and all higher value will be on right
        // if BST is not completly valid, then in smaller values, there will be one larger values and in larger values set, there will be one smaller value
        // As in order we are traversing from smaller to higher, So first culprit will be always be higher and second will be smaller
        // As this is a BST and two nodes are swapped wrongly, and first culprit is captured means it is higher value so second will definetly be smaller

        // In order to find two culprit, if we can simply create a list with BST using Inorder traversal, the list should be sorted
        // in increasing order, but if there are two culprit, the first culprit can be captured as its value will be higher than next value
        // normally in inceasing order sorted array current value is smaller than next value
        // but if any point of time, current value is greater than next value it means this is the culprit right
        // how to identify the second culprit?
        // while traversing, if the current value is greater than next value, then next value is the culprit
        // because next value is smaller

        // lets understand with an example: 
        //            15
        //          /    \
        //        12      14
        //        / \    /  \
        //       10  20  16  27
        //      /  
        //     8
        // List will be created after inorder as-
        // 8 10 12 20 15 16 14 27
        // if we move from left to right, we know 20 is the culprit, but when we reach to 20 and compare with next (15)
        // then we will know 20 is the culprit (because 8, 10, 12 and 20 are in increasing order, but when 15 comes
        // then we got to know there is a dip between 20 and 15, So 15 will not be culprit why? because we know first culprit is
        // going to be larger number and larger between 20 adn 15 is 20), So we can say first culprit is 20
        // going forward, we know 14 is the second culprit, and when we traverse,we reach to 16 and we can see there is a dip again
        // and we know second value is going to be smaller so min between 16 and 14 will be 14. as 15 and 16 are in correct order, but 14 came in between
        // So 14 is the second culprit.

        // this approach takes O(N) space complexity

        // Can we do it in O(1)? Yes
        // instead of storing everything in list, if we just store prev value, will this work?
        // Yes, if prev value is greater than current, then there must be a culprit. because in normal sorted list
        // previous value should be smaller than current element
        // Now how to identify what is first culprit and what is second?
        // we know first will be higher and second will be smaller
        // So if prev is greater than smaller, than first culprit will be prev as it is greater
        // now for second culprit, situation (prev>current) will arise once again and we know second is smaller,
        // So second=current 

        public void recoverBST(TreeNode root, ref TreeNode first, ref TreeNode second, ref TreeNode prev)
        {
            if (root == null) return;
            recoverBST(root.left, ref first, ref second, ref prev);
            if(prev!=null && prev.val > root.val)
            {
                if (first == null) first = prev;
                second = root;
            }
            prev = root;
            recoverBST(root.right,ref first, ref second, ref prev);

        }
        public List<int> recoverTree(TreeNode A)
        {
            TreeNode first = null;
            TreeNode second = null;
            TreeNode prev = null;
            recoverBST(A,ref first,ref second,ref prev);
            List<int> result = new List<int>();
            result.Add(first.val);
            result.Add(second.val);
            return result;
        }
    }
}
