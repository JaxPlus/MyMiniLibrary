using Microsoft.AspNetCore.Mvc;
using MyMiniLibrary.Dtos.Series;
using MyMiniLibrary.Interfaces;
using MyMiniLibrary.Mappers;

namespace MyMiniLibrary.Controllers;

[Route("api/series")]
[ApiController]
public class SeriesController(ISeriesRepository seriesRepo) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var series = await seriesRepo.GetAllAsync();
        return Ok(series);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) {
        var seriesModel = await seriesRepo.GetByIdAsync(id);

        return seriesModel == null ? NotFound() : Ok(seriesModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSeriesRequestDto seriesDto) {
        var seriesModel = seriesDto.ToSeriesFromCreateDto();

        await seriesRepo.CreateAsync(seriesModel);
        return CreatedAtAction(nameof(Create), new { seriesId = seriesModel.SeriesId }, seriesModel);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSeriesRequestDto seriesDto) {
        var seriesModel = await seriesRepo.UpdateAsync(id, seriesDto);

        if (seriesModel == null) {
            return NotFound();
        }

        return Ok(seriesModel);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) {
        var seriesModel = await seriesRepo.DeleteAsync(id);

        if (seriesModel == null) {
            return NotFound();
        }
        
        return NoContent();
    }
}