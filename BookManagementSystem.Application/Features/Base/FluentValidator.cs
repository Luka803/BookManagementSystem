using BookManagementSystem.Application.UnitOfWork;
using FluentValidation;

namespace BookManagementSystem.Application.Features.Base;

public abstract class FluentValidator<T> : AbstractValidator<T> where T : class
{
    protected readonly IApplicationUnitOfWorkRepository _repository;
    public FluentValidator(IApplicationUnitOfWorkRepository _repository)
    {
        this._repository = _repository;
    }
}