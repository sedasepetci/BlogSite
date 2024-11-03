using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Entities;


namespace BlogSite.Service.Abstratcts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateJwtTokenAsync(User user);
}