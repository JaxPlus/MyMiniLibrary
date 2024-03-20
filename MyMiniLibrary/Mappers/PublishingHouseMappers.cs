using MyMiniLibrary.Dtos.PublishingHouse;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Mappers;

public static class PublishingHouseMappers {
    public static PublishingHouseDto ToPublishingHouseDto(this PublishingHouse pubHouseModel) {
        return new PublishingHouseDto
        {
            PublishingHouseId = pubHouseModel.PublishingHouseId,
            Name = pubHouseModel.Name,
            Books = pubHouseModel.Books.Select(b => b.ToBookDto()).ToList(),
        };
    }

    public static PublishingHouse ToPublishingHouseFromCreateDto(this CreatePubHouseRequestDto pubHouseModel) {
        return new PublishingHouse
        {
            Name = pubHouseModel.Name
        };
    }
}