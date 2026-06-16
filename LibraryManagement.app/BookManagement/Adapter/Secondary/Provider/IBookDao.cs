using LibraryManagement.app.BookManagement.Adapter.Secondary.Provider.Entity;

namespace LibraryManagement.app.BookManagement.Adapter.Secondary.Provider;

public interface IBookDao
{
    void Add(BookEntity book);
    bool IsbnAlreadyExist(int bookIsbn);
}