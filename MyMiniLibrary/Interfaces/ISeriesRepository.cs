using MyMiniLibrary.Models;

namespace MyMiniLibrary.Interfaces;

public interface ISeriesRepository : ICommonRepository<Series> {
    public Task<int>    CountAsync();
};