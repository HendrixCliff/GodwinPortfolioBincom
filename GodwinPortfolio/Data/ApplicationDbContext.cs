
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

    public DbSet<CompanyContact> CompanyContacts { get; set; }

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
        modelBuilder.Entity<CompanyContact>(entity =>
        {
            entity.ToTable("CompanyContacts");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.Description)
                .HasMaxLength(1000);

            entity.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Phone)
                .HasMaxLength(50);

            entity.Property(x => x.Address)
                .HasMaxLength(300);

            entity.Property(x => x.City)
                .HasMaxLength(100);

            entity.Property(x => x.Country)
                .HasMaxLength(100);

            entity.Property(x => x.Website)
                .HasMaxLength(200);

            entity.Property(x => x.LinkedInUrl)
                .HasMaxLength(200);

            entity.Property(x => x.GitHubUrl)
                .HasMaxLength(200);

            entity.Property(x => x.BusinessHours)
                .HasMaxLength(200);
        });
    }
}
