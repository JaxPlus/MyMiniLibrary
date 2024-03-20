using MyMiniLibrary.Dtos.Book;
using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Dtos.Author;

public class AuthorDto : CommonDto {
    public int AuthorId { get; set; }
    public List<BookDto> Books { get; set; } = [];
}