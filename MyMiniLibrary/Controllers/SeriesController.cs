using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.Series;
using MyMiniLibrary.Mappers;

namespace MyMiniLibrary.Controllers;

[Route("api/series")]
[ApiController]
public class SeriesController(ApplicationDbContext context) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var series = await context.Series.ToListAsync();
        return Ok(series);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var seriesModel = await context.Series.FindAsync(id);

        return seriesModel == null ? NotFound() : Ok(seriesModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSeriesRequestDto seriesDto)
    {
        var seriesModel = seriesDto.ToSeriesFromCreateDto();
        await context.AddAsync(seriesModel);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Create), new { seriesId = seriesModel.SeriesId }, seriesModel);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSeriesRequestDto seriesDto) {
        var seriesModel = await context.Series.FirstOrDefaultAsync(x => x.SeriesId == id);

        if (seriesModel == null) {
            return NotFound();
        }

        seriesModel.Name = seriesDto.Name;

        await context.SaveChangesAsync();
        return Ok(seriesModel.ToSeriesDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) {
        var seriesModel = await context.Series.FirstOrDefaultAsync(x => x.SeriesId == id);

        if (seriesModel == null) {
            return NotFound();
        }

        context.Series.Remove(seriesModel);
        await context.SaveChangesAsync();
        return NoContent();
    }
}