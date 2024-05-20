using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Dtos.Book;

public class CreateBookRequestDto : CommonDto {
    public double Price { get; set; }
    public int Volume { get; set; }
    public int AuthorId { get; set; }
    public int PublishingHouseId { get; set; }
    public int SeriesId { get; set; }
}