using BoneConnect.Dto;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.User.ConnectUserService.Abstraction;

namespace BoneConnect.Services.User.ConnectUserService;

public class ConnectionUserServiceValidator(IMessageResponseCreator messageResponseCreator) : IConnectionUserServiceValidator
{
    public Task<ActionResponse<MessageDto>> ValidateConnection(Models.Auth.User currentUser, Models.Auth.User secondUser)
    {
        if (currentUser == null || secondUser == null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.UserNotFoundMessage));
        if (currentUser.Username == secondUser.Username)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.BadRequest, Resources.WrongConnectionId));
        if (currentUser.connections.Exists(secondUser.Username))
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.BadRequest, Resources.AlreadyConnectMessage));
        
        return Task.FromResult(messageResponseCreator.Create(StatusCodeType.Success,
            Resources.SuccessfulUpdateUserMessage));
    }

    public Task<ActionResponse<MessageDto>> ValidateRemoveConnection(Models.Auth.User currentUser, Models.Auth.User secondUser)
    {
        if (currentUser == null || secondUser == null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.UserNotFoundMessage));
        if (currentUser.Username == secondUser.Username)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.BadRequest, Resources.WrongRemoveConnectionId));
        if (!currentUser.connections.Exists(secondUser.Username))
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.BadRequest, Resources.AlreadyNotConnectMessage));
        
        return Task.FromResult(messageResponseCreator.Create(StatusCodeType.Success,
            Resources.SuccessfulUpdateUserMessage));
    }
}