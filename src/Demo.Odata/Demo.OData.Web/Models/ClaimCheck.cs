using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.OData.Web.Models
{
    public class ClaimCheck
    {
        public List<Claim> Claims { get; set; }
    }

    public class Claim
    {
        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public ClaimType Type { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
        public Patient Patient { get; set; }
        public Payer Payer { get; set; }
        public List<RevLineItem> RevLineItems { get; set; }
        public List<ICD9> Diagnosis { get; set; }
    }

    public enum ClaimType
    {
        UB04
    }

    public class Patient
    {
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Payer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PayerType Type { get; set; }
        public int ContractorId { get; set; }
        public string State { get; set; }
    }

    public enum PayerType
    {
        A
    }

    public class RevLineItem
    {
        public int Id { get; set; }
        public string RevenueCode { get; set; }
        public string HCPCSCode { get; set; }
        public List<Modifier> Modifiers { get; set; }
        public DateTime DateOfService { get; set; }
        public int Units { get; set; }
        public decimal TotalCharges { get; set; }
        public decimal NonCoveredCharges { get; set; }
    }

    public class Modifier
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }

    public class ICD9
    {
        public int Id { get; set; }
        public bool IsPrimary { get; set; }
        public decimal Amount { get; set; }
    }
}