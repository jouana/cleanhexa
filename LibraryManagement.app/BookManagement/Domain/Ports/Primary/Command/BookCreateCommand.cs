namespace LibraryManagement.app.BookManagement.Domain.Ports.Primary.Command;

public class BookCreateCommand(int isbn, int authorId, string title)
{
    public int ISBN => isbn;
    public int AuthorId => authorId;
    
    public string Title => title;
    
    public static BookCreateCommandBuilder Builder => new();

    public class BookCreateCommandBuilder(int isbn = 0, int authorId = 0, string title = "")
    {
        public BookCreateCommandBuilder withISBN(int isbn)
        {
            return new(isbn, authorId, title);
        }
        
        public BookCreateCommandBuilder withAuthorId(int authorId)
        {
            return new (isbn, authorId, title);
        }

        public BookCreateCommandBuilder withTitle(string title)
        {
            return new (isbn, authorId, title);
        }   

        public BookCreateCommand build()
        {
            return new (isbn, authorId, title);
        }
    }
}