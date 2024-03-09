using Microsoft.AspNetCore.Mvc;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.PublishingHouse;
using MyMiniLibrary.Mappers;

namespace MyMiniLibrary.Controllers;

[Route("api/publishing-house")]
[ApiController]
public class PublishingHouseController(ApplicationDbContext context) : ControllerBase {
    [HttpGet]
    public IActionResult GetAll()
    {
        var publishingHouses = context.PublishingHouses.ToList();
        return Ok(publishingHouses);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var publishingHouseModel = context.PublishingHouses.Find(id);

        return publishingHouseModel == null ? NotFound() : Ok(publishingHouseModel);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreatePubHouseRequestDto pubHouseDto)
    {
        var publishingHouseModel = pubHouseDto.ToPublishingHouseFromCreateDto();
        context.Add(publishingHouseModel);
        context.SaveChanges();
        return CreatedAtAction(nameof(Create),
            new { publishingHouseId = publishingHouseModel.PublishingHouseId },
            publishingHouseModel);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdatePubHouseRequestDto publishingHouseDto) {
        var publishingHouseModel = context.PublishingHouses.FirstOrDefault(x => x.PublishingHouseId == id);

        if (publishingHouseModel == null) {
            return NotFound();
        }

        publishingHouseModel.Name = publishingHouseDto.Name;

        context.SaveChanges();
        return Ok(publishingHouseModel.ToPublishingHouseDto());
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id) {
        var publishingHouseModel = context.PublishingHouses.FirstOrDefault(x => x.PublishingHouseId == id);

        if (publishingHouseModel == null) {
            return NotFound();
        }

        context.PublishingHouses.Remove(publishingHouseModel);
        context.SaveChanges();
        return NoContent();
    }
}