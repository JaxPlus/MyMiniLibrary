using Microsoft.AspNetCore.Mvc;
using MyMiniLibrary.Dtos.Book;
using MyMiniLibrary.Interfaces;

namespace MyMiniLibrary.Controllers;

[Route("api/book")]
[ApiController]
public class BookController(IBookRepository bookRepo) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var books = await bookRepo.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) {
        var bookModel = await bookRepo.GetByIdAsync(id);

        return bookModel == null ? NotFound() : Ok(bookModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookRequestDto bookDto) {
        throw new NotImplementedException();
        
        // var bookModel = bookDto.ToSeriesFromCreateDto();
        //
        // await bookRepo.CreateAsync(bookModel);
        // return CreatedAtAction(nameof(Create), new { BookId = bookModel.BookId }, bookModel);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookRequestDto bookDto) {
        throw new NotImplementedException();
        // var bookModel = await bookRepo.UpdateAsync(id, bookDto);
        //
        // if (bookModel == null) {
        //     return NotFound();
        // }
        //
        // return Ok(bookModel);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) {
        var bookModel = await bookRepo.DeleteAsync(id);

        if (bookModel == null) {
            return NotFound();
        }
        
        return NoContent();
    }
}