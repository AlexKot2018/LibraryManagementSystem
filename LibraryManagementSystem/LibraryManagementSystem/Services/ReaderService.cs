using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Mappers;


namespace LibraryManagementSystem.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public async Task<IEnumerable<ReaderDto>> GetAllReadersAsync()
        {
            var readers = await _readerRepository.GetAllReadersAsync();
            return readers.Select(r => r.ToDto()).ToList();
        }

        public async Task<ReaderDto> GetReaderByIdAsync(int id)
        {
            var reader = await _readerRepository.GetReaderByIdAsync(id);
            return reader?.ToDto();
        }

        public async Task<ReaderDto> CreateReaderAsync(CreateReaderDto readerDto)
        {
            var reader = new Models.Reader
            {
                Name = readerDto.Name
            };
            var createdReader = await _readerRepository.CreateReaderAsync(reader);
            return createdReader.ToDto();
        }

        public async Task UpdateReaderAsync(ReaderDto readerDto)
        {
            var reader = readerDto.ToEntity();
            await _readerRepository.UpdateReaderAsync(reader);
        }

        public async Task DeleteReaderAsync(int id)
        {
            await _readerRepository.DeleteReaderAsync(id);
        }
    }
}
