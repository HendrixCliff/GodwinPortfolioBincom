using GodwinPortfolio.Models;

namespace GodwinPortfolio.Services;

public interface IGalleryService
{
    Task<List<GalleryItem>> GetAllAsync();

    Task<(bool Success, string? ErrorMessage)> UploadAsync(
        string title,
        string? description,
        IFormFile? image);
}