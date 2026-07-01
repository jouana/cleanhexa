namespace LibraryManagement.app.Domain.Entities;

public class Library
{
    private readonly Rows _rows;

    public Library(Rows rows)
    {
        _rows = rows;
    }

    public void PutBookAway(int rowIndex, int shelfIndex, Book book)
    {
        _rows.PlaceBook(rowIndex, shelfIndex, book);
    }
}