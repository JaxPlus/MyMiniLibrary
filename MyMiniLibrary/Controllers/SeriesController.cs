using Microsoft.AspNetCore.Mvc;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.Series;
using MyMiniLibrary.Mappers;

namespace MyMiniLibrary.Controllers;

[Route("api/series")]
[ApiController]
public class SeriesController(ApplicationDbContext context) : ControllerBase {
    [HttpGet]
    public IActionResult GetAll()
    {
        var series = context.Series.ToList();
        return Ok(series);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var seriesModel = context.Series.Find(id);

        return seriesModel == null ? NotFound() : Ok(seriesModel);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateSeriesRequestDto seriesDto)
    {
        var seriesModel = seriesDto.ToSeriesFromCreateDto();
        context.Add(seriesModel);
        context.SaveChanges();
        return CreatedAtAction(nameof(Create), new { seriesId = seriesModel.SeriesId }, seriesModel);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateSeriesRequestDto seriesDto) {
        var seriesModel = context.Series.FirstOrDefault(x => x.SeriesId == id);

        if (seriesModel == null) {
            return NotFound();
        }

        seriesModel.Name = seriesDto.Name;

        context.SaveChanges();
        return Ok(seriesModel.ToSeriesDto());
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id) {
        var seriesModel = context.Series.FirstOrDefault(x => x.SeriesId == id);

        if (seriesModel == null) {
            return NotFound();
        }

        context.Series.Remove(seriesModel);
        context.SaveChanges();
        return NoContent();
    }
}