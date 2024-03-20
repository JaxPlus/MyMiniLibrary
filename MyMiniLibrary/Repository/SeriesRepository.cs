using Microsoft.EntityFrameworkCore;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.Common;
using MyMiniLibrary.Interfaces;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Repository;

public class SeriesRepository(ApplicationDbContext context) : ISeriesRepository {
    public async Task<List<Series>> GetAllAsync() {
        return await context.Series.ToListAsync();
    }

    public async Task<Series?> GetByIdAsync(int id) {
        return await context.Series.FindAsync(id);
    }

    public async Task<Series> CreateAsync(Series seriesModel) {
        await context.Series.AddAsync(seriesModel);
        await context.SaveChangesAsync();
        return seriesModel;
    }

    public async Task<Series?> UpdateAsync(int id, CommonDto dto) {
        var seriesModel = await context.Series.FirstOrDefaultAsync(x =>
            x.SeriesId == id);

        if (seriesModel == null) {
            return null;
        }

        seriesModel.Name = dto.Name;

        await context.SaveChangesAsync();
        return seriesModel;
    }

    public async Task<Series?> DeleteAsync(int id) {
        var seriesModel = await context.Series.FirstOrDefaultAsync(x =>
            x.SeriesId == id);
        
        if (seriesModel == null) {
            return null;
        }
        
        context.Series.Remove(seriesModel);
        await context.SaveChangesAsync();

        return seriesModel;
    }

    public Task<bool> Exists(int id) {
        return context.Series.AnyAsync(s => s.SeriesId == id);
    }
}