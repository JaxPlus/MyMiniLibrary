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
        return bookModel == null ? NotFound() : Ok(bookModel.ToBookDto());
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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookRequestDto bookDto) {
        if (!await authorRepo.Exists(bookDto.AuthorId)) {
            return BadRequest("Author does not exists");
        }

        if (!await seriesRepo.Exists(bookDto.SeriesId)) {
            return BadRequest("Series does not exists");
        }

        if (!await publishingHouseRepo.Exists(bookDto.PublishingHouseId)) {
            return BadRequest("Publishing House does not exists");
        }
        
        var bookModel = bookDto.ToBookFromCreate();
        
        await bookRepo.CreateAsync(bookModel);
        return CreatedAtAction(nameof(Create), new
        {
            authorId = bookModel.AuthorId,
            seriesId = bookModel.SeriesId,
            publishingHouseId = bookModel.PublishingHouseId
        }, bookModel.ToCreateBookDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookRequestDto bookDto) {
        var bookModel = await bookRepo.UpdateAsync(id, bookDto);

        if (bookModel == null) {
            return NotFound("Book does not exists");
        }

        return Ok(bookModel);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) {
        var bookModel = await bookRepo.DeleteAsync(id);

        if (bookModel == null) {
            return NotFound("Book does not exists");
        }
        
        return NoContent();
    }
}