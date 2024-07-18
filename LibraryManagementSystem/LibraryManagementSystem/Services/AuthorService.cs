using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Mappers;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            return authors.Select(a => a.ToDto()).ToList();
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);
            return author?.ToDto();
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var author = new Author
            {
                Name = createAuthorDto.Name
            };
            var createdAuthor = await _authorRepository.CreateAuthorAsync(author);
            return createdAuthor.ToDto();
        }

        public async Task UpdateAuthorAsync(AuthorDto authorDto)
        {
            var author = authorDto.ToEntity();
            await _authorRepository.UpdateAuthorAsync(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _authorRepository.DeleteAuthorAsync(id);
        }
    }
}
