using MyMiniLibrary.Dtos.Book;
using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Dtos.Series;

public class SeriesDto : CommonDto {
    public int SeriesId { get; set; }
    public List<BookDto> Books { get; set; }
}