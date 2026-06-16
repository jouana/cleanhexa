namespace LibraryManagement.app.Application.Commands;

public class RegisterBookCommand(int isbn, int authorId, string title)
{
    public int ISBN => isbn;
    public int AuthorId => authorId;
    public string Title => title;

    public static RegisterBookCommandBuilder Builder => new();

    public class RegisterBookCommandBuilder(int isbn = 0, int authorId = 0, string title = "")
    {
        public RegisterBookCommandBuilder withISBN(int isbn)
        {
            return new(isbn, authorId, title);
        }

        public RegisterBookCommandBuilder withAuthorId(int authorId)
        {
            return new(isbn, authorId, title);
        }

        public RegisterBookCommandBuilder withTitle(string title)
        {
            return new(isbn, authorId, title);
        }

        public RegisterBookCommand build()
        {
            return new(isbn, authorId, title);
        }
    }
}