namespace LibraryManagement.app.Application.Commands;

public interface ICommandHandler<TCommand, TPresenter>
{
    void Handle(TCommand command, TPresenter presenter);
}
