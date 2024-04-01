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
            Price = bookModel.Price,
            Volume = bookModel.Volume,
            AuthorName = bookModel.Author.Name,
            SeriesName = bookModel.Series.Name,
            PublishingHouseName = bookModel.PublishingHouse.Name,
        };
    }
    public static CreateBookDto ToCreateBookDto(this Book bookModel) {
        return new CreateBookDto
        {
            BookId = bookModel.BookId,
            Name = bookModel.Name,
            Price = bookModel.Price,
            Volume = bookModel.Volume
        };
    }
    public static Book ToBookFromCreate(this CreateBookRequestDto bookModel,
        int authorId,
        int seriesId,
        int publishingHouseId)
    {
        return new Book
        {
            Name = bookModel.Name,
            Price = bookModel.Price,
            Volume = bookModel.Volume,
            AuthorId = authorId,
            SeriesId = seriesId,
            PublishingHouseId = publishingHouseId,
        };
    }
}