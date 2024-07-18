using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Dtos;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Добавление новой книги.
        /// </summary>
        /// <param name="bookDto">Данные для добавления</param>
        /// <returns>Информация о добавленной книге</returns>
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto bookDto)
        {
            var createdBook = await _bookService.CreateBookAsync(bookDto);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
        }

        /// <summary>
        /// Получение списка всех книг.
        /// </summary>
        /// <returns>Список книг</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        /// <summary>
        /// Получение информации о конкретной книге.
        /// </summary>
        /// <param name="id">ID книги</param>
        /// <returns>Информация о конкретной книге</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        /// <summary>
        /// Обновление существующей книги.
        /// </summary>
        /// <param name="id">ID книги</param>
        /// <param name="bookDto">Данные для обновления книги</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest();
            }
            await _bookService.UpdateBookAsync(bookDto);
            return NoContent();
        }

        /// <summary>
        /// Удаление книги.
        /// </summary>
        /// <param name="id">ID книги</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}