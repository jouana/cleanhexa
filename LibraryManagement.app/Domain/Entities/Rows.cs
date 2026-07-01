namespace LibraryManagement.app.Domain.Entities;

public class Rows
{
    private readonly IList<Row> _rows;

    public Rows(int rowCount, int shelvesPerRow)
    {
        _rows = Enumerable.Range(0, rowCount).Select(_ => new Row(shelvesPerRow)).ToList();
    }

    public void PlaceBook(int rowIndex, int shelfIndex, Book book)
    {
        if (rowIndex < 0 || rowIndex >= _rows.Count)
            throw new ArgumentOutOfRangeException(nameof(rowIndex), "Invalid row index.");
        _rows[rowIndex].PlaceBook(shelfIndex, book);
    }
}