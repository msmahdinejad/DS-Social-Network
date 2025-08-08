using BoneConnect.Dto;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.User.UserDeleteService.Abstraction;

namespace BoneConnect.Services.User.UserDeleteService;

public class UserDeleteServiceValidator(IMessageResponseCreator messageResponseCreator) : IUserDeleteServiceValidator
{
    public Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user)
    {
        if (user is null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.UserNotFoundMessage));

        return Task.FromResult(messageResponseCreator.Create(StatusCodeType.Success,
            Resources.SuccessfulDeleteUserMessage));
    }
}