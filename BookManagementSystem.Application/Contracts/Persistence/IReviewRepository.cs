using BookManagementSystem.Application.Contracts.Persistence.Base;
using BookManagementSystem.Domain;

namespace BookManagementSystem.Application.Contracts.Persistence;

public interface IReviewRepository : IGenericRepository<Review>
{
    public Task<List<Review>> GetAllBookReviews(Guid bookId);
}



