using BookManagementSystem.Application.Features.Book.Commands.AddBook;
using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;

namespace BookManagementSystem.Application.Features.Book.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    protected readonly IApplicationUnitOfWorkRepository _repository;
    public UpdateBookCommandValidator(IApplicationUnitOfWorkRepository repository)
    {
        this._repository = repository;

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("{PropertyName is required}")
            .MustAsync(BookNameExist)
            .WithMessage("{PropertyName} of the book already exist");

        RuleFor(x => x.ISBN)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Equal(13)
            .WithMessage("{PropertyName} has to have 13 numbers");

        RuleFor(x => x)
            .MustAsync(AuthorExist)
            .WithMessage("Author with this ID does not exist");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");
    }

    private async Task<bool> AuthorExist(UpdateBookCommand command, CancellationToken token)
    {
        var author = await _repository.Author.GetAsync(command.AuthorID);
        return author != null;
    }

    private async Task<bool> BookNameExist(string title, CancellationToken token)
    {
        var bookName = await _repository.Books.BookNameExist(title);
        return bookName == false;
    }
}
