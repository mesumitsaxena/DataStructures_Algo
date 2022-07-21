using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.BST1
{
    internal class IsValidBST
    {
        //You are given a binary tree represented by root A.

        //Assume a BST is defined as follows:

        //1) The left subtree of a node contains only nodes with keys less than the node's key.

        //2) The right subtree of a node contains only nodes with keys greater than the node's key.

        //3) Both the left and right subtrees must also be binary search trees.
        //Example Input
        //Input 1:

 
        //   1
        //  /  \
        // 2    3
        //Input 2:

 
        //  2
        // / \
        //1   3


        //Example Output
        //Output 1:

        // 0
        //Output 2:

        // 1


        //Example Explanation
        //Explanation 1:

        // 2 is not less than 1 but is in left subtree of 1.
        //Explanation 2:

        //Satisfies all conditions.

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // 
        // Every BST has this following property, by which we can say it is valid BST or not?
        // Property is Max(left subtree) <= Node <= Min(Right Subtree)
        // if we traverse the valid BST, the List will be in Sorted order.
        // So for each node this property should be true then only Whole tree is BST

        // Approach 1: Bottom Up Apporoach: PostOrder Apporach
        // If we iterate till leaf nodes (left and right, Can you sense the observation here?) and then we will process the node
        // as it is a leaf node, left and right will be null So we can check the node if it is valid node or not?
        // As it is leaf, So we will return IntMin from left and InMax from right So that leaf will be a valid subtree
        // follow up from above statement about observation, Observation is in post order we do left right and process node
        // we also have to check this same property to check if it is valid BST, for node we should know its left and right
        // then only we will be able to check right if node is valid or not [max(left)<=node<=Min(right)]
        // So that is postorder helps here.

        // How to iterate?
        // in case of leaf node, we have to send IntMin from left and IntMax from right to parent, why? 
        // As leaf node is always a valid BST, So Max(left)<=node<=Min(right) => IntMin<=node<=IntMax (by this condition will be satisfied)
        // Now to a node, how can we send two values, means value from left and value from right?
        // Can't we send IntMin from left and InMax from right? no, it will complicate the code and every position, we neeed to check if the value is coming
        // from left subtree or right subtree, Also how to implement this base condition, in a recursive call, a value can be taken from
        // previous recursive call, we cant get two values from single recursive call? 
        // because for a node, left and right both can be null, left is sending different value and right is sending different values
        // and handling them differently will complicate the code.
        // So for a node to get two values from a single recursive call, we will send a KeyvaluePair
        // we will send Max(IntMin from base case) from left and Min from right(IntMax from base case).
        // But how do we check if the BST is valid or not?
        // we will take one reference variable and set its value, if it is set to false any where then BST is invalid
        public KeyValuePair<int,int> validBST(TreeNode A, ref bool ans)
        {
            // handling base condition, if it is null, means child of a leaf node
            // it can either be from left and right, So send intmin from left and intmax from right
            // So that leaf node can be a valid sub BST
            if(A==null) return new KeyValuePair<int, int>(Int32.MinValue,Int32.MaxValue);
            // in Postfix iteration, iterate on left, right and then process the node
            // iterate on left
            KeyValuePair<int, int> leftBST=validBST(A.left,ref ans);
            //iterate on right
            KeyValuePair<int,int> rightBST=validBST(A.right,ref ans);
            // we return max and min from left and right, So that we can know what is over all max below this node
            // and what is overall max below this node or subtree
            //leftBST.Key and rightBST.Key will be Max value returned from left(As we have defined in our Base Condition)
            // rightBST.Value and rightBST.Value will be min value return from right(As we have defined in our Base Condition)
            // calculate max by checking left and right max value
            int max =Math.Max(leftBST.Key,rightBST.Key);
            // calculate min by checking left and right min value
            int min = Math.Min(leftBST.Value, rightBST.Value);
            // check if max from left and min from right satisfied conditions
            if (max<=A.val && A.val<= min)
            {
                //usually this condition is helpful for base condition, because max from left and right will always be greater than node value
                // and same for min value. in base condition, left and right max will IntMin and left and right min will be IntMax
                // So overall max and min will be node itself
                max = Math.Max(max, A.val);
                min=Math.Min(min,A.val);
               
            }
            else
            {
                ans = false;
            }
            // else return the max from left(it can be either the max value from left or the current node value)
            // also return the min from right(it can be either the min value from right or the current node value)
            return new KeyValuePair<int, int>(max, min);
            // As you can see, we are setting ans as one and never making it true, means if any of the subtree is not bst then
            // it will be invalid BST
        }
        public int isValidBST(TreeNode A)
        {
            if (A == null) return 1;
            bool ans = true;
            var result = validBST(A, ref ans);
            if (ans) return 1;
            return 0;
        }

        // Approach 2: Top to Bottom traversal approach
        // first check the node if the node is valid or not, and by this check and each node if they are valid or not
        // How to check if it is valid or not, each node, will have a range, means if we are on left subtree then node will be valid only if
        // its value is in between its parent value and some other value.
        // Lets understand with an example:
        //   3  
        //  / \
        // 1   5
        //    /
        //   4
        // Here suppose 3, 3 can be valid node if its value lies between range - Inf to + Inf
        // then I would be say 3 is valid node, now will go to left of 3, for 1 if it is a valid node, its value should lie
        // between -Inf to 2 and 3 is in range so 1 will send true
        // from right, 5 will check the range from 3+1=4 to +Inf and 5 lies in between so it will return true
        // now go to 4 and check, for 4 it should lie in between -Inf to 4 and yes it is so it will also return true
        // So by this we will check the left adn right
        public bool validBSTOptimized(TreeNode A, int min, int max)
        {
            if (A == null) return true;
            // check the node first
            // if it is valid
            if(min<=A.val && A.val <= max)
            {
                //then travel on left
                bool leftStatus = validBSTOptimized(A.left, min, A.val - 1);
                // and travel on right
                bool rightStatus = validBSTOptimized(A.right, A.val + 1, max);
                // and return the result
                return leftStatus&& rightStatus;
            }
            // if node is not valid then return false
            return false;
            // Same approach we can also have with postorder(bottom to top)
            /*
            if (A == null) return true;
            bool leftStatus = validBSTOptimized(A.left, min, A.val - 1);
            bool rightStatus = validBSTOptimized(A.right, A.val + 1, max);
            if(min<=A.val && A.val <= max)
            {
                return leftStatus&& rightStatus;
            }
            return false;
             * 
             */

        }
        public int isValidBSTOptimized(TreeNode A)
        {
                if (A == null) return 1;
                if (validBSTOptimized(A,Int32.MinValue,Int32.MaxValue)) return 1;
                return 0;
        }
    }
}
