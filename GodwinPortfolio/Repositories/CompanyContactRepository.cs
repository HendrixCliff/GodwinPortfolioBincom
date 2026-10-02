using GodwinPortfolio.Data;
using GodwinPortfolio.Models;
using GodwinPortfolio.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GodwinPortfolio.Repositories;

public sealed class CompanyContactRepository
    : ICompanyContactRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyContactRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyContact?> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.CompanyContacts
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(
        CompanyContact company,
        CancellationToken cancellationToken = default)
    {
        await _context.CompanyContacts.AddAsync(
            company,
            cancellationToken);
    }

    public void Update(CompanyContact company)
    {
        _context.CompanyContacts.Update(company);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}