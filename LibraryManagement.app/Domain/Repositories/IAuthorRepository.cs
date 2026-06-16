using LibraryManagement.app.Domain.Entities;

namespace LibraryManagement.app.Domain.Repositories;

public interface IAuthorRepository
{
    Author FindOneById(int authorId);
}