using GodwinPortfolio.Models;

namespace GodwinPortfolio.Services;

public sealed class NigeriaTaxCalculator
{
    public TaxCalculatorViewModel Calculate(
        TaxCalculatorViewModel model)
    {
        var rentRelief = Math.Min(
            model.AnnualRent * 0.20m,
            500_000m);

        var totalDeductions =
            rentRelief
            + model.PensionContribution
            + model.NhfContribution
            + model.NhisContribution
            + model.LifeInsurance
            + model.MortgageInterest;

        var chargeableIncome = Math.Max(
            0,
            model.AnnualGrossIncome - totalDeductions);

        var tax = CalculateProgressiveTax(chargeableIncome);

        model.RentRelief = rentRelief;
        model.TotalDeductions = totalDeductions;
        model.ChargeableIncome = chargeableIncome;
        model.AnnualTax = tax;
        model.MonthlyTax = tax / 12m;

        model.EffectiveTaxRate =
            model.AnnualGrossIncome > 0
                ? tax / model.AnnualGrossIncome * 100m
                : 0;

        model.HasResult = true;

        return model;
    }

    private static decimal CalculateProgressiveTax(
        decimal taxableIncome)
    {
        decimal remaining = taxableIncome;
        decimal tax = 0;

        // First ₦800,000 at 0%
        remaining = ApplyBand(
            remaining,
            800_000m,
            0m,
            ref tax);

        // Next ₦2,200,000 at 15%
        remaining = ApplyBand(
            remaining,
            2_200_000m,
            0.15m,
            ref tax);

        // Next ₦9,000,000 at 18%
        remaining = ApplyBand(
            remaining,
            9_000_000m,
            0.18m,
            ref tax);

        // Next ₦13,000,000 at 21%
        remaining = ApplyBand(
            remaining,
            13_000_000m,
            0.21m,
            ref tax);

        // Next ₦25,000,000 at 23%
        remaining = ApplyBand(
            remaining,
            25_000_000m,
            0.23m,
            ref tax);

        // Above ₦50,000,000 at 25%
        if (remaining > 0)
        {
            tax += remaining * 0.25m;
        }

        return Math.Round(
            tax,
            2,
            MidpointRounding.AwayFromZero);
    }

    private static decimal ApplyBand(
        decimal remaining,
        decimal bandSize,
        decimal rate,
        ref decimal tax)
    {
        if (remaining <= 0)
        {
            return 0;
        }

        var taxableAmount =
            Math.Min(remaining, bandSize);

        tax += taxableAmount * rate;

        return remaining - taxableAmount;
    }
}