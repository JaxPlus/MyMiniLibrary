using MyMiniLibrary.Dtos.Author;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Mappers;

public static class AuthorMappers
{
    public static Author ToAuthorDto(this Author authorModel) {
        return new Author
        {
            AuthorId = authorModel.AuthorId,
            Name = authorModel.Name
        };
    }
    
    public static Author ToAuthorFromCreateDto(this CreateAuthorRequestDto authorModel) {
        return new Author
        {
            Name = authorModel.Name
        };
    }
}