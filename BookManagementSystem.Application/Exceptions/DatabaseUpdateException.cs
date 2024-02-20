namespace BookManagementSystem.Application.Exceptions;

public class DatabaseUpdateException : Exception
{
    public DatabaseUpdateException(string message) : base(message)
    {

    }
}
