
using GodwinPortfolio.Models;

using Microsoft.EntityFrameworkCore;



namespace GodwinPortfolio.Data;



public sealed class ApplicationDbContext : DbContext

{

    public ApplicationDbContext(

        DbContextOptions<ApplicationDbContext> options)

        : base(options)

    {

    }

    public DbSet<GalleryItem> GalleryItems => Set<GalleryItem>();
    public DbSet<Article> Articles { get; set; } = null!;

    public DbSet<CompanyContact> CompanyContacts { get; set; } = null!;

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
    .HasIndex(x => x.Slug)
    .IsUnique();
    }
  }
