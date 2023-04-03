using Dog_Market_2._0.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dog_Market_2._0.ViewModels.Response;

public class UserResponse
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public string Id { get; set; } = default!;
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
}
