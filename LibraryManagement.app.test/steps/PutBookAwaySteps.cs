using LibraryManagement.app.Application.Commands;
using LibraryManagement.app.Application.Handlers;
using LibraryManagement.app.Application.Presenters;
using LibraryManagement.app.Domain.Entities;
using LibraryManagement.app.Domain.Repositories;
using LibraryManagement.app.Infrastructure.Persistence;
using LibraryManagement.app.Infrastructure.Persistence.Sql.Entities;
using Reqnroll;

namespace LibraryManagement.app.test.steps;

[Binding]
public class PutBookAwaySteps
{
    private Library _library = null!;
    private LibraryRepositoryStub _libraryRepository = null!;
    private PutBookAwayHandler _handler = null!;
    private PutBookAwayPresenterStub _presenter = null!;
    private BookDAOStub _bookDao = null!;
    private PutBookAwayCommand _command = null!;

    [Given("a library with {int} rows of {int} shelves each")]
    public void GivenALibraryWithRowsAndShelves(int rows, int shelves)
    {
        BuildLibrary(rows, shelves);
    }

    [Given("a library with {int} row of {int} shelf")]
    public void GivenALibraryWithOneRowAndOneShelf(int rows, int shelves)
    {
        BuildLibrary(rows, shelves);
    }

    private void BuildLibrary(int rows, int shelves)
    {
        _library = new Library(new Rows(rows, shelves));
        _libraryRepository = new LibraryRepositoryStub(_library);
        _bookDao = new BookDAOStub();
        _handler = new PutBookAwayHandler(new BookRepository(_bookDao), _libraryRepository);
        _presenter = new PutBookAwayPresenterStub();
    }

    [Given("a book with ISBN {int} exists in the catalog")]
    public void GivenABookExistsInTheCatalog(int isbn)
    {
        _bookDao.Add(new BookEntity { ISBN = isbn, Title = "Test Book", AuthorId = 1 });
    }

    [Given("a book is already placed at row {int}, shelf {int}")]
    public void GivenABookIsAlreadyPlacedAt(int row, int shelf)
    {
        Book occupant = Book.Builder().withISBN(999999).withTitle("Occupant").build();
        occupant.AssignAuthor(Author.builder.withId(1).build());
        _library.PutBookAway(row, shelf, occupant);
    }

    [When("I put the book with ISBN {int} at row {int}, shelf {int}")]
    public void WhenIPutTheBookAt(int isbn, int row, int shelf)
    {
        _command = new PutBookAwayCommand { Isbn = isbn, Row = row, Shelf = shelf };
        _handler.Handle(_command, _presenter);
    }

    [When("I try to put the book with ISBN {int} at row {int}, shelf {int}")]
    public void WhenITryToPutTheBookAt(int isbn, int row, int shelf)
    {
        _command = new PutBookAwayCommand { Isbn = isbn, Row = row, Shelf = shelf };
        _handler.Handle(_command, _presenter);
    }

    [Then("the book is placed successfully")]
    public void ThenTheBookIsPlacedSuccessfully()
    {
        Assert.True(_presenter.IsSuccess);
    }

    [Then("the operation fails with message {string}")]
    public void ThenTheOperationFailsWithMessage(string message)
    {
        Assert.False(_presenter.IsSuccess);
        Assert.Contains(message, _presenter.ErrorMessage);
    }
}

internal class LibraryRepositoryStub(Library library) : ILibraryRepository
{
    private Library _library = library;

    public Library FindOne() => _library;
    public void Update(Library library) => _library = library;
}

internal class PutBookAwayPresenterStub : IPutBookAwayPresenter
{
    public bool IsSuccess { get; private set; }
    public string? ErrorMessage { get; private set; }

    public void HandleSuccess() => IsSuccess = true;
    public void HandleError(string message) => ErrorMessage = message;
}
