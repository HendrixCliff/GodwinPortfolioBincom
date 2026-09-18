using GodwinPortfolio.Models;
using GodwinPortfolio.Services;
using Microsoft.AspNetCore.Mvc;

namespace GodwinPortfolio.Controllers;

public sealed class GalleryController : Controller
{
    private readonly IGalleryService _galleryService;

    public GalleryController(IGalleryService galleryService)
    {
        _galleryService = galleryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var galleryItems = await _galleryService.GetAllAsync();

        return View(galleryItems);
    }

    [HttpGet]
    public IActionResult Upload()
    {
        return View(new GalleryUploadViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(
    GalleryUploadViewModel model)
    {
        Console.WriteLine("========== GALLERY UPLOAD ==========");
        Console.WriteLine($"Title: {model.Title}");
        Console.WriteLine($"Image null: {model.Image is null}");

        if (model.Image is not null)
        {
            Console.WriteLine($"Filename: {model.Image.FileName}");
            Console.WriteLine($"Length: {model.Image.Length}");
            Console.WriteLine($"ContentType: {model.Image.ContentType}");
        }

        Console.WriteLine($"ModelState valid: {ModelState.IsValid}");

        foreach (var entry in ModelState)
        {
            foreach (var error in entry.Value.Errors)
            {
                Console.WriteLine(
                    $"VALIDATION ERROR: {entry.Key} - {error.ErrorMessage}");

                if (error.Exception is not null)
                {
                    Console.WriteLine(
                        $"EXCEPTION: {error.Exception}");
                }
            }
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await _galleryService.UploadAsync(
            model.Title,
            model.Description,
            model.Image);

        if (!result.Success)
        {
            ModelState.AddModelError(
                string.Empty,
                result.ErrorMessage ??
                "The image could not be uploaded.");

            return View(model);
        }

        TempData["SuccessMessage"] =
            "Image uploaded successfully.";

        return RedirectToAction(nameof(Index));
    }
}