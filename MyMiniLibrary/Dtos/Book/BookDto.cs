namespace MyMiniLibrary.Dtos.Book;

public class BookDto
{
    public int BookId { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int AuthorId { get; set; }
    public Models.Author Author { get; set; } = new();
    public int Volume { get; set; }
}