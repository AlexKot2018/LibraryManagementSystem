using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Mappers;
using LibraryManagementSystem.Models; 

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return books.Select(b => b.ToDto()).ToList();
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return book?.ToDto();
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                ISBN = bookDto.ISBN,
                AuthorId = bookDto.AuthorId
            }; 
            var createdBook = await _bookRepository.CreateBookAsync(book);
            return createdBook.ToDto();
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var book = bookDto.ToEntity();
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }
    }
}
