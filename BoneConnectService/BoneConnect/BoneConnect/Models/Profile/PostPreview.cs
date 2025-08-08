using System.ComponentModel.DataAnnotations;

namespace BoneConnect.Models.Profile;

public class PostPreview
{
    [Key] [StringLength(50)] public string Id { get; set; }
    
    [Required] public string Thumbnail { get; set; }

    public PostPreview(Post.Post post)
    {
        Id = post.Id;
        Thumbnail = post.Pictures[0];
    }
    public PostPreview()
    {
    }
}