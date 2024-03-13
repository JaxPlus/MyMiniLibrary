using Microsoft.AspNetCore.Mvc;
using MyMiniLibrary.Dtos.PublishingHouse;
using MyMiniLibrary.Interfaces;
using MyMiniLibrary.Mappers;

namespace MyMiniLibrary.Controllers;

[Route("api/publishing-house")]
[ApiController]
public class PublishingHouseController(IPublishingHouseRepository pubHouseRepo) : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var publishingHouses = await pubHouseRepo.GetAllAsync();
        return Ok(publishingHouses);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) {
        var publishingHouseModel = await pubHouseRepo.GetByIdAsync(id);

        return publishingHouseModel == null ? NotFound() : Ok(publishingHouseModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePubHouseRequestDto pubHouseDto) {
        var publishingHouseModel = pubHouseDto.ToPublishingHouseFromCreateDto();

        await pubHouseRepo.CreateAsync(publishingHouseModel);
        return CreatedAtAction(nameof(Create),
            new { publishingHouseId = publishingHouseModel.PublishingHouseId },
            publishingHouseModel);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePubHouseRequestDto publishingHouseDto) {
        var publishingHouseModel = await pubHouseRepo.UpdateAsync(id, publishingHouseDto);

        if (publishingHouseModel == null) {
            return NotFound();
        }

        return Ok(publishingHouseModel);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) {
        var publishingHouseModel = await pubHouseRepo.DeleteAsync(id);

        if (publishingHouseModel == null) {
            return NotFound();
        }
        
        return NoContent();
    }
}