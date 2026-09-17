using System.Collections.Generic;

namespace GodwinPortfolio.Models;

public sealed class HomeIndexViewModel
{
    public PortfolioProfile Profile { get; init; } = new();

    public List<GalleryItem> GalleryItems { get; init; } = [];
}