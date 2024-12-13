using System.Diagnostics;

namespace APIMDemoAPI
{
    public class InsuranceCalculator
    {
        public static double CalculatePremium(int age, string gender, int drivingExperience, string vehicleType, int vehicleAge, string location, int claimHistory, int creditScore, int annualMileage, string coverageType)
        {
            double premium = 500; // Base premium
            Stopwatch stopwatch = new Stopwatch();

            // Example of file path usage
            string filePath = "path/to/your/file.txt";

            try
            {
                // Check if file exists
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The specified file does not exist.", filePath);
                }

                // Read file content (example)
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine("File content read successfully.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.FileName}");
                Debugger.Break(); // Break into the debugger
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Debugger.Break(); // Break into the debugger
            }

            // Rest of the CalculatePremium method...

            // Condition 1: Age
            stopwatch.Start();
            if (age < 25)
            {
                premium += 150;
            }
            else if (age > 60)
            {
                premium += 100;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 1 (Age) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            // Condition 2: Gender
            stopwatch.Start();
            if (gender.ToLower() == "male")
            {
                premium += 50;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 2 (Gender) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            // Condition 3: Driving Experience
            stopwatch.Start();
            if (drivingExperience < 5)
            {
                premium += 100;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 3 (Driving Experience) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            // Condition 4: Vehicle Type
            stopwatch.Start();
            if (vehicleType.ToLower() == "sports")
            {
                premium += 200;
            }
            else if (vehicleType.ToLower() == "suv")
            {
                premium += 100;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 4 (Vehicle Type) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            // Condition 5: Vehicle Age
            stopwatch.Start();
            if (vehicleAge > 10)
            {
                premium += 75;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 5 (Vehicle Age) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            // Condition 6: Location
            stopwatch.Start();
            if (location.ToLower() == "urban" || location.ToLower() == "high_crime")
            {
                premium += 100;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 6 (Location) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            // Condition 7: Claim History
            stopwatch.Start();
            if (claimHistory > 0)
            {
                premium += claimHistory * 50;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 7 (Claim History) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            // Condition 8: Credit Score
            stopwatch.Start();
            if (creditScore < 600)
            {
                premium += 100;
            }
            else if (creditScore > 750)
            {
                premium -= 50;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 8 (Credit Score) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            // Condition 9: Annual Mileage
            stopwatch.Start();
            if (annualMileage > 15000)
            {
                premium += 100;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 9 (Annual Mileage) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            // Condition 10: Coverage Type
            stopwatch.Start();
            if (coverageType != null && coverageType.ToLower() == "comprehensive")
            {
                premium += 200;
            }
            else if (coverageType != null && coverageType.ToLower() == "third_party")
            {
                premium += 50;
            }
            stopwatch.Stop();
            Console.WriteLine($"Condition 10 (Coverage Type) took: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            return premium;
        }

        public static void CalculateAndListPremium()
        {
            // Method implementation
            int age = 30;
            string gender = "male";
            int drivingExperience = 5;
            string vehicleType = "suv";
            int vehicleAge = 3;
            string location = "urban";
            int claimHistory = 1;
            int creditScore = 700;
            int annualMileage = 12000;
            string coverageType = "comprehensive";

            CalculatePremium(age, gender, drivingExperience, vehicleType, vehicleAge, location, claimHistory, creditScore, annualMileage, coverageType);
        }
    }
}
