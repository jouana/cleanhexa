using LibraryManagement.app.Infrastructure.Persistence.Sql.Entities;

namespace LibraryManagement.app.Infrastructure.Persistence.Sql;

public class BookDAOSQL : IBookDao
{
    public void Add(BookEntity book)
    {
        throw new NotImplementedException();
    }

    public bool IsbnAlreadyExist(int bookIsbn)
    {
        throw new NotImplementedException();
    }

    public BookEntity? FindByIsbn(int isbn)
    {
        throw new NotImplementedException();
    }
}