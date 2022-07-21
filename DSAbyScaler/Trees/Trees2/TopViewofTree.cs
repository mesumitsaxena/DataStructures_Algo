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
    //    [6],
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
    internal class TopViewofTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        // It is same as Vertical Order, only thing is we just need to add first element of every level from hashmap
        public List<int> topView(TreeNode A)
        {
            Queue<KeyValuePair<int, TreeNode>> verticalOrderQueue = new Queue<KeyValuePair<int, TreeNode>>();
            Dictionary<int, List<TreeNode>> levelMap = new Dictionary<int, List<TreeNode>>();
            KeyValuePair<int, TreeNode> rootnode = new KeyValuePair<int, TreeNode>(0, A);
            verticalOrderQueue.Enqueue(rootnode);
            int minLevel = 0;
            int maxLevel = 0;
            while (verticalOrderQueue.Count > 0)
            {
                KeyValuePair<int,TreeNode> levelNode= verticalOrderQueue.Peek();
                int level = levelNode.Key;
                TreeNode node=levelNode.Value;
                minLevel=Math.Min(minLevel, level);
                maxLevel=Math.Max(maxLevel, level);
                if (levelMap.ContainsKey(level))
                {
                    levelMap[level].Add(node);
                }
                else
                {
                    levelMap.Add(level, new List<TreeNode>() { node });
                }
                if (node.left != null) verticalOrderQueue.Enqueue(new KeyValuePair<int, TreeNode>(level - 1, node.left));
                if (node.right != null) verticalOrderQueue.Enqueue(new KeyValuePair<int, TreeNode>(level + 1, node.right));
            }
            // till now everything is same as vertical order traversal
            List<int> result = new List<int>();
            for(int i = minLevel; i <= maxLevel; i++)
            {
                List<TreeNode> temp = levelMap[i];
                // here we will only add 1st index of every level
                result.Add(temp[0].val);
            }
            return result;
        }
    }
}
