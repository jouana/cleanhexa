using LibraryManagement.app.BookManagement.Adapter.Secondary.Provider;
using LibraryManagement.app.BookManagement.Domain.Ports.Secondary;

namespace LibraryManagement.app.BookManagement.Adapter.Secondary;

public class AuthorRepository(IAuthorDao authorDao) : IAuthorRepository
{
    public Author FindOneById(int commandAuthorId)
    {
        var author = authorDao.FindOneById(commandAuthorId);

        return Author.builder
            .withId(author.Id)
            .build();
    }
}