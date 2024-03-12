using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.PublishingHouse;
using MyMiniLibrary.Mappers;

namespace MyMiniLibrary.Controllers;

[Route("api/publishing-house")]
[ApiController]
public class PublishingHouseController(ApplicationDbContext context) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var publishingHouses = await context.PublishingHouses.ToListAsync();
        return Ok(publishingHouses);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var publishingHouseModel = await context.PublishingHouses.FindAsync(id);

        return publishingHouseModel == null ? NotFound() : Ok(publishingHouseModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePubHouseRequestDto pubHouseDto)
    {
        var publishingHouseModel = pubHouseDto.ToPublishingHouseFromCreateDto();
        await context.AddAsync(publishingHouseModel);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Create),
            new { publishingHouseId = publishingHouseModel.PublishingHouseId },
            publishingHouseModel);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePubHouseRequestDto publishingHouseDto) {
        var publishingHouseModel = await context.PublishingHouses.FirstOrDefaultAsync(x => x.PublishingHouseId == id);

        if (publishingHouseModel == null) {
            return NotFound();
        }

        publishingHouseModel.Name = publishingHouseDto.Name;

        await context.SaveChangesAsync();
        return Ok(publishingHouseModel.ToPublishingHouseDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) {
        var publishingHouseModel = await context.PublishingHouses.FirstOrDefaultAsync(x => x.PublishingHouseId == id);

        if (publishingHouseModel == null) {
            return NotFound();
        }

        context.PublishingHouses.Remove(publishingHouseModel);
        await context.SaveChangesAsync();
        return NoContent();
    }
}