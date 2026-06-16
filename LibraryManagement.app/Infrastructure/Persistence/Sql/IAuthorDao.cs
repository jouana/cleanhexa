using LibraryManagement.app.Infrastructure.Persistence.Sql.Entities;

namespace LibraryManagement.app.Infrastructure.Persistence.Sql;

public interface IAuthorDao
{
    AuthorEntity FindOneById(int authorId);
}