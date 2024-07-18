using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryContext _context;

        public ReaderRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reader>> GetAllReadersAsync()
        {
            return await _context.Readers.ToListAsync();
        }

        public async Task<Reader> GetReaderByIdAsync(int id)
        {
            return await _context.Readers.FindAsync(id);
        }

        public async Task<Reader> CreateReaderAsync(Reader reader)
        {
            _context.Readers.Add(reader);
            await _context.SaveChangesAsync();
            return reader;
        }

        public async Task UpdateReaderAsync(Reader reader)
        {
            _context.Entry(reader).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReaderAsync(int id)
        {
            var reader = await _context.Readers.FindAsync(id);
            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();
        }
    }
}