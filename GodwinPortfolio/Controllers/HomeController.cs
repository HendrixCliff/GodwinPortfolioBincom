using GodwinPortfolio.Data;
using GodwinPortfolio.Models;
using GodwinPortfolio.Services;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolio.Controllers;

public sealed class HomeController : Controller
{
    private readonly NigeriaTaxCalculator _taxCalculator;

    public HomeController(
        NigeriaTaxCalculator taxCalculator)
    {
        _taxCalculator = taxCalculator;
    }

    public IActionResult Index()
    {
        return View(PortfolioData.BuildProfile());
    }

    public IActionResult About()
    {
        return View(PortfolioData.BuildProfile());
    }

    public IActionResult Experience()
    {
        return View(PortfolioData.BuildExperience());
    }

    public IActionResult Projects()
    {
        return View(PortfolioData.BuildProjects());
    }

    [HttpGet]
    public IActionResult Skills()
    {
        return View(PortfolioData.BuildSkills());
    }

    [HttpGet]
    public IActionResult TaxCalculator()
    {
        return View(new TaxCalculatorViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TaxCalculator(
        TaxCalculatorViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = _taxCalculator.Calculate(model);

        return View(result);
    }
}