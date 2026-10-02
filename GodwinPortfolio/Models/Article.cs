using System.ComponentModel.DataAnnotations;

namespace GodwinPortfolio.Models;

public sealed class Article
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(250)]
    public string Slug { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Summary { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? PublishedAt { get; set; }

    public bool IsPublished { get; set; }
}