using FluentValidation.Results;

namespace BookManagementSystem.Application.Exceptions;

public class FluentValidationException : Exception
{
    public IDictionary<string, string[]> ValidationErrors { get; set; }
    public FluentValidationException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
}
