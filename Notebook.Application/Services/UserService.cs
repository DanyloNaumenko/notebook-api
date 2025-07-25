using Notebook.Application.DTOs.UserDTO;
using Notebook.Application.Interfaces;

namespace Notebook.Application.Services;

public class UserService : IUserService
{
    public RegisterResultDto Register(RegisterUserDto registerUserDto)
    {
        throw new NotImplementedException();
    }

    public LoginResultDto Login(LoginUserDto loginUserDto)
    {
        throw new NotImplementedException();
    }

    public UserDto? GetByLogin(string login)
    {
        throw new NotImplementedException();
    }

    public bool Update(Guid userId, UpdateUserDto updateUserDto)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid userId)
    {
        throw new NotImplementedException();
    }
}