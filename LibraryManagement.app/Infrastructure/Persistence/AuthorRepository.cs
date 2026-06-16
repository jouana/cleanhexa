using LibraryManagement.app.Domain.Entities;
using LibraryManagement.app.Domain.Repositories;
using LibraryManagement.app.Infrastructure.Persistence.Sql;

namespace LibraryManagement.app.Infrastructure.Persistence;

public class AuthorRepository(IAuthorDao authorDao) : IAuthorRepository
{
    public Author FindOneById(int authorId)
    {
        var author = authorDao.FindOneById(authorId);

        return Author.builder
            .withId(author.Id)
            .build();
    }
}