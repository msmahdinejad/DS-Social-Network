using BoneConnect.Dto;
using BoneConnect.Enums;
using BoneConnect.Services.CRUD.Post.Abstraction;
using BoneConnect.Services.Post.PostDeleteService.Abstraction;

namespace BoneConnect.Services.Post.PostDeleteService;

public class PostDeleteService(IPostDeleteServiceValidator validator,
    IPostDeleter postDeleter) : IPostDeleteService
{
    public async Task<ActionResponse<MessageDto>> DeletePost(Models.Auth.User user, Models.Post.Post post)
    {
        var validateResult = await validator.Validate(user, post);
        if (validateResult.StatusCode != StatusCodeType.Success) return validateResult;

        await postDeleter.DeletePostAsync(user, post);

        return validateResult;
    }
}