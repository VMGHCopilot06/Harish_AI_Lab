using System;
using System.ComponentModel.DataAnnotations;

public static class PolicyValidator
{
    public static ValidationResult ValidateEffectiveDate(DateTime effectiveDate, ValidationContext context)
    {
        if (effectiveDate > DateTime.Now)
        {
            return new ValidationResult("Effective Date must be less than or equal to the current date.");
        }
        return ValidationResult.Success;
    }

    public static ValidationResult ValidateExpirationDate(DateTime expirationDate, ValidationContext context)
    {
        var instance = context.ObjectInstance as Policy;
        if (instance != null && expirationDate < instance.EffectiveDate)
        {
            return new ValidationResult("Expiration Date must be greater than or equal to the Effective Date.");
        }
        return ValidationResult.Success;
    }
}
