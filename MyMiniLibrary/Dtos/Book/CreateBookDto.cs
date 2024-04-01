using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Dtos.Book;

public class CreateBookDto : CommonDto {
    public int BookId { get; set; }
    public double Price { get; set; }
    public int Volume { get; set; }
}