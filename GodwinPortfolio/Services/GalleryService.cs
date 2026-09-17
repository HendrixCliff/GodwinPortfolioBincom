using GodwinPortfolio.Data;
using GodwinPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace GodwinPortfolio.Services;

public sealed class GalleryService : IGalleryService
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _environment;

    private static readonly HashSet<string> AllowedExtensions =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".gif",
            ".webp"
        };

    private static readonly HashSet<string> AllowedContentTypes =
        new(StringComparer.OrdinalIgnoreCase)
        {
            "image/jpeg",
            "image/png",
            "image/gif",
            "image/webp"
        };

    private const long MaximumFileSize = 5 * 1024 * 1024;

    public GalleryService(
        ApplicationDbContext context,
        IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<List<GalleryItem>> GetAllAsync()
    {
        return await _context.GalleryItems
            .AsNoTracking()
            .OrderByDescending(x => x.UploadedAt)
            .ToListAsync();
    }

    public async Task<(bool Success, string? ErrorMessage)> UploadAsync(
        string title,
        string? description,
        IFormFile? image)
    {
        title = title.Trim();
        description = description?.Trim();

        if (string.IsNullOrWhiteSpace(title))
        {
            return (
                false,
                "Please enter an image title.");
        }

        if (title.Length > 150)
        {
            return (
                false,
                "The image title cannot exceed 150 characters.");
        }

        if (!string.IsNullOrWhiteSpace(description) &&
            description.Length > 500)
        {
            return (
                false,
                "The image description cannot exceed 500 characters.");
        }

        var validationError = ValidateImage(image);

        if (validationError is not null)
        {
            return (false, validationError);
        }

        var uploadFolder = Path.Combine(
            _environment.WebRootPath,
            "uploads",
            "gallery");

        Directory.CreateDirectory(uploadFolder);

        var extension = Path.GetExtension(
            image!.FileName)
            .ToLowerInvariant();

        var uniqueFileName =
            $"{Guid.NewGuid():N}{extension}";

        var physicalFilePath = Path.Combine(
            uploadFolder,
            uniqueFileName);

        try
        {
            await using (var fileStream = new FileStream(
                physicalFilePath,
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None))
            {
                await image.CopyToAsync(fileStream);
            }

            var galleryItem = new GalleryItem
            {
                Title = title,
                Description = description ?? string.Empty,
                ImagePath =
                    $"/uploads/gallery/{uniqueFileName}",
                UploadedAt = DateTime.UtcNow
            };

            _context.GalleryItems.Add(galleryItem);

            await _context.SaveChangesAsync();

            return (true, null);
        }
        catch
        {
            if (File.Exists(physicalFilePath))
            {
                File.Delete(physicalFilePath);
            }

            throw;
        }
    }

    private static string? ValidateImage(IFormFile? image)
    {
        if (image is null || image.Length == 0)
        {
            return "Please select an image.";
        }

        if (image.Length > MaximumFileSize)
        {
            return "The image must be 5 MB or smaller.";
        }

        var extension = Path.GetExtension(
            image.FileName)
            .ToLowerInvariant();

        if (!AllowedExtensions.Contains(extension))
        {
            return
                "Only JPG, JPEG, PNG, GIF and WEBP images are allowed.";
        }

        if (!AllowedContentTypes.Contains(
                image.ContentType))
        {
            return
                "The uploaded file must be a valid image type.";
        }

        return null;
    }
}