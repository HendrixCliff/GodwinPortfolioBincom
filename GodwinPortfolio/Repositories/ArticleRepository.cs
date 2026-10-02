using GodwinPortfolio.Data;
using GodwinPortfolio.Repositories;
using GodwinPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace GodwinPortfolio.Repositories;

public sealed class ArticleRepository : IArticleRepository
{
    private readonly ApplicationDbContext _context;

    public ArticleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Article>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Articles
            .AsNoTracking()
            .OrderByDescending(x => x.PublishedAt)
            .ThenByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Article?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Articles
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    public async Task<Article?> GetBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default)
    {
        return await _context.Articles
            .FirstOrDefaultAsync(
                x => x.Slug == slug,
                cancellationToken);
    }

    public async Task AddAsync(
        Article article,
        CancellationToken cancellationToken = default)
    {
        await _context.Articles.AddAsync(
            article,
            cancellationToken);
    }

    public void Update(Article article)
    {
        _context.Articles.Update(article);
    }

    public void Delete(Article article)
    {
        _context.Articles.Remove(article);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}