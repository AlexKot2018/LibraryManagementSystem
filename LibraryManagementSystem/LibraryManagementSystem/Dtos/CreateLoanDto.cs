namespace LibraryManagementSystem.Dtos
{
    public class CreateLoanDto
    {
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
