using LibraryManagement.app.Domain.Entities;

namespace LibraryManagement.app.Domain.Repositories;

public interface ILibraryRepository
{
    Library FindOne();
    void Update(Library library);
}