using System.ComponentModel.DataAnnotations;

namespace GodwinPortfolio.Models;

public sealed class TaxCalculatorViewModel
{
    [Display(Name = "Annual Gross Income")]
    [Range(0, double.MaxValue)]
    public decimal AnnualGrossIncome { get; set; }

    [Display(Name = "Annual Rent Paid")]
    [Range(0, double.MaxValue)]
    public decimal AnnualRent { get; set; }

    [Display(Name = "Annual Pension Contribution")]
    [Range(0, double.MaxValue)]
    public decimal PensionContribution { get; set; }

    [Display(Name = "Annual NHF Contribution")]
    [Range(0, double.MaxValue)]
    public decimal NhfContribution { get; set; }

    [Display(Name = "Annual NHIS Contribution")]
    [Range(0, double.MaxValue)]
    public decimal NhisContribution { get; set; }

    [Display(Name = "Life Insurance / Qualifying Annuity")]
    [Range(0, double.MaxValue)]
    public decimal LifeInsurance { get; set; }

    [Display(Name = "Owner-Occupied Home Loan Interest")]
    [Range(0, double.MaxValue)]
    public decimal MortgageInterest { get; set; }

    public decimal RentRelief { get; set; }
    public decimal TotalDeductions { get; set; }
    public decimal ChargeableIncome { get; set; }
    public decimal AnnualTax { get; set; }
    public decimal MonthlyTax { get; set; }
    public decimal EffectiveTaxRate { get; set; }

    public bool HasResult { get; set; }
}