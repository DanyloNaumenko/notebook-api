namespace Notebook.Application.DTOs.UserDTO;

public class UpdateResultDto
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public UserDto? UpdatedUserDto { get; set; }
}