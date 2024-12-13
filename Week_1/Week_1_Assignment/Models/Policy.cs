using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents an insurance policy with various details.
/// </summary>
public class Policy : IPolicy
{
    /// <summary>
    /// Gets or sets the email address associated with the policy.
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the account number associated with the policy.
    /// Must be an 8-digit number.
    /// </summary>
    [Required]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Account Number must be an 8 digit number.")]
    public string AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets the policy number.
    /// Must be an 8-digit number.
    /// </summary>
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Policy Number must be an 8 digit number.")]
    public string PolicyNumber { get; set; }

    /// <summary>
    /// Gets or sets the first name of the policyholder.
    /// Must be a non-empty string with a maximum length of 50 characters.
    /// </summary>
    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must be a non-empty string with a maximum length of 50 characters.")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the policyholder.
    /// Must be a non-empty string with a maximum length of 50 characters.
    /// </summary>
    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name must be a non-empty string with a maximum length of 50 characters.")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the postal code associated with the policy.
    /// Must be a 7-digit number.
    /// </summary>
    [RegularExpression(@"^\d{7}$", ErrorMessage = "Postal Code must be a 7 digit number.")]
    public string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the phone number associated with the policy.
    /// </summary>
    [Required]
    [Phone]
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the producer code associated with the policy.
    /// Must be a non-empty string with a maximum length of 5 characters.
    /// </summary>
    [Required]
    [StringLength(5, MinimumLength = 1, ErrorMessage = "Producer Code must be a non-empty string with a maximum length of 5 characters.")]
    public string ProducerCode { get; set; }

    /// <summary>
    /// Gets or sets the group code associated with the policy.
    /// Must be a non-empty string with a maximum length of 5 characters.
    /// </summary>
    [Required]
    [StringLength(5, MinimumLength = 1, ErrorMessage = "Group Code must be a non-empty string with a maximum length of 5 characters.")]
    public string GroupCode { get; set; }

    /// <summary>
    /// Gets or sets the master code associated with the policy.
    /// Must be a non-empty string with a maximum length of 5 characters.
    /// </summary>
    [Required]
    [StringLength(5, MinimumLength = 1, ErrorMessage = "Master Code must be a non-empty string with a maximum length of 5 characters.")]
    public string MasterCode { get; set; }

    /// <summary>
    /// Gets or sets the city associated with the policy.
    /// Must be a non-empty string with a maximum length of 20 characters.
    /// </summary>
    [Required]
    [StringLength(20, MinimumLength = 1, ErrorMessage = "City must be a non-empty string with a maximum length of 20 characters.")]
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the state associated with the policy.
    /// Must be a non-empty string with a maximum length of 20 characters.
    /// </summary>
    [Required]
    [StringLength(20, MinimumLength = 1, ErrorMessage = "State must be a non-empty string with a maximum length of 20 characters.")]
    public string State { get; set; }

    /// <summary>
    /// Gets or sets the effective date of the policy.
    /// </summary>
    [Required]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(PolicyValidator), nameof(PolicyValidator.ValidateEffectiveDate))]
    public DateTime EffectiveDate { get; set; }

    /// <summary>
    /// Gets or sets the expiration date of the policy.
    /// </summary>
    [Required]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(PolicyValidator), nameof(PolicyValidator.ValidateExpirationDate))]
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    /// Gets or sets the annual premium of the policy.
    /// Must be a non-zero value with up to 2 decimal places.
    /// </summary>
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Annual Premium must be a non-zero value with up to 2 decimal places.")]
    [DataType(DataType.Currency)]
    public decimal AnnualPremium { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the policy.
    /// </summary>
    public int PolicyId { get; set; }
}
