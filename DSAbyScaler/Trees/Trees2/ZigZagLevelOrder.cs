using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Given a binary tree, return the zigzag level order traversal of its nodes values.
    //(ie, from left to right, then right to left for the next level and alternate between).
    //Input Format
    //First and only argument is root node of the binary tree, A.



    //Output Format
    //Return a 2D integer array denoting the zigzag level order traversal of the given binary tree.



    //Example Input
    //Input 1:

    //    3
    //   / \
    //  9  20
    //    /  \
    //   15   7
    //Input 2:

    //   1
    //  / \
    // 6   2
    //    /
    //   3


    //Example Output
    //Output 1:

    // [
    //   [3],
    //   [20, 9],
    //   [15, 7]
    // ]
    //Output 2:

    // [
    //   [1]
    //    [2, 6]
    //    [3]
    // ]
    internal class ZigZagLevelOrder
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // It is same as level order traversal
        // only thing is even levels are listed in reverse order
        // So while iterating, we will add the elements in left to right only in the list
        // but if level is even then reverse the list and add it in the answer 2d list
        // lets see this in action
        public List<List<int>> zigzagLevelOrder(TreeNode A)
        {
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            List<List<int>> result = new List<List<int>>();
            List<int> tempList = new List<int>();
            nodeQueue.Enqueue(A);
            nodeQueue.Enqueue(null);
            int level = 1;
            while(nodeQueue.Count > 1)
            {
                TreeNode node = nodeQueue.Peek();
                if (node == null)
                {
                    if (level % 2 == 0)
                    {
                        tempList.Reverse();
                    }
                    result.Add(tempList);
                    tempList = new List<int>();
                    nodeQueue.Dequeue();
                    nodeQueue.Enqueue(null);
                    level++;
                    continue;
                }
                tempList.Add(node.val);
                if (node.left != null) nodeQueue.Enqueue(node.left);
                if (node.right != null) nodeQueue.Enqueue(node.right);
            }
            return result;
        }
    }
}
