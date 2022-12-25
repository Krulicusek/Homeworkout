using Microsoft.AspNetCore.Authorization.Infrastructure;
using HomeWorkoutModels.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public int? PhysioId { get; set; }
}
