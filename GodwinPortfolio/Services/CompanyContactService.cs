using GodwinPortfolio.Models;
using GodwinPortfolio.Repositories;


namespace GodwinPortfolio.Services;

public sealed class CompanyContactService
    : ICompanyContactService
{
    private readonly ICompanyContactRepository _repository;

    public CompanyContactService(
        ICompanyContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<CompanyContact> GetAsync(
        CancellationToken cancellationToken = default)
    {
        var company = await _repository.GetAsync(
            cancellationToken);

        if (company is not null)
        {
            return company;
        }

        company = new CompanyContact
        {
            CompanyName = "Godwin Technologies",
            Description =
                "We build modern software solutions for businesses and individuals.",
            Email = "hello@example.com",
            Phone = "+234 000 000 0000",
            Address = "Business Address",
            City = "Lagos",
            Country = "Nigeria",
            Website = "https://example.com",
            LinkedInUrl = "https://linkedin.com",
            GitHubUrl = "https://github.com",
            BusinessHours =
                "Monday - Friday, 9:00 AM - 5:00 PM"
        };

        await _repository.AddAsync(
            company,
            cancellationToken);

        await _repository.SaveChangesAsync(
            cancellationToken);

        return company;
    }
}