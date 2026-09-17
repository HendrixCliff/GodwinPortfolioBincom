using System.Collections.Generic;
namespace GodwinPortfolio.Models;

public sealed class PortfolioProfile
{
    public string Name { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Summary { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string GitHub { get; init; } = string.Empty;
    public string PortfolioUrl { get; init; } = string.Empty;
    public string Education { get; init; } = string.Empty;
}

public sealed class Experience
{
    public string Company { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    public string Period { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public List<string> Highlights { get; init; } = [];
    public List<string> Technologies { get; init; } = [];
}

public sealed class Project
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public List<string> Technologies { get; init; } = [];
}

public sealed class SkillGroup
{
    public string Category { get; init; } = string.Empty;
    public List<string> Skills { get; init; } = [];
}