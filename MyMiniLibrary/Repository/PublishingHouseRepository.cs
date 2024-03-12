using Microsoft.EntityFrameworkCore;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.Common;
using MyMiniLibrary.Interfaces;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Repository;

public class PublishingHouseRepository(ApplicationDbContext context) : IPublishingHouseRepository {
    public async Task<List<PublishingHouse>> GetAllAsync() {
        return await context.PublishingHouses.ToListAsync();
    }

    public async Task<PublishingHouse?> GetByIdAsync(int id) {
        return await context.PublishingHouses.FindAsync(id);
    }

    public async Task<PublishingHouse> CreateAsync(PublishingHouse publishingHouseModel) {
        await context.PublishingHouses.AddAsync(publishingHouseModel);
        await context.SaveChangesAsync();
        return publishingHouseModel;
    }

    public async Task<PublishingHouse?> UpdateAsync(int id, CommonDto dto) {
        var publishingHouseModel = await context.PublishingHouses.FirstOrDefaultAsync(x =>
            x.PublishingHouseId == id);

        if (publishingHouseModel == null) {
            return null;
        }

        publishingHouseModel.Name = dto.Name;

        await context.SaveChangesAsync();
        return publishingHouseModel;
    }

    public async Task<PublishingHouse?> DeleteAsync(int id) {
        var publishingHouseModel = await context.PublishingHouses.FirstOrDefaultAsync(x =>
            x.PublishingHouseId == id);
        
        if (publishingHouseModel == null) {
            return null;
        }
        
        context.PublishingHouses.Remove(publishingHouseModel);
        await context.SaveChangesAsync();

        return publishingHouseModel;
    }
}