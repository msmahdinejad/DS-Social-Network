using System.ComponentModel.DataAnnotations;
using BoneConnect.DataStructures.List;
using BoneConnect.Models.Profile;

namespace BoneConnect.Dto.Post;

public class PostOutputInfoDto
{
    [Key] [StringLength(50)] public string Id { get; set; }
    
    [Required] public UserPreview Author { get; set; }
    
    [Required] public string Caption { get; set; }
    
    [Required] public ArrayList<string> Pictures { get; set; }

    public PostOutputInfoDto(Models.Post.Post post)
    {
        Id = post.Id;
        Author = post.Author;
        Caption = post.Caption;
        Pictures = post.Pictures;
    }
}