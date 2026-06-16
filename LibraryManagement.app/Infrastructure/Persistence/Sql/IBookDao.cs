using LibraryManagement.app.Infrastructure.Persistence.Sql.Entities;

namespace LibraryManagement.app.Infrastructure.Persistence.Sql;

public interface IBookDao
{
    void Add(BookEntity book);
    bool IsbnAlreadyExist(int bookIsbn);
}