using System.ComponentModel.DataAnnotations;

namespace Dog_Market_2._0.ViewModels;

public class RegisterDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
}

