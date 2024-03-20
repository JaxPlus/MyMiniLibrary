using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Dtos.Book;

public class UpdateBookRequestDto : CommonDto {
    public double Price { get; set; }
    public int Volume { get; set; }
}