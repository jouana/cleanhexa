namespace LibraryManagement.app.Application.Presenters;

public interface IPutBookAwayPresenter
{
    void HandleSuccess();
    void HandleError(string message);
}