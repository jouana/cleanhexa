using LibraryManagement.app.Application.Commands;
using LibraryManagement.app.Application.Handlers;
using LibraryManagement.app.Application.Presenters;
using LibraryManagement.app.Application.Queries;
using LibraryManagement.app.Infrastructure.Persistence;
using LibraryManagement.app.Infrastructure.Persistence.Sql;
using LibraryManagement.app.Presentation.Controllers;
using LibraryManagement.app.Presentation.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reqnroll;

namespace LibraryManagement.app.test.steps;

[Binding]
public class DeclareNewBookSteps
{
    private BookDAOStub _bookDao = new BookDAOStub();
    private BookController _sut = null!;
    private CreateBookRequest _request = new CreateBookRequest();
    private IActionResult _result = null!;

    private BookController CreateSut(BookDAOStub bookDao)
    {
        IAuthorDao authorDao = new AuthorDaoStub();
        BookRepository bookRepository = new BookRepository(bookDao);
        AuthorRepository authorRepository = new AuthorRepository(authorDao);
        ICommandHandler<RegisterBookCommand, IRegisterBookPresenter> commandHandler =
            new RegisterBookCommandHandler(bookRepository, authorRepository);

        var db = new LibraryDbContext(new DbContextOptionsBuilder<LibraryDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);
        IQueryHandler<GetBookByISBNQuery, BookReadModel?> queryHandler =
            new GetBookByISBNQueryHandler(db);

        return new BookController(commandHandler, queryHandler);
    }

    [Given("a book with ISBN {int}, title {string} and author {int}")]
    public void GivenABookWithIsbnTitleAndAuthor(int isbn, string title, int authorId)
    {
        _bookDao = new BookDAOStub();
        _sut = CreateSut(_bookDao);
        _request = new CreateBookRequest { ISBN = isbn, Title = title, AuthorId = authorId };
    }

    [When("I register the book")]
    public void WhenIRegisterTheBook()
    {
        _result = _sut.Create(_request);
    }

    [Then("the book is saved with ISBN {int} and title {string}")]
    public void ThenTheBookIsSavedWithIsbnAndTitle(int isbn, string title)
    {
        Assert.Equal(isbn, _bookDao.Books[0].ISBN);
        Assert.Equal(title, _bookDao.Books[0].Title);
    }

    [Then("the book is saved with author {int}")]
    public void ThenTheBookIsSavedWithAuthor(int authorId)
    {
        Assert.Equal(authorId, _bookDao.Books[0].AuthorId);
    }

    [Given("the ISBN {int} already exists in the catalog")]
    public void GivenTheIsbnAlreadyExistsInTheCatalog(int isbn)
    {
        _bookDao = new BookDAOStub(true);
        _sut = CreateSut(_bookDao);
        _request = new CreateBookRequest { ISBN = isbn };
    }

    [When("I try to register a book with ISBN {int}")]
    public void WhenITryToRegisterABookWithIsbn(int isbn)
    {
        _result = _sut.Create(_request);
    }

    [Then("the registration fails with a conflict")]
    public void ThenTheRegistrationFailsWithAConflict()
    {
        Assert.IsType<ConflictObjectResult>(_result);
    }
}