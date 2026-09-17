
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

}

