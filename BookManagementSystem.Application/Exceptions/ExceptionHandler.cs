using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Application.Exceptions
{
    public static class ExceptionHandler
    {
        public static void HandleException(Exception exception)
        {
            switch (exception)
            {
                case DbUpdateException:
                    throw new DatabaseUpdateException("Error with parent/child key delete");
                default:
                    throw new DefaultException();
            }
        }
    }
}
