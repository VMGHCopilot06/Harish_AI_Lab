public class InsurancePolicy
{
    public double CalculateTotalPremium(double basePremium, double riskFactor, int insurerAge, string policyType, string vehicleType)
    {
        // Poor coding standards: No validation checks, no comments, and poor naming conventions
        double totalPremium = basePremium;

        // Separate if-else statements for each condition (anti-pattern)
        if (policyType == "Comprehensive")
        {
            if (vehicleType == "SUV")
                totalPremium *= 1.2;
        }
        else if (policyType == "ThirdParty")
        {
            if (vehicleType == "Sedan")
                totalPremium *= 1.1;
        }

        // Adjust premium based on insurer's age (magic numbers)
        if (insurerAge < 25)
            totalPremium *= 1.3;
        else if (insurerAge >= 60)
            totalPremium *= 0.9;

        // Apply risk factor (no comments or explanation)
        totalPremium *= riskFactor;

        // Poor naming conventions: No meaningful variable names
        return totalPremium;
    }
}
