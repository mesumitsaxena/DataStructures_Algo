using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.Trees.Trees2
{
    //Given a binary tree, return a 2-D array with vertical order traversal of it.Go through the example and image for more details.


    //NOTE: If 2 Tree Nodes shares the same vertical level then the one with lesser depth will come first.
    //Input 1:

    //      6
    //    /   \
    //   3     7
    //  / \     \
    // 2   5     9
    //Input 2:

    //      1
    //    /   \
    //   3     7
    //  /       \
    // 2         9


    //Example Output
    //Output 1:

    // [
    //    [2],
    //    [3],
    //    [6, 5],
    //    [7],
    //    [9]
    // ]
    //Output 2:

    // [
    //    [2],
    //    [3],
    //    [1],
    //    [7],
    //    [9]
    // ]


    //Example Explanation
    //Explanation 1:

    // First row represent the verical line 1 and so on.
    internal class VerticalOrderTraversal
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // for vertical ordering, we need to find the levels vertically
        // So root will be at 0 level, left of root will be -1 level, and so on
        // root's right will be level 1 and so on.
        // How can we find it the levels?

        // We can make use of Queues, where we can store the node with its level, and when its children comes
        // we can increase or decrease by 1 from its existing level.

        // How to find which node is at which level? and how do we print them?
        // we can store level's into the map and corresponding to a level, we will store the nodes on that level

        // Now how can we traverse? will preorder, inorder or postorder helps? No, because we need data top to bottom and left to right
        // for now lets only consider top to bottm data approach, if we follow any of the above traversal, it will be Node Left Right, or LNR pr LRN
        // in all 3 cases, first we will complete left subtreee then right subtree, but by this nodes might not come from top to down, take an example and understand
        // So best way of traversal for this is level order, becasue we will first store vertical level for each horizontal level
        // 
        // So best way is to use map to store vertical level and its nodes and for level order traversal, we will use Queue.

        // Basically hashmap we will use to store the level and its nodes so that at the end when we have to create 2D array,
        // we can create it using this map.
        // we will take queue of keyvalue pair, because how do we know the level of the node, we will store the node along with its level
        // we will start with root node and its level as 0, then if we encountered a left node and take the parent node and do -1 and store it into the queue
        // So as we can see, we need 2 information, 1 is node info and other is its level.

        // Now how do we add nodes from left level to right? as level's are stored in hashmap, do we iterate the map and find the minimum level and maximum level?
        // As we want the far more left to far most right.
        //      6
        //    /   \
        //   3     7
        //  / \     \
        // 2   5     9
        // In above example: 6 is at level 0, 3 is at level -1, 2 is at -2 level, 5 is at 0 level.
        // 7 is at 1 level and 9 is at 2 level.
        // but in hashmap these levels can stored in random order right, it might be like below
        /*
         *  1: 3
         *  0: 6,5
         * -2: 2
         *  2: 9
         *  1: 7
         */
        // So as we can see, levels are not ordered, So how do we order these levels?
        // do we iterate the minimum level and then 2nd minimum and so on, No, it will be then take O(N^2) time complexity
        // Optimized apporach is, we can take two variables, minLevel and maxLevel, and for each level we will maintain that
        // we can then run a loop from minLevel to maxLevel, find this level in the map and add all the nodes into list
        public List<List<int>> verticalOrderTraversal(TreeNode A)
        {
            // Taking queue for level order traversal and data type would be keyvalue pair, why?
            // How do we know the levels of each node and how do we fill the level's in hashmap?
            Queue<KeyValuePair<int,TreeNode>> queue = new Queue<KeyValuePair<int, TreeNode>>();
            // we will have a map, SO that we can store all the nodes level wise, for example: for level 2: all nodes for level 2
            Dictionary<int, List<TreeNode>> levelwiseNodes = new Dictionary<int, List<TreeNode>>();
            //result set
            List<List<int>> result = new List<List<int>>();
            //Add the root node and its level into Queue
            KeyValuePair<int, TreeNode> root = new KeyValuePair<int, TreeNode>(0, A);
            queue.Enqueue(root);
            int minLevel = 0;
            int maxLevel = 0;
            while(queue.Count > 0)
            {
                // Access the front
                KeyValuePair<int, TreeNode> frontpair = queue.Peek();
                int level= frontpair.Key;
                TreeNode node= frontpair.Value;
                //insert the node in map with its level, if level already exist then just add the node
                if (levelwiseNodes.ContainsKey(level))
                {
                    levelwiseNodes[level].Add(node);
                }
                else
                {
                    levelwiseNodes.Add(level, new List<TreeNode>() { node});
                }
                minLevel = Math.Min(minLevel, level);
                maxLevel = Math.Max(maxLevel, level);
                // add node's left to queue with its level, left node will have its parent's level-1
                if (node.left!=null) queue.Enqueue(new KeyValuePair<int,TreeNode>(level-1, node.left));
                // add node's right to queue with its level, right node will have its parent's level+1
                if (node.right != null) queue.Enqueue(new KeyValuePair<int, TreeNode>(level + 1, node.right));

            }
            // run a loop from minLevel to maxLevel and add the nodes and its data into result list
            for(int i = minLevel; i < maxLevel; i++)
            {
                //List<TreeNode> tempList = levelwiseNodes[i];
                List<int> tempList = new List<int>();
                foreach(var item in levelwiseNodes[i])
                {
                    tempList.Add(item.val);
                }
                result.Add(tempList);
            }
            return result;
        }
    }
}
