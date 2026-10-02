using System.ComponentModel.DataAnnotations;

namespace GodwinPortfolio.Models;

public sealed class CompanyContact
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string CompanyName { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string Email { get; set; } = string.Empty;

    [StringLength(50)]
    public string Phone { get; set; } = string.Empty;

    [StringLength(300)]
    public string Address { get; set; } = string.Empty;

    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [StringLength(100)]
    public string Country { get; set; } = string.Empty;

    [StringLength(200)]
    public string Website { get; set; } = string.Empty;

    [StringLength(200)]
    public string LinkedInUrl { get; set; } = string.Empty;

    [StringLength(200)]
    public string GitHubUrl { get; set; } = string.Empty;

    [StringLength(200)]
    public string BusinessHours { get; set; } = string.Empty;
}