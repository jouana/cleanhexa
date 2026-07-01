namespace LibraryManagement.app.Application.Commands;

public class PutBookAwayCommand
{
    public int Isbn { get; init; }
    public int Row { get; init; }
    public int Shelf { get; init; }
}