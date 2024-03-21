using Microsoft.AspNetCore.Mvc;
using MyMiniLibrary.Dtos.Book;
using MyMiniLibrary.Interfaces;
using MyMiniLibrary.Mappers;

namespace MyMiniLibrary.Controllers;

[Route("api/book")]
[ApiController]
public class BookController(IBookRepository bookRepo,
            IAuthorRepository authorRepo,
            ISeriesRepository seriesRepo,
            IPublishingHouseRepository publishingHouseRepo)
        : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var books = await bookRepo.GetAllAsync();
        return Ok(books.Select(b => b.ToBookDto()).ToList());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) {
        var bookModel = await bookRepo.GetByIdAsync(id);
        return bookModel == null ? NotFound() : Ok(bookModel);
    }

    [HttpGet("/stats")]
    public IActionResult GetStatisticData() {
        var statisticsData = new StatisticsDataDto
        {
            SumOfPrice = bookRepo.SumOfAsync().Result,
            BookCount = bookRepo.CountAsync().Result
        };
        
        return Ok(statisticsData);
    }

    [HttpPost("{authorId:int}/{seriesId:int}/{publishingHouseId:int}")]
    public async Task<IActionResult> Create([FromRoute] int authorId,
        [FromRoute] int seriesId,
        [FromRoute] int publishingHouseId,
        [FromBody] CreateBookRequestDto bookDto) {
        if (!await authorRepo.Exists(authorId)) {
            return BadRequest("Author does not exists");
        }

        if (!await seriesRepo.Exists(seriesId)) {
            return BadRequest("Series does not exists");
        }

        if (!await publishingHouseRepo.Exists(publishingHouseId)) {
            return BadRequest("Publishing House does not exists");
        }
        
        var bookModel = bookDto.ToBookFromCreate(authorId, seriesId, publishingHouseId);
        
        await bookRepo.CreateAsync(bookModel);
        return CreatedAtAction(nameof(Create), new { bookId = bookModel.BookId }, bookModel.ToBookDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookRequestDto bookDto) {
        throw new NotImplementedException();
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