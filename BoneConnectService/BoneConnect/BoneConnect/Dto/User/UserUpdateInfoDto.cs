using System.ComponentModel.DataAnnotations;

namespace BoneConnect.Dto.User;

public class UserUpdateInfoDto
{
    [Required(ErrorMessageResourceName = "UsernameRequired", ErrorMessageResourceType = typeof(Resources))]
    public string Username { get; set; }

    [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources))]
    [EmailAddress]
    public string Email { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }
    
    [Required] public string ProfilePic { get; set; }
}