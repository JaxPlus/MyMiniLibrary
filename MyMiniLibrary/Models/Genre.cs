namespace MyMiniLibrary.Models;

public class Genre
{
    public int GenreId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BookGenre> BookGenres { get; set; } = [];
}