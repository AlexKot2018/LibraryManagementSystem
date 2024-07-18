using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Dtos;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        /// <summary>
        /// Выдача книги читателю
        /// </summary>
        /// <param name="loanDto">Данные о выдаче</param>
        /// <returns>Информация о новой выдаче книги</returns>
        [HttpPost]
        public async Task<ActionResult<LoanDto>> CreateLoan(CreateLoanDto loanDto)
        {
            var createdLoan = await _loanService.CreateLoanAsync(loanDto);
            return CreatedAtAction(nameof(GetLoanById), new { id = createdLoan.Id }, createdLoan);
        }

        /// <summary>
        /// Получение списка всех выдач.
        /// </summary>
        /// <returns>Список выдач</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetLoans()
        {
            var loans = await _loanService.GetAllLoansAsync();
            return Ok(loans);
        }

        /// <summary>
        /// Получение информации о конкретной выдаче.
        /// </summary>
        /// <param name="id">ID выдачи</param>
        /// <returns>Информация о выдаче книги</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDto>> GetLoanById(int id)
        {
            var loan = await _loanService.GetLoanByIdAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        /// <summary>
        /// Возврат книги.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            await _loanService.DeleteLoanAsync(id);
            return NoContent();
        }
    }
}