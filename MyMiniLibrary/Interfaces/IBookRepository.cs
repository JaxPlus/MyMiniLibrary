using MyMiniLibrary.Models;

namespace MyMiniLibrary.Interfaces;

public interface IBookRepository : ICommonRepository<Book> {
    public Task<double> SumOfAsync();
    public Task<int>    CountAsync();
};