using LibraryManagement.app.Domain.Entities;
using LibraryManagement.app.Domain.Repositories;
using LibraryManagement.app.Infrastructure.Persistence.Sql;
using LibraryManagement.app.Infrastructure.Persistence.Sql.Entities;

namespace LibraryManagement.app.Infrastructure.Persistence;

public class BookRepository(IBookDao dao) : IBookRepository
{
    public void Add(Book book)
    {
        var entity = BookEntity.Builder
            .withISBN(book.ISBN)
            .withTitle(book.Title)
            .withAuthorId(book.Author.Id)
            .build();

        dao.Add(entity);
    }

    public bool IsbnAlreadyExist(int bookIsbn)
    {
        return dao.IsbnAlreadyExist(bookIsbn);
    }
}