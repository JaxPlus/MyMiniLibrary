using MyMiniLibrary.Dtos.Author;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Mappers;

public static class AuthorMappers
{
    public static Author ToAuthorFromCreateDto(this CreateAuthorRequestDto authorDto)
    {
        return new Author
        {
            Name = authorDto.Name
        };
    }
}