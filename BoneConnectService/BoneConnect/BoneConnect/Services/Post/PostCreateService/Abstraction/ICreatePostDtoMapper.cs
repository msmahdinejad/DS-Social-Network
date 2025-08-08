using BoneConnect.Dto.Post;

namespace BoneConnect.Services.Post.PostCreateService.Abstraction;

public interface ICreatePostDtoMapper
{
    Models.Post.Post Map(Models.Auth.User user, CreatePostDto createPostDto);
}