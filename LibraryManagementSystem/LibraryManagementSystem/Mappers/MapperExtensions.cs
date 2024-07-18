using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Mappers
{
    public static class MapperExtensions
    {
        public static AuthorDto ToDto(this Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public static Author ToEntity(this AuthorDto authorDto)
        {
            return new Author
            {
                Id = authorDto.Id,
                Name = authorDto.Name
            };
        }

        public static BookDto ToDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                AuthorId = book.AuthorId,
            };
        }

        public static Book ToEntity(this BookDto bookDto)
        {
            return new Book
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId,
            };
        }

        public static ReaderDto ToDto(this Reader reader)
        {
            return new ReaderDto
            {
                Id = reader.Id,
                Name = reader.Name,
            };
        }

        public static Reader ToEntity(this ReaderDto readerDto)
        {
            return new Reader
            {
                Id = readerDto.Id,
                Name = readerDto.Name,
            };
        }

        public static LoanDto ToDto(this Loan loan)
        {
            return new LoanDto
            {
                Id = loan.Id,
                BookId = loan.BookId,
                ReaderId = loan.ReaderId,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate,
            };
        }

        public static Loan ToEntity(this LoanDto loanDto)
        {
            return new Loan
            {
                Id = loanDto.Id,
                BookId = loanDto.BookId,
                ReaderId = loanDto.ReaderId,
                LoanDate = loanDto.LoanDate,
                ReturnDate = loanDto.ReturnDate,
            };
        }
    }
}
