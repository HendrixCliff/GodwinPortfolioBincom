using System.ComponentModel.DataAnnotations;

namespace GodwinPortfolio.DTOs.Article;

public sealed class ArticleRequest
{
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

    public bool IsPublished { get; set; }
}