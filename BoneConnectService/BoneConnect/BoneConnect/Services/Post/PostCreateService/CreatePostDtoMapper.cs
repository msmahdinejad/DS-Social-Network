using BoneConnect.DataStructures.List;
using BoneConnect.Dto.Post;
using BoneConnect.Models.Profile;
using BoneConnect.Services.Post.PostCreateService.Abstraction;

namespace BoneConnect.Services.Post.PostCreateService;

public class CreatePostDtoMapper : ICreatePostDtoMapper
{
    public Models.Post.Post Map(Models.Auth.User user, CreatePostDto createPostDto)
    {
        return new Models.Post.Post
        {
            Id = Guid.NewGuid().ToString(),
            Author = new UserPreview(user),
            Caption = createPostDto.Caption,
            Pictures = new ArrayList<string>(createPostDto.Pictures)
        };
    }
}