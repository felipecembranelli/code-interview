using System;
using System.Collections;
using System.Collections.Generic;

namespace algo
{
    class Program
    {
        private static int numberInteractions = 0;
        private static int timeComplexity = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            // int[] sampleValues = new int[1000];

            // for (int i = 0; i < 1000; i++)
            // {
            //     sampleValues[i] = i;
            // }

            // var result1 = TwoSum(sampleValues, 1000);
            // DisplayResult(result1, numberInteractions, sampleValues.Length);

            // var result = TwoSum(new int[] { 2, 7, 11, 15 }, 4);
            // DisplayResult(result, timeComplexity);

            // var result4 = TwoSumHash(new int[] { 2, 7, 11, 15 }, 26);
            // DisplayResult(result, timeComplexity);

            // var result2 = TwoSum(new int[] { 2, 2, 11, 15 }, 4);
            // DisplayResult(result2, timeComplexity);

            // var result5 = TwoSumHash(new int[] { 2, 3, 11, 15 }, 4);
            // DisplayResult(result2, timeComplexity);

            // var result3 = TwoSum(new int[] { 1, 7, 2, 5, 4 }, 9);
            // DisplayResult(result3, timeComplexity);

            // var result6 = TwoSumHash(new int[] { 1, 7, 2, 5, 4 }, 9);
            // DisplayResult(result3, ++timeComplexity);


            //var result = BuyStock(new int[] { 1, 2, 3, 4, 5 });
            //var result = BuyStock(new int[] { 1, 2, 5, 4, 3 });
            //var result = BuyStock(new int[] { 2, 1, 4, 5, 3 });     //1,3
            //var result = BuyStock1(new int[] { 2, 3, 4, 1, 5 });     //3,4
            //var result = BuyStock2(new int[] { 2, 5, 4, 1, 3 });     //0,1
            //var result1 = BuyStock2(new int[] { 2, 1, 4, 5, 3 });     //1,3
            //var result2 = BuyStock2(new int[] { 2, 3, 4, 1, 5 });     //3,4

            var result = BuyStock3(new int[] { 2, 3, 4, 1, 5 });     //3,4

            //DisplayResult(result, 0);

        }
        public static int[] TwoSum(int[] nums, int target)
        {

            timeComplexity = 0;
            numberInteractions = 0;

            if (nums.Length == 0) return null;

            for (int i = 0; i < nums.Length; i++)
            {

                timeComplexity = 1;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    timeComplexity = 2;
                    numberInteractions++;

                    if (nums[j] == target - nums[i])
                        return new int[] { i, j };
                }
            }

            return null;
        }

        public static int[] TwoSumHash(int[] nums, int target)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                map.Add(nums[i], i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                timeComplexity++;

                int complement = target - nums[i];
                if (map.ContainsKey(complement) && map[complement] != i)
                {
                    return new int[] { i, map[complement] };
                }
            }

            return null;

        }

        ////////////////////////////////////////
        // EX 2 : STOCK
        ////////////////////////////////////////
        public static int[] BuyStock1(int[] nums)
        {

            timeComplexity = 0;
            numberInteractions = 0;

            int buyPrice = nums[0];
            int currentStockValue = 0;
            int sellPrice = 0;
            int buyDay = 0;
            int sellDay = 0;


            for (int i = 0; i < nums.Length; i++)
            {
                currentStockValue = nums[i];

                if (currentStockValue <= buyPrice)
                {
                    buyPrice = currentStockValue;
                    buyDay = i;
                }

            }

            sellPrice = nums[nums.Length - 1];

            for (int j = nums.Length - 1; j > 0; j--)
            {

                sellDay = j;
                currentStockValue = nums[j];

                if ((currentStockValue > buyPrice) && (sellDay >= buyDay))
                {
                    sellPrice = currentStockValue;
                    sellDay = j;
                }

            }

            return new int[] { buyDay, sellDay };
        }

        public static int[] BuyStock2(int[] nums)
        {

            timeComplexity = 0;
            numberInteractions = 0;

            int buyPrice = nums[0];
            int currentPrice = 0;
            int sellPrice = 0;
            int buyDay = 0;
            int sellDay = 0;
            int currentBalance = 0;
            int maxBalance = 0;
            int selectedBuyDay = 0;
            int selectedSellDay = 0;

            
            for (int i = 0; i < nums.Length; i++)
            {
                currentPrice = nums[i];
                buyPrice = currentPrice;
                buyDay = i;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    sellPrice = nums[j];
                    sellDay = j;
                    currentBalance = sellPrice - buyPrice;

                    if (currentBalance > maxBalance) 
                    {
                        maxBalance = currentBalance;
                        selectedBuyDay = buyDay;
                        selectedSellDay = sellDay;
                    }

                }
            }
            
            return new int[] { selectedBuyDay, selectedSellDay };
        }

        public static int[] BuyStock3(int[] nums)
        {

            timeComplexity = 0;
            numberInteractions = 0;

            int buyPrice = nums[0];
            int currentPrice = 0;
            int sellPrice = 0;
            int buyDay = 0;
            int sellDay = 0;
            int currentBalance = 0;
            int maxBalance = 0;
            int selectedBuyDay = 0;
            int selectedSellDay = 0;

            int minPrice = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                currentPrice = nums[i];
                //buyPrice = currentPrice;
                //buyDay = i;
                sellPrice = currentPrice;
                currentBalance = sellPrice - minPrice;

                if (currentPrice < minPrice) 
                {
                    minPrice = currentPrice;
                    selectedBuyDay = i;
                }

                if (currentBalance > maxBalance) {
                    maxBalance = sellPrice - minPrice;
                    selectedSellDay = i;
                }

            }

            return new int[] { selectedBuyDay, selectedSellDay };
        }

        /// <summary> 
        /// Helper Method To Display The Result 
        /// </summary> 
        /// <param name="result"></param> 
        /// <param name="counter"></param> 
        public static void DisplayResult(int[] result, int counter, int arraySize)
        {
            if (result == null) return;

            Console.WriteLine("Test Case: " + result[0] + "," + result[1] + " - timecomplexity:" + (timeComplexity) + " - interactions:" + counter);

            timeComplexity = 0;

            Console.WriteLine("================================================");
        }

    }
}
