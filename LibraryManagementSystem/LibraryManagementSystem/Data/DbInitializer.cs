using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return; 
            }

            var authors = new Author[]
            {
                new Author { Name = "Author1" },
                new Author { Name = "Author2" }
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();

            var books = new Book[]
            {
                new Book { Title = "Book1", ISBN = "123", AuthorId = authors[0].Id },
                new Book { Title = "Book2", ISBN = "456", AuthorId = authors[1].Id }
            };

            context.Books.AddRange(books);
            context.SaveChanges();

            var readers = new Reader[]
            {
                new Reader { Name = "Reader1" },
                new Reader { Name = "Reader2" }
            };

            context.Readers.AddRange(readers);
            context.SaveChanges();

            var loans = new Loan[]
            {
                new Loan { BookId = books[0].Id, ReaderId = readers[0].Id, LoanDate = DateTime.Now },
                new Loan { BookId = books[1].Id, ReaderId = readers[1].Id, LoanDate = DateTime.Now }
            };

            context.Loans.AddRange(loans);
            context.SaveChanges();
        }
    }
}