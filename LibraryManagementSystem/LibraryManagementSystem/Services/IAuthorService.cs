using LibraryManagementSystem.Dtos;

namespace LibraryManagementSystem.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto> GetAuthorByIdAsync(int id);
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto); 
        Task UpdateAuthorAsync(AuthorDto authorDto);
        Task DeleteAuthorAsync(int id);
    }
}
