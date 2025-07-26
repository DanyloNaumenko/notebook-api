using System.ComponentModel.DataAnnotations;

namespace Notebook.Application.DTOs.UserDTO;

public class UpdateUserDto
{
    [Required]
    public string Login { get; set; }
    
    [Required]
    public string Password { get; set; }
}