using LibraryManagement.app.Application.Commands;
using LibraryManagement.app.Application.Presenters;
using LibraryManagement.app.Application.Queries;
using LibraryManagement.app.Presentation.Presenters;
using LibraryManagement.app.Presentation.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.app.Presentation.Controllers;

[ApiController]
[Route("api/books")]
public class BookController(
    ICommandHandler<RegisterBookCommand, IRegisterBookPresenter> registerBookHandler,
    ICommandHandler<PutBookAwayCommand, IPutBookAwayPresenter> putBookAwayHandler,
    IQueryHandler<GetBookByISBNQuery, BookReadModel?> getBookByISBNHandler) : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] CreateBookRequest request)
    {
        RegisterBookCommand command = RegisterBookCommand.Builder
            .withISBN(request.ISBN)
            .withTitle(request.Title)
            .withAuthorId(request.AuthorId)
            .build();

        RegisterBookPresenter presenter = new RegisterBookPresenter();
        registerBookHandler.Handle(command, presenter);

        if (!presenter.IsSuccess)
            return Conflict(presenter.ErrorMessage);

        return Created();
    }

    [HttpPut("{isbn}/shelf")]
    public IActionResult PutAway(int isbn, [FromBody] PutBookAwayRequest request)
    {
        var command = new PutBookAwayCommand { Isbn = isbn, Row = request.Row, Shelf = request.Shelf };
        var presenter = new PutBookAwayPresenter();
        putBookAwayHandler.Handle(command, presenter);

        if (!presenter.IsSuccess)
            return BadRequest(presenter.ErrorMessage);

        return NoContent();
    }

    [HttpGet("{isbn}")]
    public IActionResult GetByISBN(int isbn)
    {
        BookReadModel? result = getBookByISBNHandler.Handle(new GetBookByISBNQuery(isbn));
        if (result is null) return NotFound();
        return Ok(result);
    }
}
