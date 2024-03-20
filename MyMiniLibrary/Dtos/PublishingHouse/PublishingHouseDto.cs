using MyMiniLibrary.Dtos.Book;
using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Dtos.PublishingHouse;

public class PublishingHouseDto : CommonDto {
    public int PublishingHouseId { get; set; }
    public List<BookDto> Books { get; set; }
}