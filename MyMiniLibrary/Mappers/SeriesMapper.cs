using MyMiniLibrary.Dtos.Series;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Mappers;

public static class SeriesMapper {
    public static Series ToSeriesDto(this Series seriesModel) {
        return new Series
        {
            SeriesId = seriesModel.SeriesId,
            Name = seriesModel.Name
        };
    }

    public static Series ToSeriesFromCreateDto(this CreateSeriesRequestDto seriesModelDto) {
        return new Series
        {
            Name = seriesModelDto.Name
        };
    }
}