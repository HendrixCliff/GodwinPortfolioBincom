using GodwinPortfolio.DTOs;
using GodwinPortfolio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolio.Areas.Admin.Controllers;

[Area("Admin")]
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
        var articles = await _service.GetAllForAdminAsync(
            cancellationToken);

        return View(articles);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var model = new ArticleRequest();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        ArticleRequest model,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var article = await _service.CreateAsync(
            model,
            cancellationToken);

        if (article is null)
        {
            ModelState.AddModelError(
                nameof(model.Slug),
                "An article with this slug already exists.");

            return View(model);
        }

        TempData["SuccessMessage"] =
            "Article created successfully.";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(
        int id,
        CancellationToken cancellationToken)
    {
        var article = await _service.GetByIdForAdminAsync(
            id,
            cancellationToken);

        if (article is null)
        {
            return NotFound();
        }

        var model = new ArticleRequest
        {
            Title = article.Title,
            Slug = article.Slug,
            Summary = article.Summary,
            Content = article.Content,
            IsPublished = article.IsPublished
        };

        ViewBag.ArticleId = article.Id;

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        ArticleRequest model,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ArticleId = id;

            return View(model);
        }

        var article = await _service.UpdateAsync(
            id,
            model,
            cancellationToken);

        if (article is null)
        {
            ModelState.AddModelError(
                nameof(model.Slug),
                "The article could not be updated. The slug may already be in use.");

            ViewBag.ArticleId = id;

            return View(model);
        }

        TempData["SuccessMessage"] =
            "Article updated successfully.";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(
        int id,
        CancellationToken cancellationToken)
    {
        var article = await _service.GetByIdForAdminAsync(
            id,
            cancellationToken);

        if (article is null)
        {
            return NotFound();
        }

        return View(article);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(
        int id,
        CancellationToken cancellationToken)
    {
        var deleted = await _service.DeleteAsync(
            id,
            cancellationToken);

        if (!deleted)
        {
            return NotFound();
        }

        TempData["SuccessMessage"] =
            "Article deleted successfully.";

        return RedirectToAction(nameof(Index));
    }
}