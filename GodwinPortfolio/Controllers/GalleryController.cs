using GodwinPortfolio.Services;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolio.Controllers;

public sealed class GalleryController : Controller
{
    private readonly IGalleryService _galleryService;

    public GalleryController(
        IGalleryService galleryService)
    {
        _galleryService = galleryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var galleryItems =
            await _galleryService.GetAllAsync();

        return View(galleryItems);
    }

    [HttpGet]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(
        string title,
        string? description,
        IFormFile? image)
    {
        var result = await _galleryService.UploadAsync(
            title,
            description,
            image);

        if (!result.Success)
        {
            ModelState.AddModelError(
                "Image",
                result.ErrorMessage!);

            ViewData["TitleValue"] = title;
            ViewData["DescriptionValue"] = description;

            return View();
        }

        TempData["SuccessMessage"] =
            "Image uploaded successfully.";

        return RedirectToAction(nameof(Index));
    }
}