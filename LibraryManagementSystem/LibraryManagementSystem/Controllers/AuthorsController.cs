using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Dtos;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Добавление нового автора.
        /// </summary>
        /// <param name="authorDto">Параметры для создания автора</param>
        /// <returns>Созданный автор</returns>
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var createdAuthor = await _authorService.CreateAuthorAsync(createAuthorDto);
            return CreatedAtAction(nameof(GetAuthorById), new { id = createdAuthor.Id }, createdAuthor);
        }

        /// <summary>
        /// Получение всех авторов.
        /// </summary>
        /// <returns>Список авторов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }


        /// <summary>
        /// Получение информации о конкретном авторе.
        /// </summary>
        /// <param name="id">ID автора</param>
        /// <returns>Информация о конкретном авторе</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        /// <summary>
        /// Обновление информации о существующем авторе.
        /// </summary>
        /// <param name="id">ID автора</param>
        /// <param name="authorDto">"Параметры для обновления"</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, AuthorDto authorDto)
        {
            if (id != authorDto.Id)
            {
                return BadRequest();
            }
            await _authorService.UpdateAuthorAsync(authorDto);
            return NoContent();
        }

        /// <summary>
        /// Удаление автора.
        /// </summary>
        /// <param name="id">ID автора</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}