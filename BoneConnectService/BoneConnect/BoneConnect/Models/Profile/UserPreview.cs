using System.ComponentModel.DataAnnotations;
using BoneConnect.Models.Auth;

namespace BoneConnect.Models.Profile;

public class UserPreview
{
    [Key] [StringLength(50)] public string Username { get; set; }
    
    [Required] public string ProfilePic { get; set; }

    public UserPreview(User user)
    {
        Username = user.Username;
        ProfilePic = user.ProfilePic;
    }
    public UserPreview()
    {
    }
}