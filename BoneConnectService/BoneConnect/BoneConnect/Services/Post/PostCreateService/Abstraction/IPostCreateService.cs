using BoneConnect.Dto;
using BoneConnect.Dto.Post;

namespace BoneConnect.Services.Post.PostCreateService.Abstraction;

public interface IPostCreateService
{
    Task<ActionResponse<MessageDto>> CreatePost(Models.Auth.User user, CreatePostDto createPostDto);
}