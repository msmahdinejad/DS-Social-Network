using BoneConnect.DataStructures.List;
using BoneConnect.Models.DataStructures;
using BoneConnect.Models.Profile;

namespace BoneConnect.Dto.User;

public class UserOutputInfoDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string ProfilePic { get; set; }
    public ArrayList<PostPreview> posts { get; set; }
    public ArrayList<UserPreview> connections { get; set; }

    public UserOutputInfoDto(Models.Auth.User user)
    {
        Username = user.Username;
        Email = user.Email;
        FirstName = user.FirstName;
        LastName = user.LastName;
        posts = user.posts.GetAllValues();
        ProfilePic = user.ProfilePic;
        connections = user.connections.GetAllValues();
    }
}