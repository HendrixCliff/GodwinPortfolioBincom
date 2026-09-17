
using GodwinPortfolio.Models;

using GodwinPortfolio.Services;

using Microsoft.AspNetCore.Http;

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

        return View();

    }



    [HttpPost]

    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Upload(

        GalleryItem model,

        IFormFile? image)

    {

        if (!ModelState.IsValid)

        {

            return View(model);

        }



        var result = await _galleryService.UploadAsync(

            model.Title,

            model.Description,

            image);



        if (!result.Success)

        {

            ModelState.AddModelError(

                string.Empty,

                result.ErrorMessage ?? "The image could not be uploaded.");



            return View(model);

        }



        TempData["SuccessMessage"] = "Image uploaded successfully.";



        return RedirectToAction(nameof(Index));

    }

}

