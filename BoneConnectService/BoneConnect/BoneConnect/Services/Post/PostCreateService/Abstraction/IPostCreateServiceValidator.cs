using BoneConnect.Dto;
using BoneConnect.Dto.Auth;
using BoneConnect.Dto.Post;

namespace BoneConnect.Services.Post.PostCreateService.Abstraction;

public interface IPostCreateServiceValidator
{
    Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, CreatePostDto createPostDto);
}