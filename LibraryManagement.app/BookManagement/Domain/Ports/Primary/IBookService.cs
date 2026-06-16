using LibraryManagement.app.BookManagement.Domain.Ports.Primary.Command;

namespace LibraryManagement.app.BookManagement.Domain.Ports.Primary;

public interface IBookService
{
    void RegisterBook(BookCreateCommand book);
}