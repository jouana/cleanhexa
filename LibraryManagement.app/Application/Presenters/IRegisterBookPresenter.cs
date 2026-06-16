namespace LibraryManagement.app.Application.Presenters;

public interface IRegisterBookPresenter
{
    void HandleSuccess();
    void HandleError(string message);
}
