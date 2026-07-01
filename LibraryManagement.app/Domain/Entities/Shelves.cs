namespace LibraryManagement.app.Domain.Entities;

public class Shelves
{
    private readonly IList<Shelf> _shelves;

    public Shelves(int count)
    {
        _shelves = Enumerable.Range(0, count).Select(_ => new Shelf()).ToList();
    }

    public void PlaceBook(int index, Book book)
    {
        if (index < 0 || index >= _shelves.Count)
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid shelf index.");
        _shelves[index].PlaceBook(book);
    }
}