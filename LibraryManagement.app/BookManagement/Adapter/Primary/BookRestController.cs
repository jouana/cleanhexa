using System.Security.Cryptography;
using LibraryManagement.app.BookManagement.Adapter.Primary.Resource;
using LibraryManagement.app.BookManagement.Domain.Ports.Primary;
using LibraryManagement.app.BookManagement.Domain.Ports.Primary.Command;

namespace LibraryManagement.app.BookManagement.Adapter.Primary;

public class BookRestController(IBookService bookService)
{
    public void Create(BookResource resource)
    {
        BookCreateCommand command = BookCreateCommand.Builder
            .withISBN(resource.ISBN)
            .withTitle(resource.Title)
            .withAuthorId(resource.AuthorId)
            .build();
        
        bookService.RegisterBook(command);
    }
}