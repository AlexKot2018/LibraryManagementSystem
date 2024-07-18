namespace LibraryManagementSystem.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}