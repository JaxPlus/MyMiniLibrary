using MyMiniLibrary.Dtos.Common;

namespace MyMiniLibrary.Interfaces;

public interface ICommonRepository<T> {
    Task<List<T>> GetAllAsync();
    Task<T?>      GetByIdAsync(int id);
    Task<T>       CreateAsync(T model);
    Task<T?>      UpdateAsync(int id, CommonDto dto);
    Task<T?>      DeleteAsync(int id);
    Task<bool>    Exists(int id);
}