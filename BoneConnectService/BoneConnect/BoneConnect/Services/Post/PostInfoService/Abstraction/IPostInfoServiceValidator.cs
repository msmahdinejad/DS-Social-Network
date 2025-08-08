using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Dto.User;

namespace BoneConnect.Services.Post.PostInfoService.Abstraction;

public interface IPostInfoServiceValidator
{
    Task<ActionResponse<PostOutputInfoDto>> Validate(Models.Post.Post post);
}