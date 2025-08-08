using BoneConnect.Dto;

namespace BoneConnect.Services.Post.PostDeleteService.Abstraction;

public interface IPostDeleteServiceValidator
{
    Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, Models.Post.Post post);
}