using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //You are given an integer array prices where prices[i] is the price of a given stock on the ith day.

    //On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. However, you can buy it then immediately sell it on the same day.

    //Find and return the maximum profit you can achieve.
    //Input: prices = [7,1,5,3,6,4]
    //Output: 7
    //Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
    //Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
    //Total profit is 4 + 3 = 7.
    //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
    internal class BestTimetoBuyandSellStockII
    {
        //check for buyindex which is dip value, whenever you have a dip calculate profit.
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int buyindex = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                // check if next value is dip or not
                if (prices[i] < prices[i - 1])
                {
                    profit += (prices[i - 1] - prices[buyindex]);
                    buyindex = i;
                }
                // if it is last index and dip is not yet came, then we have to calculate the profit here only
                else if (i == prices.Length - 1)
                {
                    profit += (prices[i] - prices[buyindex]);
                }
            }
            return profit;
        }
    }
}
