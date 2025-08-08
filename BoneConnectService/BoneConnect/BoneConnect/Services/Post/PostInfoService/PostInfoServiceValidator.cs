using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Services.Post.PostInfoService.Abstraction;

namespace BoneConnect.Services.Post.PostInfoService;

public class PostInfoServiceValidator : IPostInfoServiceValidator
{
    public async Task<ActionResponse<PostOutputInfoDto>> Validate(Models.Post.Post post)
    {
        if (post is null) return NotFoundResult();
        return await SuccessResult();
    }

    private Task<ActionResponse<PostOutputInfoDto>> SuccessResult()
    {
        return Task.FromResult(new ActionResponse<PostOutputInfoDto>
        {
            StatusCode = StatusCodeType.Success
        });
    }

    private ActionResponse<PostOutputInfoDto> NotFoundResult()
    {
        return new ActionResponse<PostOutputInfoDto>
        {
            StatusCode = StatusCodeType.NotFound
        };
    }
}