using LibraryManagement.app.Application.Queries;
using LibraryManagement.app.Infrastructure.Persistence;

namespace LibraryManagement.app.Application.Handlers;

public class GetBookByISBNQueryHandler(LibraryDbContext db) : IQueryHandler<GetBookByISBNQuery, BookReadModel?>
{
    public BookReadModel? Handle(GetBookByISBNQuery query)
    {
        return db.Books
            .Where(b => b.ISBN == query.ISBN)
            .Select(b => new BookReadModel(b.ISBN, b.Title, b.AuthorId))
            .FirstOrDefault();
    }
}
