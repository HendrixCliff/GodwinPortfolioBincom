using GodwinPortfolio.DTOs.Article;


namespace GodwinPortfolio.Services;

public interface IArticleService
{
    Task<IReadOnlyList<ArticleResponse>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<ArticleResponse?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<ArticleResponse?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task<ArticleResponse?> CreateAsync(
        ArticleRequest request,
        CancellationToken cancellationToken = default);

    Task<ArticleResponse?> UpdateAsync(
        int id,
        ArticleRequest request,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default);
}