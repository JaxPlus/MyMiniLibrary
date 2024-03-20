using Microsoft.EntityFrameworkCore;
using MyMiniLibrary.Data;
using MyMiniLibrary.Dtos.Common;
using MyMiniLibrary.Interfaces;
using MyMiniLibrary.Models;

namespace MyMiniLibrary.Repository;

public class BookRepository(ApplicationDbContext context) : IBookRepository {
    public async Task<List<Book>> GetAllAsync() {
        return await context.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id) {
        return await context.Books.FindAsync(id);
    }

    public async Task<Book> CreateAsync(Book bookModel) {
        await context.Books.AddAsync(bookModel);
        await context.SaveChangesAsync();
        return bookModel;
    }

    public async Task<Book?> UpdateAsync(int id, CommonDto dto) {
        var bookModel = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);

        if (bookModel == null) {
            return null;
        }

        bookModel.Name = dto.Name;

        await context.SaveChangesAsync();
        return bookModel;
    }

    public async Task<Book?> DeleteAsync(int id) {
        var bookModel = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
        
        if (bookModel == null) {
            return null;
        }
        
        context.Books.Remove(bookModel);
        await context.SaveChangesAsync();

        return bookModel;
    }

    public Task<bool> Exists(int id) {
        return context.Books.AnyAsync(b => b.BookId == id);
    }
}