using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.DTOs.UserDTO;

public class RegisterUserDto
{
    [Required(ErrorMessage = "Login is required")]
    public string Login { get; set; } = null!;
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;
}