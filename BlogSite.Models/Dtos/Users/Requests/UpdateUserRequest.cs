
namespace BlogSite.Models.Dtos.Users.Requests;

public sealed record UpdateUserRequest(long UserId,string FirstName,string LastName,string Email,string UserName,string Password);

