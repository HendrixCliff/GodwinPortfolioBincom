using GodwinPortfolio.Data;
using GodwinPortfolio.Models;
using GodwinPortfolio.Services;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolio.Controllers;

public sealed class HomeController : Controller
{
    private readonly NigeriaTaxCalculator _taxCalculator;
    private readonly IGalleryService _galleryService;

    public HomeController(
        NigeriaTaxCalculator taxCalculator,
        IGalleryService galleryService)
    {
        _taxCalculator = taxCalculator;
        _galleryService = galleryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = new HomeIndexViewModel
        {
            Profile = PortfolioData.BuildProfile(),
            GalleryItems = await _galleryService.GetAllAsync()
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult About()
    {
        return View(PortfolioData.BuildProfile());
    }

    [HttpGet]
    public IActionResult Experience()
    {
        return View(PortfolioData.BuildExperience());
    }

    [HttpGet]
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