using LibraryManagement.app.Domain.Entities;

namespace LibraryManagement.app.Domain.Repositories;

public interface IBookRepository
{
    void Add(Book book);
    bool IsbnAlreadyExist(int bookIsbn);
}