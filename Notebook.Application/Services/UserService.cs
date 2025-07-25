using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Notebook.Application.DTOs.UserDTO;
using Notebook.Application.Interfaces;
using Notebook.Domain.Interfaces;
using Notebook.Domain.Models;

namespace Notebook.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;
    private readonly IPasswordHasher<User> _passwordHasher;
    public RegisterResultDto Register(RegisterUserDto registerUserDto)
    {
        if (_userRepository.Exists(registerUserDto.Login))
        {
            return new RegisterResultDto()
            {
                ErrorMessage = "User already exists!",
                Success = false
            };
        }

        var user = new User()
        {
            Id = Guid.NewGuid(),
            Login = registerUserDto.Login,
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, registerUserDto.Password);
        
        _userRepository.Create(user);
        return new RegisterResultDto()
        {
            Success = true,
            UserId = user.Id,
        };
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