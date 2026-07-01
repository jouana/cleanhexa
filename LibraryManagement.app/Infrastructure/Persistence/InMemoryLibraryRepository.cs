using LibraryManagement.app.Domain.Entities;
using LibraryManagement.app.Domain.Repositories;

namespace LibraryManagement.app.Infrastructure.Persistence;

public class InMemoryLibraryRepository : ILibraryRepository
{
    private Library _library = new Library(new Rows(5, 10));

    public Library FindOne() => _library;

    public void Update(Library library) => _library = library;
}