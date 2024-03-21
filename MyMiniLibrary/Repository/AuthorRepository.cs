using Microsoft.EntityFrameworkCore;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.Common;
using MyMiniLibrary.Interfaces;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Repository;

public class AuthorRepository(ApplicationDbContext context) : IAuthorRepository {
    public async Task<List<Author>> GetAllAsync() {
        return await context.Authors.ToListAsync();
    }

    public async Task<Author?> GetByIdAsync(int id) {
        return await context.Authors.FindAsync(id);
    }

    public async Task<Author?> UpdateAsync(int id, CommonDto dto) {
        var authorModel = await context.Authors.FirstOrDefaultAsync(a => a.AuthorId == id);

        if (authorModel == null) {
            return null;
        }

        authorModel.Name = dto.Name;

        await context.SaveChangesAsync();
        return authorModel;
    }

    public async Task<Author> CreateAsync(Author authorModel) {
        await context.Authors.AddAsync(authorModel);
        await context.SaveChangesAsync();
        return authorModel;
    }

    public async Task<Author?> DeleteAsync(int id) {
        var authorModel = await context.Authors.FirstOrDefaultAsync(a => a.AuthorId == id);
        
        if (authorModel == null) {
            return null;
        }
        
        context.Authors.Remove(authorModel);
        await context.SaveChangesAsync();

        return authorModel;
    }

    public Task<bool> Exists(int id) {
        return context.Authors.AnyAsync(a => a.AuthorId == id);
    }
}