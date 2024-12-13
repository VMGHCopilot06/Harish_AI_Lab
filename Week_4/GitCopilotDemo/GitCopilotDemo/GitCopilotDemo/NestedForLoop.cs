using System;


   public class PremiumManager
    {
        static void CalculatePremium(string[] args)
        {
            // Sample data
            string[] regions = { "North", "South", "East", "West" };
            string[] agents = { "Agent1", "Agent2", "Agent3" };
            string[] customers = { "Customer1", "Customer2", "Customer3" };
            string[] policies = { "Health", "Life", "Auto", "Home" };

            // Nested loops to calculate total premium
            double totalPremium = 0.0;

            foreach (var region in regions)
            {
                foreach (var agent in agents)
                {
                    foreach (var customer in customers)
                    {
                        foreach (var policy in policies)
                        {
                            // Sample premium calculation
                            double premium = CalculatePremium(region, agent, customer, policy);
                            totalPremium += premium;

                            Console.WriteLine($"Region: {region}, Agent: {agent}, Customer: {customer}, Policy: {policy}, Premium: {premium:C}");
                        }
                    }
                }
            }

            Console.WriteLine($"\nTotal Premium: {totalPremium:C}");
        }

        static double CalculatePremium(string region, string agent, string customer, string policy)
        {
            // Simple premium calculation logic (for demonstration purposes)
            return (region.Length + agent.Length + customer.Length + policy.Length) * 10;
        }
    }
