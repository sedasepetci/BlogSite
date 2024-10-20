

using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Conceretes;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public ReturnModel<UserResponseDto> Add(CreateUserRequest create)
    {
        throw new NotImplementedException();
    }

    public ReturnModel<List<UserResponseDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public ReturnModel<UserResponseDto?> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public ReturnModel<UserResponseDto> Remove(long id)
    {
        throw new NotImplementedException();
    }

    public ReturnModel<UserResponseDto> Update(UpdateUserRequest update)
    {
        throw new NotImplementedException();
    }
}
