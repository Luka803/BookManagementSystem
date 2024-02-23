using MediatR;

namespace BookManagementSystem.Application.Features.Review.Commands.AddReview;

public class AddReviewCommand : IRequest<Guid>
{
    public Guid BookID { get; set; }
    public Guid UserID { get; set; }
    public decimal Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}
