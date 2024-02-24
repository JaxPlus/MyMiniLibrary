using MyMiniLibrary.Dtos.Book;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Mappers;

public static class BookMappers
{
    public static BookDto ToBookDto(this Book bookModel)
    {
        return new BookDto
        {
            BookId = bookModel.BookId,
            Name = bookModel.Name,
            AuthorId = bookModel.AuthorId,
            Author = bookModel.Author,
            Price = bookModel.Price,
            Volume = bookModel.Volume,
        };
    }
}