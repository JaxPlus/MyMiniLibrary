using MyMiniLibrary.Dtos.Author;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Mappers;

public static class AuthorMappers
{
    public static AuthorDto ToAuthorDto(this Author authorModel) {
        return new AuthorDto
        {
            AuthorId = authorModel.AuthorId,
            Name = authorModel.Name,
            Books = authorModel.Books.Select(b => b.ToBookDto()).ToList(),
        };
    }
    
    public static Author ToAuthorFromCreateDto(this CreateAuthorRequestDto authorModel) {
        return new Author
        {
            Name = authorModel.Name
        };
    }
}