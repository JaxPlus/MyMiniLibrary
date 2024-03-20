using MyMiniLibrary.Dtos.Series;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Mappers;

public static class SeriesMapper {
    public static SeriesDto ToSeriesDto(this Series seriesModel) {
        return new SeriesDto
        {
            SeriesId = seriesModel.SeriesId,
            Name = seriesModel.Name,
            Books = seriesModel.Books.Select(b => b.ToBookDto()).ToList()
        };
    }

    public static Series ToSeriesFromCreateDto(this CreateSeriesRequestDto seriesModelDto) {
        return new Series
        {
            Name = seriesModelDto.Name
        };
    }
}