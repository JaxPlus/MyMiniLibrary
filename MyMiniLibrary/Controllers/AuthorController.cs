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

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var authorModel = context.Authors.Find(id);

        return authorModel == null ? NotFound() : Ok(authorModel);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateAuthorRequestDto authorDto)
    {
        var authorModel = authorDto.ToAuthorFromCreateDto();
        context.Add(authorModel);
        context.SaveChanges();
        return CreatedAtAction(nameof(Create), new { authorId = authorModel.AuthorId }, authorModel);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateAuthorRequestDto authorDto) {
        var authorModel = context.Authors.FirstOrDefault(x => x.AuthorId == id);

        if (authorModel == null) {
            return NotFound();
        }

        authorModel.Name = authorDto.Name;

        context.SaveChanges();
        return Ok(authorModel.ToAuthorDto());
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id) {
        var authorModel = context.Authors.FirstOrDefault(x => x.AuthorId == id);

        if (authorModel == null) {
            return NotFound();
        }

        context.Authors.Remove(authorModel);
        context.SaveChanges();
        return NoContent();
    }
}