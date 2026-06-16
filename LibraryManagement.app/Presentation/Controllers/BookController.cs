using LibraryManagement.app.Application.Commands;
using LibraryManagement.app.Application.UseCases;
using LibraryManagement.app.Presentation.Presenters;
using LibraryManagement.app.Presentation.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.app.Presentation.Controllers;

[ApiController]
[Route("api/books")]
public class BookController(RegisterBookUseCase registerBookUseCase) : ControllerBase
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
        registerBookUseCase.Execute(command, presenter);

        if (!presenter.IsSuccess)
            return Conflict(presenter.ErrorMessage);

        return Created();
    }
}
