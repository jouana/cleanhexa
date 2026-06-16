namespace LibraryManagement.app.Application.Queries;

public interface IQueryHandler<TQuery, TResult>
{
    TResult Handle(TQuery query);
}
