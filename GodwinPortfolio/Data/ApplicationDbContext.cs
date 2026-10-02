
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
    public DbSet<Article> Articles { get; set; }

    public DbSet<CompanyContact> CompanyContacts { get; set; } = null!;

    protected override void OnModelCreating(
      ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(250);

            entity.HasIndex(x => x.Slug)
                .IsUnique();

            entity.Property(x => x.Summary)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(x => x.Content)
                .IsRequired();
        });
    }
}
