using Microsoft.EntityFrameworkCore;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; } 
    public DbSet<Series> Series { get; set; }
};