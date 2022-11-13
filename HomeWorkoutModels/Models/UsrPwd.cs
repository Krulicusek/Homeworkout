using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

public class UsrPwd
{
    [Parameter]
    [Display(Name = "Nazwa Użytkownika")]
    [Required(ErrorMessage = "Pole '{0}' jest wymagane")]
    public string Username { get; set; }
    [Display(Name = "Hasło")]
    [Required(ErrorMessage = "Pole '{0}' jest wymagane")]
    public string Pwd { get; set; }
}

