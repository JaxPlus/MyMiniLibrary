using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.Author;
using MyMiniLibrary.Interfaces;
using MyMiniLibrary.Mappers;
using MyMiniLibrary.Repository;

namespace MyMiniLibrary.Controllers;

[Route("api/author")]
[ApiController]
public class AuthorController(IAuthorRepository authorRepo) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var authors = await authorRepo.GetAllAsync();
        var authorDto = authors.Select(a => a.ToAuthorDto());
        
        return Ok(authorDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) {
        var authorModel = await authorRepo.GetByIdAsync(id);

        return authorModel == null ? NotFound() : Ok(authorModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuthorRequestDto authorDto) {
        var authorModel = authorDto.ToAuthorFromCreateDto();

        await authorRepo.CreateAsync(authorModel);
        return CreatedAtAction(nameof(Create), new { authorId = authorModel.AuthorId }, authorModel);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorRequestDto authorDto) {
        var authorModel = await authorRepo.UpdateAsync(id, authorDto);

        if (authorModel == null) {
            return NotFound();
        }

        return Ok(authorModel);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) {
        var authorModel = await authorRepo.DeleteAsync(id);

        if (authorModel == null) {
            return NotFound();
        }
        
        return NoContent();
    }
}