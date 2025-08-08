using System.ComponentModel.DataAnnotations;

namespace BoneConnect.Dto.Auth;

public class RegisterUserDto
{
    [Required(ErrorMessageResourceName = "UsernameRequired", ErrorMessageResourceType = typeof(Resources))]
    public string Username { get; set; }

    [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources))]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessageResourceName = "InvalidPasswordMessage", ErrorMessageResourceType = typeof(Resources))]
    public string? Password { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }
    
    [Required] public string ProfilePic { get; set; }
}