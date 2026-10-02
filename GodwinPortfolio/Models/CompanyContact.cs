using System.ComponentModel.DataAnnotations;

namespace GodwinPortfolio.Models;

public sealed class CompanyContact
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string CompanyName { get; set; } = "CoffeBean Devs";

    [StringLength(1000)]
    public string Description { get; set; } =
        "CoffeBean Devs builds modern software solutions, web applications, and digital products using reliable and scalable technologies.";

    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string Email { get; set; } =
        "godwincliff10@gmail.com";

    [StringLength(50)]
    public string Phone { get; set; } =
        "+234 7043455089";

    [StringLength(300)]
    public string Address { get; set; } =
        "Lagos, Nigeria";

    [StringLength(100)]
    public string City { get; set; } =
        "Ajah";

    [StringLength(100)]
    public string Country { get; set; } =
        "Nigeria";

    [StringLength(200)]
    public string Website { get; set; } =
        "https://godwin-portfolio-ivory.vercel.app/";

    [StringLength(200)]
    public string LinkedInUrl { get; set; } =
        "https://www.linkedin.com/in/godwin-igwegbe-181a63359?utm_source=share_via&utm_content=profile&utm_medium=member_android";

    [StringLength(200)]
    public string GitHubUrl { get; set; } =
        "https://github.com/HendrixCliff";

    [StringLength(200)]
    public string BusinessHours { get; set; } =
        "Monday - Friday, 9:00 AM - 5:00 PM";
}