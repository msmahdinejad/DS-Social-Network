using BoneConnect.DataStructures.List;
using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Services.CRUD.Post.Abstraction;
using BoneConnect.Services.Post.PostUpdateInfoService.Abstraction;

namespace BoneConnect.Services.Post.PostUpdateInfoService;

public class PostUpdateInfoService(
    IPostUpdateInfoServiceValidator validator, 
    IPostUpdater postUpdater) : IPostUpdateInfoService
{
    public async Task<ActionResponse<MessageDto>> UpdatePostAsync(Models.Auth.User user, Models.Post.Post post, PostUpdateInfoDto postUpdateInfoDto)
    {
        var validateResult = await validator.Validate(user, post, postUpdateInfoDto);
        if (validateResult.StatusCode != StatusCodeType.Success)
            return validateResult;

        await UpdateInfo(user, post, postUpdateInfoDto);

        return validateResult;
    }

    private async Task UpdateInfo(Models.Auth.User user, Models.Post.Post post, PostUpdateInfoDto postUpdateInfoDto)
    {
        post.Caption = postUpdateInfoDto.Caption;
        post.Pictures = new ArrayList<string>(postUpdateInfoDto.Pictures);

        await postUpdater.UpdatePostAsync(user, post);
    }
}