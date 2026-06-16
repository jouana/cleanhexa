namespace LibraryManagement.app.Domain.Entities;

public class Book(int isbn = 0, string title = "")
{
    public int ISBN => isbn;
    public string Title => title;
    public Author Author { get; private set; }

    public void AssignAuthor(Author author)
    {
        Author = author;
    }

    public override bool Equals(object? o)
    {
        if (o != null && o is Book book)
        {
            return ISBN == book.ISBN;
        }
        return false;
    }

    public static BookBuilder Builder()
    {
        return new BookBuilder();
    }

    public class BookBuilder(int isbn = 0, string title = "")
    {
        public BookBuilder withISBN(int pisbn)
        {
            return new BookBuilder(pisbn);
        }

        public BookBuilder withTitle(string ptitle)
        {
            return new BookBuilder(isbn, ptitle);
        }

        public Book build()
        {
            return new Book(isbn, title);
        }
    }
}
