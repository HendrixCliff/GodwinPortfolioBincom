using GodwinPortfolio.Services;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolio.Controllers;

public sealed class ArticlesController : Controller
{
    private readonly IArticleService _service;

    public ArticlesController(IArticleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index(
        CancellationToken cancellationToken)
    {
        var articles = await _service.GetAllAsync(
            cancellationToken);

        return View(articles);
    }

    [HttpGet]
    public async Task<IActionResult> Details(
        string slug,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(slug))
        {
            return NotFound();
        }

        var article = await _service.GetBySlugAsync(
            slug,
            cancellationToken);

        if (article is null)
        {
            return NotFound();
        }

        return View(article);
    }
}