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
    private readonly ISessionService _sessionService;
    private readonly TimeSpan _sessionTime = TimeSpan.FromMinutes(45);

    public UserService(
        IUserRepository userRepository,
        ILogger<UserService> logger,
        IPasswordHasher<User> passwordHasher,
        ISessionService sessionService)
    {
        _userRepository = userRepository;
        _logger = logger;
        _passwordHasher = passwordHasher;
        _sessionService = sessionService;
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
        
        var passwordCompareResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUserDto.Password);
        if (passwordCompareResult != PasswordVerificationResult.Success)
            return new LoginResultDto()
            {
                Success = false,
                ErrorMessage = "Login failed because of invalid password!"
            };
        var session = _sessionService.GetCurrentUserSession(user.Id);
        if (session == null) 
            session = _sessionService.CreateSession(user.Id, _sessionTime);
        return new LoginResultDto()
        {
            Success = true,
            UserId = user.Id,
            Token = session.Token
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
        User? existing;
        existing = _userRepository.GetById(userId);
        
        if(existing == null) return new UpdateResultDto()
        {
            Success = false,
            ErrorMessage = "User does not exist!"
        };
        if (updateUserDto.Login != null && _userRepository.ExistsByLogin(updateUserDto.Login)) return new UpdateResultDto()
        {
            Success = false,
            ErrorMessage = "User with this login already exists!"
        };
        var newUser = new User()
        {
            Id = userId,
            Login = updateUserDto.Login ?? existing.Login,
        };
        newUser.PasswordHash = updateUserDto.Password != null ? _passwordHasher.HashPassword(newUser, updateUserDto.Password) : existing.PasswordHash;
        if (!_userRepository.Update(newUser))
            return new UpdateResultDto()
            {
                Success = false,
                ErrorMessage = "User updating went wrong!"
            };
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

    public bool Delete(Guid userId)
    {
        if(_userRepository.ExistsById(userId))
            return _userRepository.Delete(userId);
        return false;
    }
}