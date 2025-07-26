using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.DTOs.UserDTO;

public class LoginUserDto
{
    [Required(ErrorMessage = "Login is required")]
    public string Login { get; set; } = null!;
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; } = null!;
}