using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Enums;
using BoneConnect.Services.CRUD.Post.Abstraction;
using BoneConnect.Services.Post.PostCreateService.Abstraction;

namespace BoneConnect.Services.Post.PostCreateService;

public class PostCreateService(
    IPostAdder postAdder,
    IPostCreateServiceValidator validator,
    ICreatePostDtoMapper mapper) : IPostCreateService
{
    public async Task<ActionResponse<MessageDto>> CreatePost(Models.Auth.User user, CreatePostDto createPostDto)
    {
        var validateResult = await validator.Validate(user, createPostDto);
        if (validateResult.StatusCode != StatusCodeType.Success) return validateResult;

        await AddPost(user, createPostDto);

        return validateResult;
    }
    
    private async Task AddPost(Models.Auth.User user, CreatePostDto createPostDto)
    {
        var post = mapper.Map(user, createPostDto);
        await postAdder.AddPostAsync(user, post);
    }
}