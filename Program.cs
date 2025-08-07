using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stock Price Analysis");
            Console.WriteLine("Enter closing prices for 7 consecutive days:");

            List<decimal> prices = new List<decimal>();
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Day {i + 1} price: ");
                while (true)
                {
                    if (decimal.TryParse(Console.ReadLine(), out decimal price) && price > 0)
                    {
                        prices.Add(price);
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a positive number:");
                }
            }
            Console.WriteLine("\nDaily Price Changes:");
            List<decimal> gains = new List<decimal>();
            int maxGainDay = 1;
            decimal maxGain = 0;

            for (int i = 1; i < 7; i++)
            {
                decimal gain = prices[i] - prices[i - 1];
                decimal percentGain = prices[i - 1] == 0 ? 0 : (gain / prices[i - 1]) * 100;
                gains.Add(percentGain);

                Console.WriteLine($"Day {i + 1}: {(percentGain >= 0 ? "+" : "")}{percentGain:F2}%");

                if (gain > maxGain)
                {
                    maxGain = gain;
                    maxGainDay = i + 1;
                }
            }
            Console.WriteLine($"\nThe highest gain was on Day {maxGainDay} with {(maxGain / prices[maxGainDay - 2] * 100):F2}% increase");
        }
    }
}
