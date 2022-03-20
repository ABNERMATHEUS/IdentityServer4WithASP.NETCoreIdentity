using System.ComponentModel.DataAnnotations;

namespace APITest.Dto;

public class UserCreateDto
{

    [Required]
    public string  Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}