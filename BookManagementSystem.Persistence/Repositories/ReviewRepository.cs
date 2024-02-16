using BookManagementSystem.Application.Contracts.Persistence;
using BookManagementSystem.Domain;
using BookManagementSystem.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Persistence.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(BookManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Review>> GetAllBookReviews(Guid bookId)
        {
            var reviews = await _dbContext.Reviews
                .Include(x => x.Book)
                .Where(x => x.BookID == bookId)
                .ToListAsync();
            return reviews;
        }
    }
}
