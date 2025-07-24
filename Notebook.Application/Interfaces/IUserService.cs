using Notebook.Application.DTOs.UserDTO;

namespace Notebook.Application.Interfaces;

public interface IUserService
{
    public RegisterResultDto Register(RegisterUserDto registerUserDto);
    public LoginResultDto Login(LoginUserDto loginUserDto);
    public UserDto? GetByLogin(string login);
    public bool Update(Guid userId, UpdateUserDto updateUserDto);
    public bool Delete(Guid userId);
}