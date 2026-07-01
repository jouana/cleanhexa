namespace LibraryManagement.app.Presentation.Requests;

public class PutBookAwayRequest
{
    public int Row { get; init; }
    public int Shelf { get; init; }
}