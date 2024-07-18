using LibraryManagementSystem.Dtos;

namespace LibraryManagementSystem.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanDto>> GetAllLoansAsync();
        Task<LoanDto> GetLoanByIdAsync(int id);
        Task<LoanDto> CreateLoanAsync(CreateLoanDto loanDto); 
        Task UpdateLoanAsync(LoanDto loanDto);
        Task DeleteLoanAsync(int id);
    }
}
