using LibraryManagement.app.Application.Presenters;

namespace LibraryManagement.app.Presentation.Presenters;

public class PutBookAwayPresenter : IPutBookAwayPresenter
{
    public bool IsSuccess { get; private set; }
    public string? ErrorMessage { get; private set; }

    public void HandleSuccess() => IsSuccess = true;
    public void HandleError(string message) => ErrorMessage = message;
}
