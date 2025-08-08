using System.ComponentModel.DataAnnotations;
using BoneConnect.DataStructures.List;
using Newtonsoft.Json;

namespace BoneConnect.Dto.Post;

public class PostUpdateInfoDto
{
    [Required] public string Caption { get; set; }
    [Required] public List<string> Pictures { get; set; }
}