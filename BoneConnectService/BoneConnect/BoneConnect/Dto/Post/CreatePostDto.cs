using System.ComponentModel.DataAnnotations;
using BoneConnect.DataStructures.List;
using BoneConnect.Models.Profile;
using Newtonsoft.Json;

namespace BoneConnect.Dto.Post;

public class CreatePostDto
{
    [Required] public string Caption { get; set; }
    [Required] public List<string> Pictures { get; set; }
}