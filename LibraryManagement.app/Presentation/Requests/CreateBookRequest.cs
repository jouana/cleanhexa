namespace LibraryManagement.app.Presentation.Requests;

public class CreateBookRequest
{
    public int ISBN { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
}
