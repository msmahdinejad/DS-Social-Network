using BoneConnect.Dto;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.Post.PostDeleteService.Abstraction;

namespace BoneConnect.Services.Post.PostDeleteService;

public class PostDeleteServiceValidator(
    IMessageResponseCreator messageResponseCreator) : IPostDeleteServiceValidator
{
    public Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, Models.Post.Post post)
    {
        if (user is null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.UserNotFoundMessage));
        if (post is null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.PostNotFoundMessage));
        if(post.Author.Username != user.Username)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.Forbidden, Resources.ForbiddenPost));

        return Task.FromResult(messageResponseCreator.Create(StatusCodeType.Success,
            Resources.SuccessfulDeletePostMessage));
    }
}