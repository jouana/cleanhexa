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

    [HttpGet("{isbn}")]
    public IActionResult GetByISBN(int isbn)
    {
        BookReadModel? result = getBookByISBNHandler.Handle(new GetBookByISBNQuery(isbn));
        if (result is null) return NotFound();
        return Ok(result);
    }
}
