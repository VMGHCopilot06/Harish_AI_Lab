using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Console
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Prompts the user to enter a number and checks if it is prime.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a number to check if it is prime:");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    bool isPrime = IsPrime(number);
                    Console.WriteLine($"{number} is prime: {isPrime}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Determines whether the specified number is a prime number.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns><c>true</c> if the specified number is prime; otherwise, <c>false</c>.</returns>
        public static bool IsPrime(int number)
        {
            try
            {
                if (number <= 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;

                var boundary = (int)Math.Floor(Math.Sqrt(number));

                for (int i = 3; i <= boundary; i += 2)
                {
                    if (number % i == 0) return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking if the number is prime: {ex.Message}");
                return false;
            }
        }
    }
}
