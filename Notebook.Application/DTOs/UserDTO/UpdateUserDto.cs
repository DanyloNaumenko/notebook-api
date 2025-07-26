using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.DTOs.UserDTO;

public class UpdateUserDto
{
    [Required]
    public string Login { get; set; }
    
    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }
}