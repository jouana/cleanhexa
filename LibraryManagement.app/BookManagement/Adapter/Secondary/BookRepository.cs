using LibraryManagement.app.BookManagement.Adapter.Secondary.Provider;
using LibraryManagement.app.BookManagement.Adapter.Secondary.Provider.Entity;

namespace LibraryManagement.app.BookManagement.Adapter.Secondary;

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