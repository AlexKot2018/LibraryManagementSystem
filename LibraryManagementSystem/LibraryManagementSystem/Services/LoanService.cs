using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Mappers;
using LibraryManagementSystem.Models; 


namespace LibraryManagementSystem.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<IEnumerable<LoanDto>> GetAllLoansAsync()
        {
            var loans = await _loanRepository.GetAllLoansAsync();
            return loans.Select(l => l.ToDto()).ToList();
        }

        public async Task<LoanDto> GetLoanByIdAsync(int id)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(id);
            return loan?.ToDto();
        }

        public async Task<LoanDto> CreateLoanAsync(CreateLoanDto loanDto)
        {
            var loan = new Loan
            {
                BookId = loanDto.BookId,
                ReaderId = loanDto.ReaderId,
                LoanDate = loanDto.LoanDate,
                ReturnDate = loanDto.ReturnDate
            }; 
            var createdLoan = await _loanRepository.CreateLoanAsync(loan);
            return createdLoan.ToDto();
        }

        public async Task UpdateLoanAsync(LoanDto loanDto)
        {
            var loan = loanDto.ToEntity();
            await _loanRepository.UpdateLoanAsync(loan);
        }

        public async Task DeleteLoanAsync(int id)
        {
            await _loanRepository.DeleteLoanAsync(id);
        }
    }
}
