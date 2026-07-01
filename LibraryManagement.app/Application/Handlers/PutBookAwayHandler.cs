using LibraryManagement.app.Application.Commands;
using LibraryManagement.app.Application.Presenters;
using LibraryManagement.app.Domain.Entities;
using LibraryManagement.app.Domain.Repositories;

namespace LibraryManagement.app.Application.Handlers;

public class PutBookAwayHandler(IBookRepository bookRepository, ILibraryRepository libraryRepository)
    : ICommandHandler<PutBookAwayCommand, IPutBookAwayPresenter>
{
    public void Handle(PutBookAwayCommand command, IPutBookAwayPresenter presenter)
    {
        Book book = bookRepository.FindByIsbn(command.Isbn);
        Library library = libraryRepository.FindOne();

        try
        {
            library.PutBookAway(command.Row, command.Shelf, book);
            libraryRepository.Update(library);
            presenter.HandleSuccess();
        }
        catch (Exception ex)
        {
            presenter.HandleError(ex.Message);
        }
    }
}