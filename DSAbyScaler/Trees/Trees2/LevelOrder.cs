using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Given a binary tree, return the level order traversal of its nodes' values.
    //(i.e., from left to right, level by level).
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
    //   [9, 20],
    //   [15, 7]
    // ]
    //Output 2:

    // [
    //   [1]
    //    [6, 2]
    //    [3]
    // ]


    //Example Explanation
    //Explanation 1:

    // Return the 2D array.Each row denotes the traversal of each level.
    internal class LevelOrder
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }

        // for level order traversal, we need to print level by level in 2D array or 2D list
        // to traverse horizontaly from left to right, we need to store node's children in some DS
        // lets understand how the logic will work.
        // we will store the root in DS, and then access the node from DS and store its children
        // after that remove the first node as it is processed.
        // now move to next node in DS, and store its children in DS and so on.

        // observation:  we are kind of accessing first node in DS and storing its children at the end of DS.
        // So we are kind of accessing front and storing front's children.
        // Queue is DS by which we can access the front and store front's children at rear.
        // So Queue will be helpful here.

        // As we need to store the data level by level in 2D list, how do we know when the level has ended?
        // we can represent null as eliminator. when the level is done, insert null in the queue.
        // we will store root and null in the queue, as we already know at level 0, there is only 1 element which is root
        // So we will store root in queue along with null which will represent that the level is done.
        // now access front of queue, store front value in temp list and store its children, remove the front
        // now check if next element(front) is null? if yes it means level is done, So store temp list in 2d result list
        // reset the temp list as we will add new data for next level.
        // Also remove the front (as it is null) and add the null at rear, why? because if front is null, it means
        // all the nodes of this level is done and its childrens are also added in queue, So add null to identify the level done for next level.
        // if front was null then do not continue for other activities like adding its childrem as it is null, it will not have children.
        // we will continue this process till queue has only 1 element, why?
        // Queue will always have atleast 2 element, either node and null, or node's childrena and null.
        // when will queue has only 1 element? when we are processing, last level, and previous level null encountered in queue
        // means we will add previous level temp data to result set and add null as previous level's node's children also gets added in queue
        // now for last level, when we process all the leaf nodes, and when we encountered last null, then we will temp list to result set.
        // we will remove front which is null but we will also add null(indicating all the nodes of current level are processed).
        // as there no element left, queue will always have null, So whenever there is only 1 element left we can assume, it is null only and all the nodes are processed

        public List<List<int>> levelOrder(TreeNode A)
        {
            List<List<int>> result= new List<List<int>>();
            Queue<TreeNode> levelQueue = new Queue<TreeNode>();
            // Store root and null, null will represent level is done, at root level there is only one element which is root itself
            levelQueue.Enqueue(A);
            levelQueue.Enqueue(null);
            // take temp list which will contains data for each level
            List<int> temp = new List<int>();
            // process until count is greater than 1, as we know if there is only 1 element in queue it will be null
            while(levelQueue.Count > 1)
            {
                // access front
                TreeNode node= levelQueue.Peek();
                // if front is null, then add temp list into 2D array, reset temp.
                // remove front as it is null, also add null (indicates all the nodes of current level are processed)
                // and if all the nodes of current level are processed, it means we have added all its children.
                // So we will add null so that we will know when the level is ended.
                // Continue, do not process next code, null will not have its children and value.
                if (node == null)
                {
                    result.Add(temp);
                    temp = new List<int>();
                    levelQueue.Dequeue();
                    levelQueue.Enqueue(null);
                    continue;
                }
                // if not not null then process the front, by storing its value in temp(storing data of current level)
                temp.Add(node.val);
                // after processing node, add its children into queue, but before that check if node has left or right or not
                if(node.left != null)levelQueue.Enqueue(node.left);
                if(node.right != null)levelQueue.Enqueue(node.right);
                // finally delete the front
                levelQueue.Dequeue();
            }
            // at the end Add last level into result.
            if (temp.Count > 0)
                result.Add(temp);
            return result;
        }
    }
}
