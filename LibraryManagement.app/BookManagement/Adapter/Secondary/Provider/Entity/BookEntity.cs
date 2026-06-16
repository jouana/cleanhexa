namespace LibraryManagement.app.BookManagement.Adapter.Secondary.Provider.Entity;

public class BookEntity
{
    public int ISBN;
    public string Title;
    public int AuthorId;
    
    public static BookEntityBuilder Builder => new BookEntityBuilder();

    public class BookEntityBuilder(int isbn = 0, string title = "", int authorId = 0)
    {
        public BookEntityBuilder withISBN(int pisbn)
        {
            return new BookEntityBuilder(pisbn);
        }
        
        public BookEntityBuilder withTitle(string pbookTitle)
        {
            return new BookEntityBuilder(isbn, pbookTitle);
        }
        
        public BookEntityBuilder withAuthorId(int pauthorId)
        {
            return new BookEntityBuilder(isbn, title, pauthorId);    
        }
        
        public BookEntity build()
        {
            return new BookEntity()
            {
                ISBN = isbn,
                Title = title,
                AuthorId = authorId
            };
        }
    }
}