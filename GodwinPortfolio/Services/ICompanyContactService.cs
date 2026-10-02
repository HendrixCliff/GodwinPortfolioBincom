using GodwinPortfolio.Models;


namespace GodwinPortfolio.Services;

public interface ICompanyContactService
{
    Task<CompanyContact> GetAsync(
        CancellationToken cancellationToken = default);
}