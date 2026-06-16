namespace LibraryManagement.app;

public interface IBookRepository
{
    void Add(Book book);
    bool IsbnAlreadyExist(int bookIsbn);
}