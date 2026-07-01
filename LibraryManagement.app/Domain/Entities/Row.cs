namespace LibraryManagement.app.Domain.Entities;

public class Row
{
    private readonly Shelves _shelves;

    public Row(int shelvesCount)
    {
        _shelves = new Shelves(shelvesCount);
    }

    public void PlaceBook(int shelfIndex, Book book)
    {
        _shelves.PlaceBook(shelfIndex, book);
    }
}
