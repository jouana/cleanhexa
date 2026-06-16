using LibraryManagement.app.BookManagement.Domain.Ports.Primary;
using LibraryManagement.app.BookManagement.Domain.Ports.Primary.Command;
using LibraryManagement.app.BookManagement.Domain.Ports.Secondary;

namespace LibraryManagement.app;

public class BookService(IBookRepository bookRepository, IAuthorRepository authorRepository) : IBookService
{
    public void RegisterBook(BookCreateCommand command)
    {
        Book book = Book.Builder()
            .withISBN(command.ISBN)
            .withTitle(command.Title)
            .build();
        
        Author author = authorRepository.FindOneById(command.AuthorId);
        
        book.AssignAuthor(author);
        
        if (bookRepository.IsbnAlreadyExist(command.ISBN))
        {
            throw new Exception("ISBN already exist");
        }
        
        bookRepository.Add(book);
    }
}