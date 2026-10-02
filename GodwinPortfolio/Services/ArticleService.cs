using GodwinPortfolio.DTOs.Article;
using GodwinPortfolio.Repositories;
using GodwinPortfolio.Services;
using GodwinPortfolio.Models;


namespace GodwinPortfolio.Services;

public sealed class ArticleService : IArticleService
{
    private readonly IArticleRepository _repository;

    public ArticleService(IArticleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ArticleResponse>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var articles = await _repository.GetAllAsync(cancellationToken);

        return articles
            .Where(x => x.IsPublished)
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<ArticleResponse?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var article = await _repository.GetByIdAsync(
            id,
            cancellationToken);

        if (article is null || !article.IsPublished)
        {
            return null;
        }

        return MapToResponse(article);
    }

    public async Task<ArticleResponse?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default)
    {
        var article = await _repository.GetBySlugAsync(
            slug,
            cancellationToken);

        if (article is null || !article.IsPublished)
        {
            return null;
        }

        return MapToResponse(article);
    }

    public async Task<ArticleResponse?> CreateAsync(
        ArticleRequest request,
        CancellationToken cancellationToken = default)
    {
        var slug = NormalizeSlug(request.Slug);

        var existing = await _repository.GetBySlugAsync(
            slug,
            cancellationToken);

        if (existing is not null)
        {
            return null;
        }

        var now = DateTime.UtcNow;

        var article = new Article
        {
            Title = request.Title.Trim(),
            Slug = slug,
            Summary = request.Summary.Trim(),
            Content = request.Content.Trim(),
            CreatedAt = now,
            IsPublished = request.IsPublished,
            PublishedAt = request.IsPublished ? now : null
        };

        await _repository.AddAsync(
            article,
            cancellationToken);

        await _repository.SaveChangesAsync(
            cancellationToken);

        return MapToResponse(article);
    }

    public async Task<ArticleResponse?> UpdateAsync(
        int id,
        ArticleRequest request,
        CancellationToken cancellationToken = default)
    {
        var article = await _repository.GetByIdAsync(
            id,
            cancellationToken);

        if (article is null)
        {
            return null;
        }

        var slug = NormalizeSlug(request.Slug);

        var existing = await _repository.GetBySlugAsync(
            slug,
            cancellationToken);

        if (existing is not null && existing.Id != id)
        {
            return null;
        }

        article.Title = request.Title.Trim();
        article.Slug = slug;
        article.Summary = request.Summary.Trim();
        article.Content = request.Content.Trim();

        if (request.IsPublished && !article.IsPublished)
        {
            article.PublishedAt = DateTime.UtcNow;
        }

        if (!request.IsPublished)
        {
            article.PublishedAt = null;
        }

        article.IsPublished = request.IsPublished;

        _repository.Update(article);

        await _repository.SaveChangesAsync(
            cancellationToken);

        return MapToResponse(article);
    }

    public async Task<bool> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var article = await _repository.GetByIdAsync(
            id,
            cancellationToken);

        if (article is null)
        {
            return false;
        }

        _repository.Delete(article);

        await _repository.SaveChangesAsync(
            cancellationToken);

        return true;
    }

    private static string NormalizeSlug(string slug)
    {
        return slug
            .Trim()
            .ToLowerInvariant()
            .Replace(" ", "-");
    }

    private static ArticleResponse MapToResponse(
        Article article)
    {
        return new ArticleResponse
        {
            Id = article.Id,
            Title = article.Title,
            Slug = article.Slug,
            Summary = article.Summary,
            Content = article.Content,
            CreatedAt = article.CreatedAt,
            PublishedAt = article.PublishedAt,
            IsPublished = article.IsPublished
        };
    }
}