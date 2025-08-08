using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Services.Post.PostInfoService.Abstraction;

namespace BoneConnect.Services.Post.PostInfoService;

public class PostInfoService(IPostInfoServiceValidator validator) : IPostInfoService
{
    public async Task<ActionResponse<PostOutputInfoDto>> GetPost(Models.Post.Post post)
    {
        var validateResult = await validator.Validate(post);
        if (validateResult.StatusCode != StatusCodeType.Success)
            return validateResult;

        validateResult.Data = new PostOutputInfoDto(post);

        return validateResult;    
    }
}