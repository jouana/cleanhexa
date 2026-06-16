using LibraryManagement.app.Application.Commands;
using LibraryManagement.app.Application.Presenters;
using LibraryManagement.app.Domain.Entities;
using LibraryManagement.app.Domain.Repositories;

namespace LibraryManagement.app.Application.Handlers;

public class RegisterBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository)
    : ICommandHandler<RegisterBookCommand, IRegisterBookPresenter>
{
    public void Handle(RegisterBookCommand command, IRegisterBookPresenter presenter)
    {
        if (bookRepository.IsbnAlreadyExist(command.ISBN))
        {
            presenter.HandleError("ISBN already exist");
            return;
        }

        Book book = Book.Builder()
            .withISBN(command.ISBN)
            .withTitle(command.Title)
            .build();

        Author author = authorRepository.FindOneById(command.AuthorId);
        book.AssignAuthor(author);

        bookRepository.Add(book);
        presenter.HandleSuccess();
    }
}
