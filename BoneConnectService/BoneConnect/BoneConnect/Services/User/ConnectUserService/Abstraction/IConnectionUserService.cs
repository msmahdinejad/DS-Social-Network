using BoneConnect.Dto;
using BoneConnect.Dto.User;

namespace BoneConnect.Services.User.ConnectUserService.Abstraction;

public interface IConnectionUserService
{
    Task<ActionResponse<MessageDto>> Connection(Models.Auth.User currentUser, Models.Auth.User secondUser);
    Task<ActionResponse<MessageDto>> RemoveConnection(Models.Auth.User currentUser, Models.Auth.User secondUser);

}