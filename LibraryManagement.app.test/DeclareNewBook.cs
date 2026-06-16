using LibraryManagement.app.Application.UseCases;
using LibraryManagement.app.Infrastructure.Persistence;
using LibraryManagement.app.Infrastructure.Persistence.Sql;
using LibraryManagement.app.Infrastructure.Persistence.Sql.Entities;
using LibraryManagement.app.Presentation.Controllers;
using LibraryManagement.app.Presentation.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.app.test;

public class DeclareNewBook
{
    private BookController initSut(BookDAOStub bookDao)
    {
        IAuthorDao authorDao = new AuthorDaoStub();
        BookRepository bookRepository = new BookRepository(bookDao);
        AuthorRepository authorRepository = new AuthorRepository(authorDao);
        RegisterBookUseCase registerBookUseCase = new RegisterBookUseCase(bookRepository, authorRepository);
        return new BookController(registerBookUseCase);
    }

    [Fact]
    public void When_OK_Then_ISBN_Saved()
    {
        BookDAOStub bookDao = new BookDAOStub();
        BookController bookController = initSut(bookDao);
        CreateBookRequest request = new CreateBookRequest()
        {
            ISBN = 123456789,
            AuthorId = 1,
            Title = "asitrau"
        };

        bookController.Create(request);

        Assert.Equal(bookDao.Books[0].ISBN, request.ISBN);
    }

    [Fact]
    public void When_OK_Then_Title_Saved()
    {
        BookDAOStub bookDao = new BookDAOStub();
        BookController bookController = initSut(bookDao);
        CreateBookRequest request = new CreateBookRequest()
        {
            ISBN = 123456789,
            AuthorId = 1,
            Title = "asitrau"
        };

        bookController.Create(request);

        Assert.Equal(bookDao.Books[0].Title, request.Title);
    }

    [Fact]
    public void When_OK_Then_Author_Saved()
    {
        BookDAOStub bookDao = new BookDAOStub();
        BookController bookController = initSut(bookDao);
        CreateBookRequest request = new CreateBookRequest()
        {
            ISBN = 123456789,
            AuthorId = 1,
            Title = "asitrau"
        };

        bookController.Create(request);

        Assert.Equal(bookDao.Books[0].AuthorId, request.AuthorId);
    }

    [Fact]
    public void When_ISBN_already_exist_then_Error()
    {
        BookDAOStub bookDao = new BookDAOStub(true);
        BookController bookController = initSut(bookDao);
        CreateBookRequest request = new CreateBookRequest()
        {
            ISBN = 123456789,
        };

        IActionResult result = bookController.Create(request);

        Assert.IsType<ConflictObjectResult>(result);
    }
}

internal class AuthorDaoStub : IAuthorDao
{
    public AuthorEntity FindOneById(int authorId)
    {
        return new AuthorEntity() { Id = 1 };
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
