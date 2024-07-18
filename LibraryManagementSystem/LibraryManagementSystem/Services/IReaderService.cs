using LibraryManagementSystem.Dtos;

namespace LibraryManagementSystem.Services
{
    public interface IReaderService
    {
        Task<IEnumerable<ReaderDto>> GetAllReadersAsync();
        Task<ReaderDto> GetReaderByIdAsync(int id);
        Task<ReaderDto> CreateReaderAsync(CreateReaderDto readerDto);
        Task UpdateReaderAsync(ReaderDto readerDto);
        Task DeleteReaderAsync(int id);
    }
}
