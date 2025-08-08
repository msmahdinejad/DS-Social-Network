using BoneConnect.Dto;
using BoneConnect.Dto.Post;

namespace BoneConnect.Services.Post.PostUpdateInfoService.Abstraction;

public interface IPostUpdateInfoService
{
    Task<ActionResponse<MessageDto>> UpdatePostAsync(Models.Auth.User user, Models.Post.Post post,
        PostUpdateInfoDto postUpdateInfoDto);
}