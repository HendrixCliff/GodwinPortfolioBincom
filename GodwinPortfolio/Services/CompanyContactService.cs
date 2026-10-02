using GodwinPortfolio.Models;
using GodwinPortfolio.Repositories;

namespace GodwinPortfolio.Services;

public sealed class CompanyContactService : ICompanyContactService
{
    private readonly ICompanyContactRepository _repository;

    public CompanyContactService(
        ICompanyContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<CompanyContact?> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetAsync(cancellationToken);
    }
}