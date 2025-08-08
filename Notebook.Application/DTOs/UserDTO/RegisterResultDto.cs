namespace Notebook.Application.DTOs.UserDTO;

public class RegisterResultDto
{
    public bool Success { get; set; }
    
    public string? ErrorMessage { get; set; }
    
    public Guid? UserId { get; set; }
    
}
