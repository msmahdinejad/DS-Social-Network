using BoneConnect.Dto;

namespace BoneConnect.Services.User.UserDeleteService.Abstraction;

public interface IUserDeleteService
{
    Task<ActionResponse<MessageDto>> DeleteUser(Models.Auth.User user);
}