using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IReaderRepository
    {
        Task<IEnumerable<Reader>> GetAllReadersAsync();
        Task<Reader> GetReaderByIdAsync(int id);
        Task<Reader> CreateReaderAsync(Reader reader);
        Task UpdateReaderAsync(Reader reader);
        Task DeleteReaderAsync(int id);
    }
}