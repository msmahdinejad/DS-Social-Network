using BoneConnect.Dto;

namespace BoneConnect.Services.Post.PostDeleteService.Abstraction;

public interface IPostDeleteService
{
    Task<ActionResponse<MessageDto>> DeletePost(Models.Auth.User user, Models.Post.Post post);
}