namespace Notebook.Application.DTOs.UserDTO;

public class LoginResultDto
{
    public bool Success { get; set; }

    public string? Token { get; set; }

    public string? ErrorMessage { get; set; }
    
    public Guid? UserId { get; set; }
}