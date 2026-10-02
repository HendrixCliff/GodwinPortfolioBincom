using GodwinPortfolio.Models;
using GodwinPortfolio.Services;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolio.Controllers;

public sealed class ContactController : Controller
{
    private readonly ICompanyContactService _service;

    public ContactController(ICompanyContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index(
        CancellationToken cancellationToken)
    {
        var company = await _service.GetAsync(cancellationToken);

        if (company is null)
        {
            company = new CompanyContact();
        }

        return View(company);
    }
}