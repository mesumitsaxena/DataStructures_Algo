using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Given a root of binary tree A, determine if it is height-balanced.

    //A height-balanced binary tree is defined as a binary tree in which the
    //depth of the two subtrees of every node never differ by more than 1.
    //Example Input
    //Input 1:

    //    1
    //   / \
    //  2   3
    //Input 2:


    //       1
    //      /
    //     2
    //    /
    //   3


    //Example Output
    //Output 1:

    //1
    //Output 2:

    //0
    internal class BalancedBinarytree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // Approach 1:
        /*
         * Calculate each node's left height and right height and then check the diff, if it is <2 (means 0 or 1) then return 1
         * else return 0
         * we will return 1 or 0 to previous function call, if any of the function call returns 0, then we will return 0.
         * if all the function call return 1, return 1
         * but calculating height for each left and right will increase the time complexity
         * by O(N^2).
         */
        public int height(TreeNode A)
        {
            if (A == null) return -1;
            int leftHeight = height(A.left);
            int rightHeight = height(A.right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public int isBalancednonOptimized(TreeNode A)
        {
            if (A == null) return 1;
            int leftheight = height(A.left);
            int rightheight = height(A.right);
            int diff = Math.Abs(leftheight - rightheight);
            if (diff < 2 && isBalanced(A.left) == 1 && isBalanced(A.right) == 1)
            {
                return 1;
            }
            return 0;

        }

        //Approach 2:
        /*
         * What was the issue in above solution
         * 1.) height function was called again and again for each recursive call, which is like very costly
         * 2.) So, Can we calculate height while recursivly iterating and checking if it is balanced or not? No,
         * because height is sending height value for the subtree and isbalanced method is return 0 or 1 for that subtree
         * 
         * Can we combine them together, we can not return 2 values from a method, but we can return a pair which consist of two values
         * So we will calculate height from the bottom and send the height and status of subtree to previous function call
         * by height we can check the diff and by status we can check if it is valid or not
         * and that is what we need to check.
         * There are few scenario which we need to check
         * 1.) if diff of height is ok for current node but its subtree is invalid means left or right subtrees is sending status as 0 then whole tree is invalid, So return height and status as 0
         * 2.) if subtree is valid means left and right subtrees are sending status as 1, but diff of height is invalid, then also return 0
         * 3.) if diff is ok and left and right subtrees are also sending status as 1, then only return 1
         * So by using Keyvaluepair, we can solve this problem from O(N^2) to O(N)
         */
        public KeyValuePair<int, int> isheightBalanced(TreeNode A)
        {
            if (A == null) return new KeyValuePair<int, int>(-1, 1);
            // Iterate till A is null and then calculate left and right subtrees values(height and status)
            // Using Bottom up apporach
            KeyValuePair<int, int> leftHeightBalanced = isheightBalanced(A.left);
            KeyValuePair<int, int> rightHeightBalanced = isheightBalanced(A.right);
            int diff = Math.Abs(leftHeightBalanced.Key - rightHeightBalanced.Key);
            // if diff is ok(means left subtree and right subtree height diff is less than 2) and
            // left and right subtrees are also sending status as 1.
            // then return height (calculate the height here for this node, take previous function call height and use it
            // , So by this we are not calling height method again and again) and status as 1
            if (diff < 2 && leftHeightBalanced.Value == 1 && rightHeightBalanced.Value == 1)
            {
                return new KeyValuePair<int, int>(Math.Max(leftHeightBalanced.Key, rightHeightBalanced.Key) + 1, 1);
            }
            // else return height (calculate the height here for this node) and status as 0
            return new KeyValuePair<int, int>(Math.Max(leftHeightBalanced.Key, rightHeightBalanced.Key) + 1, 0);
        }
        public int isBalanced(TreeNode A)
        {
            KeyValuePair<int, int> heightandStatus = isheightBalanced(A);
            if (heightandStatus.Value == 1)
            {
                return 1;
            }
            return 0;
        }

    }
}
