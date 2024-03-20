using System.ComponentModel.DataAnnotations.Schema;

namespace MyMiniLibrary.Models;

public class Book
{
    public int BookId { get; set; }
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "decimal(5,2)")]
    public double Price { get; set; }
    public int Volume { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public int PublishingHouseId { get; set; }
    public PublishingHouse PublishingHouse { get; set; } = null!;
    public int SeriesId { get; set; }
    public Series Series { get; set; } = null!;
    public List<BookGenre?> BookGenres { get; set; } = [];
}