using MyMiniLibrary.Dtos.Book;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Mappers;

public static class BookMappers
{
    public static BookDto ToBookDto(this Book bookModel)
    {
        return new BookDto
        {
            Name = bookModel.Name,
            Price = bookModel.Price,
            Volume = bookModel.Volume,
            AuthorId = bookModel.AuthorId,
            Author = bookModel.Author,
            SeriesId = bookModel.SeriesId,
            Series = bookModel.Series,
        };
    }
}