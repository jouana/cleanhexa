namespace LibraryManagement.app.Domain.Entities;

public class Author(int id)
{
    public int Id => id;

    public static AuthorBuilder builder => new AuthorBuilder();

    public class AuthorBuilder(int authorId = 0)
    {
        public AuthorBuilder withId(int pAuthorId)
        {
            return new AuthorBuilder(pAuthorId);
        }

        public Author build()
        {
            return new Author(authorId);
        }
    }
}