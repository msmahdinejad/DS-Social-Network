using BoneConnect.Dto;

namespace BoneConnect.Services.User.ConnectUserService.Abstraction;

public interface IConnectionUserServiceValidator
{
    Task<ActionResponse<MessageDto>> ValidateConnection(Models.Auth.User currentUser, Models.Auth.User secondUser);
    Task<ActionResponse<MessageDto>> ValidateRemoveConnection(Models.Auth.User currentUser, Models.Auth.User secondUser);

}