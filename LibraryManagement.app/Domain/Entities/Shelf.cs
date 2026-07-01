namespace LibraryManagement.app.Domain.Entities;

public class Shelf
{
    private Book? _book;

    public bool IsEmpty => _book is null;

    public void PlaceBook(Book book)
    {
        if (!IsEmpty)
            throw new InvalidOperationException("Shelf is already occupied.");
        _book = book;
    }
}