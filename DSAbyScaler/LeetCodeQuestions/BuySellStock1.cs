using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler.LeetCodeQuestions
{
    //You are given an array prices where prices[i] is the price of a given stock on the ith day.

    //You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

    //Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.
    //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    internal class BuySellStock1
    {
        public int MaxProfit(int[] prices)
        {
            int[] prefixBuyPrice = new int[prices.Length];
            prefixBuyPrice[0] = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                prefixBuyPrice[i] = Math.Min(prefixBuyPrice[i - 1], prices[i]);
            }
            int sellPrice = Int32.MinValue;
            int profit = 0;
            for (int i = prices.Length - 1; i >= 0; i--)
            {
                sellPrice = Math.Max(sellPrice, prices[i]);
                profit = Math.Max(profit, (sellPrice - prefixBuyPrice[i]));
            }
            return profit;
        }
    }
    

}
