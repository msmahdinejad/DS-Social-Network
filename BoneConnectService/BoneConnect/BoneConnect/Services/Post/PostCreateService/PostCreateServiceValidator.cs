using BoneConnect.Context;
using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.Post.PostCreateService.Abstraction;

namespace BoneConnect.Services.Post.PostCreateService;

public class PostCreateServiceValidator(IMessageResponseCreator messageResponseCreator) : IPostCreateServiceValidator
{
    public Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, CreatePostDto createPostDto)
    {
        if (user == null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.UserNotFoundMessage));

        if (createPostDto.Pictures == null || createPostDto.Pictures.Count < 1)
            return Task.FromResult(messageResponseCreator.Create(StatusCodeType.BadRequest,
                Resources.PicturesRequired));

        return Task.FromResult(messageResponseCreator.Create(StatusCodeType.Success, Resources.SucceddfulCreatePost));
    }
}