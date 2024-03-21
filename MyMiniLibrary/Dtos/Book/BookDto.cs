using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Dtos.Book;

public class BookDto : CommonDto
{
    public int BookId { get; set; }
    public double Price { get; set; }
    public int Volume { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string SeriesName { get; set; } = string.Empty;
    public string PublishingHouseName { get; set; } = string.Empty;
}