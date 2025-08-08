using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Dto.User;

namespace BoneConnect.Services.Post.PostUpdateInfoService.Abstraction;

public interface IPostUpdateInfoServiceValidator
{
    Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, Models.Post.Post post,
        PostUpdateInfoDto postUpdateInfoDto);
}