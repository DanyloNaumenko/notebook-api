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
    
    public UserService(
        IUserRepository userRepository,
        ILogger<UserService> logger,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _logger = logger;
        _passwordHasher = passwordHasher;
    }
    
    public RegisterResultDto Register(RegisterUserDto registerUserDto)
    {
        if (_userRepository.ExistsByLogin(registerUserDto.Login))
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
            Token = ""
        };
    }

    public LoginResultDto Login(LoginUserDto loginUserDto)
    {
        var user = _userRepository.GetByLogin(loginUserDto.Login);
        if (user == null)
            return new LoginResultDto()
            {
                Success = false,
                ErrorMessage = "Login failed because of user does not exist! Maybe you wanted to register it?"
            };
        
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUserDto.Password);
        if (result == PasswordVerificationResult.Success)
        {
            return new LoginResultDto()
            {
                Success = true,
                UserId = user.Id,
                Token = ""
            };
        }
        return new LoginResultDto()
        {
            Success = false,
            ErrorMessage = "Login failed because of invalid password!"
        };
    }

    public UserDto? GetByLogin(string login)
    {
        var user = _userRepository.GetByLogin(login);
        if(user == null) return null;
        var userDto = new UserDto()
        {
            Id = user.Id,
            Login = login,
        };
        return userDto;
    }

    public UpdateResultDto Update(Guid userId, UpdateUserDto updateUserDto)
    {
        var existing = _userRepository.GetById(userId);
        if(existing == null) return new UpdateResultDto()
        {
            Success = false,
            ErrorMessage = "User does not exist!"
        };

        var newUser = new User()
        {
            Id = userId,
            Login = updateUserDto.Login,
        };
        newUser.PasswordHash = _passwordHasher.HashPassword(newUser, updateUserDto.Password);
        if (_userRepository.Update(newUser, userId))
        {
            var updatedUserDto = new UserDto()
            {
                Id = newUser.Id,
                Login = newUser.Login
            };
            return new UpdateResultDto()
            {
                Success = true,
                UpdatedUserDto = updatedUserDto
            };
        }

        return new UpdateResultDto()
        {
            Success = false,
            ErrorMessage = "User updating went wrong!"
        };
    }

    public bool Delete(Guid userId)
    {
        if(_userRepository.ExistsById(userId))
            return _userRepository.Delete(userId);
        return false;
    }
}