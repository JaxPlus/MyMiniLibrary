using MyMiniLibrary.Dtos.PublishingHouse;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Mappers;

public static class PublishingHouseMappers {
    public static PublishingHouse ToPublishingHouseDto(this PublishingHouse pubHouseModel) {
        return new PublishingHouse
        {
            PublishingHouseId = pubHouseModel.PublishingHouseId,
            Name = pubHouseModel.Name
        };
    }

    public static PublishingHouse ToPublishingHouseFromCreateDto(this CreatePubHouseRequestDto pubHouseModel) {
        return new PublishingHouse
        {
            Name = pubHouseModel.Name
        };
    }
}