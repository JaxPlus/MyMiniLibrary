using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Dtos.Book;

public class CreateBookRequestDto : CommonDto {
    public double Price { get; set; }
    public int Volume { get; set; }
}