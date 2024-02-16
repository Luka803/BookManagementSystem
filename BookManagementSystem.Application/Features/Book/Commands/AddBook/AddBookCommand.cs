using MediatR;

namespace BookManagementSystem.Application.Features.Book.Commands.AddBook;

public class AddBookCommand : IRequest<Guid>
{
    public string Title { get; set; } = null!;
    public Guid AuthorID { get; set; }
    public int ISBN { get; set; }
    public decimal Price { get; set; }
    public int PublicationYear { get; set; }

}
