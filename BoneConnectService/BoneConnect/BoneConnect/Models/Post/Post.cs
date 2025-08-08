using System.ComponentModel.DataAnnotations;
using BoneConnect.DataStructures.List;
using BoneConnect.Models.DataStructures;
using BoneConnect.Models.Profile;

namespace BoneConnect.Models.Post;

public class Post
{
    [Key] [StringLength(50)] public string Id { get; set; }
    
    [Required] public UserPreview Author { get; set; }
    
    [Required] public string Caption { get; set; }
    
    [Required] public ArrayList<string> Pictures { get; set; }
        
    //[Required] public ArrayList<string> Likes { get; set; }
}