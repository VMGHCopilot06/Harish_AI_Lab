using System;

namespace APIMDemoAPI
{
    class NestedForLoopDebugging
    {
        static void Main(string[] args)
        {
            int[,] premiums = new int[3, 3]
            {
                    { 100, 200, 300 },
                    { 400, 500, 600 },
                    { 700, 800, 900 }
            };

            // Calculate total premium for each agent
            for (int i = 0; i < premiums.GetLength(0); i++)
            {
                int totalPremium = 0; // Reset totalPremium for each agent
                Console.WriteLine($"Calculating total premium for agent {i + 1}");

                for (int j = 0; j < premiums.GetLength(1); j++)
                {
                    totalPremium += premiums[i, j];
                    Console.WriteLine($"  Adding premium {premiums[i, j]} for policy {j + 1}");
                }

                Console.WriteLine($"Total premium for agent {i + 1}: {totalPremium}");
            }
        }
    }
}
