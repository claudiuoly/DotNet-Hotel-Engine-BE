using System.ComponentModel.DataAnnotations;

namespace AuraStay.Api.Models;

public class LoginDto
{
    /// <summary>Username, email or phone number.</summary>
    [Required]
    public string LoginIdentifier { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
