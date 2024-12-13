using System;

public interface IPolicy
{
    string Email { get; set; }
    string AccountNumber { get; set; }
    string PolicyNumber { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string PostalCode { get; set; }
    string Phone { get; set; }
    string ProducerCode { get; set; }
    string GroupCode { get; set; }
    string MasterCode { get; set; }
    string City { get; set; }
    string State { get; set; }
    DateTime EffectiveDate { get; set; }
    DateTime ExpirationDate { get; set; }
    decimal AnnualPremium { get; set; }
    int PolicyId { get; set; }
}
