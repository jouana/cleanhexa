using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.app.Infrastructure.Persistence.Sql.Entities;

public class BookEntity
{
    [Key]
    public int ISBN { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }

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
