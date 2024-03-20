namespace MyMiniLibrary.Models;

public class Series
{
    public int SeriesId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Book> Books { get; set; } = [];
}