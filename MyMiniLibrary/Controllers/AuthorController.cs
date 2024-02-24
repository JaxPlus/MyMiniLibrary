using Microsoft.AspNetCore.Mvc;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.Author;
using MyMiniLibrary.Mappers;

namespace MyMiniLibrary.Controllers;

[Route("api/author")]
[ApiController]
public class AuthorController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var authors = context.Authors.ToList();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var author = context.Authors.Find(id);

        return author == null ? NotFound() : Ok(author);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateAuthorRequestDto authorDto)
    {
        var authorModel = authorDto.ToAuthorFromCreateDto();
        context.Add(authorModel);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { authorId = authorModel.AuthorId }, authorModel);
    }
}