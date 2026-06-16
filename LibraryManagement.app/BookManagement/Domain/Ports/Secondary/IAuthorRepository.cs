namespace LibraryManagement.app.BookManagement.Domain.Ports.Secondary;

public interface IAuthorRepository 
{
    Author FindOneById(int commandAuthorId);
}