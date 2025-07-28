using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.DTOs.UserDTO;

public class UpdateUserDto
{
    public string? Login { get; set; }
    
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string? Password { get; set; }
}