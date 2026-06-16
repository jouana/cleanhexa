using LibraryManagement.app.BookManagement.Adapter.Primary;
using LibraryManagement.app.BookManagement.Adapter.Primary.Resource;
using LibraryManagement.app.BookManagement.Adapter.Secondary;
using LibraryManagement.app.BookManagement.Adapter.Secondary.Provider;
using LibraryManagement.app.BookManagement.Adapter.Secondary.Provider.Entity;

namespace LibraryManagement.app.test;

public class DeclareNewBook
{
    private BookRestController initSut(BookDAOStub bookDao)
    {
        IAuthorDao authorDao = new AuthorDaoStub();
        BookRepository bookRepository = new BookRepository(bookDao);
        AuthorRepository authorRepository = new AuthorRepository(authorDao);
        BookService bookService = new BookService(bookRepository, authorRepository);
        return new BookRestController(bookService);

    }
    
    
    [Fact]
    public void When_OK_Then_ISBN_Saved()
    {
        BookDAOStub bookDao = new BookDAOStub();
        BookRestController bookRestController = initSut(bookDao);
        BookResource resource = new BookResource()
        {
            ISBN = 123456789,
            AuthorId = 1,
            Title = "asitrau"
        };
        

        bookRestController.Create(resource);
        
        Assert.Equal(bookDao.Books[0].ISBN, resource.ISBN);
    }
    
    
    [Fact]
    public void When_OK_Then_Title_Saved()
    {
        BookDAOStub bookDao = new BookDAOStub();
        BookRestController bookRestController = initSut(bookDao);
        BookResource resource = new BookResource()
        {
            ISBN = 123456789,
            AuthorId = 1,
            Title = "asitrau"
        };
        
        bookRestController.Create(resource);
        
        Assert.Equal(bookDao.Books[0].Title, resource.Title);
    }
    
    [Fact]
    public void When_OK_Then_Author_Saved()
    {
        BookDAOStub bookDao = new BookDAOStub();
        BookRestController bookRestController = initSut(bookDao);
        BookResource resource = new BookResource()
        {
            ISBN = 123456789,
            AuthorId = 1,
            Title = "asitrau"
        };
        
        bookRestController.Create(resource);
        
        Assert.Equal(bookDao.Books[0].AuthorId, resource.AuthorId);
    }
    

    [Fact]
    public void When_ISBN_already_exist_then_Error()
    {
        BookDAOStub bookDao = new BookDAOStub(true);
        BookRestController bookRestController = initSut(bookDao);
        BookResource resource = new BookResource()
        {
            ISBN = 123456789,
        };
        
        Assert.Throws<Exception>(() => bookRestController.Create(resource));
    }
}

internal class AuthorDaoStub : IAuthorDao
{
    public AuthorEntity FindOneById(int commandAuthorId)
    {
        return new AuthorEntity()
        {
            Id = 1
        };
    }
}

public class BookDAOStub(bool isbnExist = false) : IBookDao
{
    public IList<BookEntity> Books { get; } = new List<BookEntity>();
    
    public void Add(BookEntity book)
    {
        Books.Add(book);
    }

    public bool IsbnAlreadyExist(int bookIsbn)
    {
        return isbnExist;
    }
}
