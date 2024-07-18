using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Dtos;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly IReaderService _readerService;

        public ReadersController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        /// <summary>
        /// Регистрация нового читателя.
        /// </summary>
        /// <param name="readerDto">Данные для регистрации</param>
        /// <returns>Зарегистрированный читатель</returns>
        [HttpPost]
        public async Task<ActionResult<ReaderDto>> CreateReader(CreateReaderDto readerDto)
        {
            var createdReader = await _readerService.CreateReaderAsync(readerDto);
            return CreatedAtAction(nameof(GetReaderById), new { id = createdReader.Id }, createdReader);
        }

        /// <summary>
        /// Получение списка всех читателей.
        /// </summary>
        /// <returns>Список читателей</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReaderDto>>> GetReaders()
        {
            var readers = await _readerService.GetAllReadersAsync();
            return Ok(readers);
        }

        /// <summary>
        /// Получение информации о конкретном читателе.
        /// </summary>
        /// <param name="id">ID читателя</param>
        /// <returns>Информация о конкретном читателе</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReaderDto>> GetReaderById(int id)
        {
            var reader = await _readerService.GetReaderByIdAsync(id);
            if (reader == null)
            {
                return NotFound();
            }
            return Ok(reader);
        }

        /// <summary>
        /// Обновление существующего читателя.
        /// </summary>
        /// <param name="id">ID читателя</param>
        /// <param name="readerDto">Данные для обновления читателя</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReader(int id, ReaderDto readerDto)
        {
            if (id != readerDto.Id)
            {
                return BadRequest();
            }
            await _readerService.UpdateReaderAsync(readerDto);
            return NoContent();
        }

        /// <summary>
        /// Удаление читателя.
        /// </summary>
        /// <param name="id">ID читателя</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReader(int id)
        {
            await _readerService.DeleteReaderAsync(id);
            return NoContent();
        }
    }
}
