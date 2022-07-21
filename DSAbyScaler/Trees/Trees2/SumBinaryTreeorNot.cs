using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Given a binary tree.Check whether the given tree is a Sum-binary Tree or not.

    //Sum-binary Tree is a Binary Tree where the value of a every node is equal to sum of the nodes present in its left subtree and right subtree.

    //An empty tree is Sum-binary Tree and sum of an empty tree can be considered as 0. A leaf node is also considered as SumTree.

    //Return 1 if it sum-binary tree else return 0.
    //Example Input
    //Input 1:

    //       26
    //     /    \
    //    10     3
    //   /  \     \
    //  4   6      3
    //Input 2:

    //       26
    //     /    \
    //    10     3
    //   /  \     \
    //  4   6      4


    //Example Output
    //Output 1:

    // 1
    //Output 2:

    // 0


    //Example Explanation
    //Explanation 1:

    // All leaf nodes are considered as SumTree.
    // Value of Node 10 = 4 + 6.
    // Value of Node 3 = 0 + 3 
    // Value of Node 26 = 20 + 6 
    //Explanation 2:

    // Sum of left subtree and right subtree is 27 which is not equal to the value of root node which is 26.
    internal class SumBinaryTreeorNot
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
         * In order to check each subtree, we will follow the same recursive appraoch,
         * Calculate sum of node's left and calculate sum of node's right and then check if the sum of left and right =node value
         * if yes then return 1 else return 0 and we have to do this for each subtree going down.
         * example:
         *       26
                /    \
               10     3
              /  \     \
             4   6      3
            we will call recursive function call for 26, in the method, we will call the sum method for 26.left and 26.right
            this sum function will sum all the elements for left subtree ex:(10+6+4)=20, and right subtree (3+3)=6
            now we will add left and right and compare it with node value which is 26 and it is equal and its left and right subtrees are also sumtree
            then return 1 else return 0
            
            Now for its left and right subtree call the same for left subtree, as this might not be sumtree or can be, so we need to check that, 
            if it is it will return 1.

            So it will be called as for root, check its left and right sum, then call the same method to find sum of its left children and right childre
            example:  for above example, for 26, sum will be called on left which will give 20, right will return 6, its sum is 26
            which is equal, but we will stll not return 1, now we will call same method for 10, 
            for 10, sum on left is 4, sum on right is 6, which is equal to 10, but still we will not return 1,
            now check if current node is leaf or its left or right is empty, so for 4, its left and right is empty (its a base condition)
            now return 1, so 1 will be returned by 4 to 10, same 6 will return 1 to 10, so both are 1 and its left and right sum is equal o 10 now return 1
            now 10 will return 1 to 26, similiarly 3 will return 1 to 26, also 20+6=26 so finally return 1
            
            Suppose from right instead of 3-3, we have 2-4, then 4 will return 1 to 3, but 3+0 !=4 so it will return 0.
            now 3 will return 0, 10 will return 1 so final output will be 0
            
            lets understand it with code.
            

         */
        public int sum(TreeNode A)
        {
            if (A == null) return 0;
            return A.val + sum(A.left) + sum(A.right);
        }
        public int solveSumApproach(TreeNode A)
        {
            if (A == null) return 1;
            int left=sum(A.left);
            int right=sum(A.right);
            // even if node's value is equal to its left and right subtree, we will wait for its left and right subtree
            // validation by solveSumApproach(A.left) ==1 we are checking if A's left tree is a sumtree or not, same for right subtree
            // if any of the condition fails, will return 0, which in previous function calls, can make whole answer 0.
            // if condiitons are satisfied then will return 1, which can again make previous function call sum as 1
            if (A.val==(left+right) && solveSumApproach(A.left) ==1 && solveSumApproach(A.right) == 1)
            {
                return 1;
            }
            return 0;
        }
        // Approach 2:
        /*
         * We can see, we called the sum method for 26's left(which is making sum of 10+4+6) and right(3+3), and again we calculating the same sum for 10's left(4+6) adn right (3)
         * so this is making the time complexity as O(N^2), how? if we are having skewed tree then we will be calling the sum function again and again
         * skewed tree is 1-2-3-4-5 all childs on left or right. So we will call sum for 1 (which is 2+3+4+5), then call sum for 2(3+4+5), then for 3(4+5) etc
         * So thats how it will be O(n^2)
         * So problem with the above approach is calling the sum method again and again. why are we calling it again and again?
         * As we have to send the final output as 0 or 1, we can't send sum from previous function call .
         * example: consider below tree
         * 
         *       26
                /    \
               10     3
              /  \     \
             4   6      3
         * when we call method for 26, we are callling sum for 10 and 3, now if we dig deeper and try to send the sum when we found leaf node or null
         * we can still do that and we can verify that as well, but then in the we will be sending the sum from left and right but we need 1 (valid) or 0(invalid)
         * from recusion we can not send two values means sum and status
         * so we can make use of keyvalue pair, key will be sum and value will be if subtree is valid or not
         * Now  we will call for 26, 26 will call the method for 10 and 3, 10 will call for 4 and 6
         * 4 will call null, as we encountered null, we will return keyvalue pair saying null has value 0 but 4 is valid subtree so value will be true
         * now same for 6, 0,tree will be send to 4 and 6, now we will check if left adn right =0 then its a valid subtree
         * So return 4+leftsubtree.key(which is 0)+rightsubtree.key(which is 0)=4, true to 10
         * now 10 will check if 10=leftsubtree.key+rightsubtree.key which is true so return 10+leftsubtree.key(4)+rightsubtree.key(6)=20,true
         * So 10 will return 20 from 10 to 26, by this we are calculating the sum from bottom to top and sending it to parent and by value
         * we are checking if subtree is valid or not
            
         */
        public KeyValuePair<int,bool> isSumTree(TreeNode node)
        {
            if(node==null)
            {
                return new KeyValuePair<int, bool>(0, true);
            }
            KeyValuePair<int,bool> leftSum=isSumTree(node.left);
            KeyValuePair<int, bool> righSum = isSumTree(node.right);
            if ((node.val == leftSum.Key + righSum.Key && (leftSum.Value && righSum.Value)) || leftSum.Key + righSum.Key==0)
            {
                return new KeyValuePair<int, bool>(node.val + leftSum.Key + righSum.Key, true);
            }
            return  new KeyValuePair<int, bool>(node.val + leftSum.Key + righSum.Key, false);
        }
        public int solve(TreeNode A)
        {
            if (A == null) return 0;
            KeyValuePair<int, bool> result = isSumTree(A);
            if (result.Value) return 1;
            return 0;
        }
    }
}
