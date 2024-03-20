namespace MyMiniLibrary.Models;

public class PublishingHouse
{
    public int PublishingHouseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Book> Books { get; set; } = [];
}