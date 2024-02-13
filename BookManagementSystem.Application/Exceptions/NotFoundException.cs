namespace BookManagementSystem.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) : base($"{name} with ID ({key}) not found")
    {

    }
}
