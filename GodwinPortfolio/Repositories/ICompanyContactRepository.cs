using GodwinPortfolio.Models;

namespace GodwinPortfolio.Repositories;

public interface ICompanyContactRepository
{
    Task<CompanyContact?> GetAsync(
        CancellationToken cancellationToken = default);

    Task AddAsync(
        CompanyContact company,
        CancellationToken cancellationToken = default);

    void Update(CompanyContact company);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}