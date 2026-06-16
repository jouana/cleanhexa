using LibraryManagement.app.BookManagement.Adapter.Secondary.Provider.Entity;

namespace LibraryManagement.app.BookManagement.Adapter.Secondary.Provider;

public interface IAuthorDao
{
    AuthorEntity FindOneById(int commandAuthorId);
}