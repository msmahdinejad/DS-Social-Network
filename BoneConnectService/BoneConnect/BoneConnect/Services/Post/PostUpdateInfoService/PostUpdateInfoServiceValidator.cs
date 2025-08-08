using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.Post.PostUpdateInfoService.Abstraction;

namespace BoneConnect.Services.Post.PostUpdateInfoService;

public class PostUpdateInfoServiceValidator(
    IMessageResponseCreator messageResponseCreator) : IPostUpdateInfoServiceValidator
{
    public Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, Models.Post.Post post, PostUpdateInfoDto postUpdateInfoDto)
    {
        if (user == null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.UserNotFoundMessage));
        
        if (post is null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.PostNotFoundMessage));
        
        if(post.Author.Username != user.Username)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.Forbidden, Resources.ForbiddenPost));

        if (postUpdateInfoDto.Pictures == null || postUpdateInfoDto.Pictures.Count < 1)
            return Task.FromResult(messageResponseCreator.Create(StatusCodeType.BadRequest,
                Resources.PicturesRequired));
        

        return Task.FromResult(messageResponseCreator.Create(StatusCodeType.Success, Resources.SucceddfulCreateUser));
    }
}