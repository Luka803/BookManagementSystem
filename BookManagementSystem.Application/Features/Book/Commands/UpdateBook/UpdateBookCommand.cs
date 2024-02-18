using BookManagementSystem.Application.Models;
using MediatR;

namespace BookManagementSystem.Application.Features.Book.Commands.UpdateBook
{
    public class UpdateBookCommand : BaseDTO, IRequest<Guid>
    {
        public string Title { get; set; } = null!;
        public Guid AuthorID { get; set; }
        public int ISBN { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
    }
}
