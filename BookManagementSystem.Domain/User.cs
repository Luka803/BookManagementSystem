using BookManagementSystem.Domain.Base;

namespace BookManagementSystem.Domain;

public class User : BaseEntity
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

}
