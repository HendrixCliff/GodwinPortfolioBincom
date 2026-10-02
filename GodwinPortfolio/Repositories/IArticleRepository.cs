using GodwinPortfolio.Models;

namespace GodwinPortfolio.Repositories;

public interface IArticleRepository
{
    Task<IReadOnlyList<Article>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Article?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<Article?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Article article,
        CancellationToken cancellationToken = default);

    void Update(Article article);

    void Delete(Article article);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}