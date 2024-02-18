using BookManagementSystem.Application.Models;

namespace BookManagementSystem.Application.Features.User.Queries.GetUserDetails;

public class UserDetailsDTO : BaseDTO
{
    public string FullName { get; set; } = null!;
}
