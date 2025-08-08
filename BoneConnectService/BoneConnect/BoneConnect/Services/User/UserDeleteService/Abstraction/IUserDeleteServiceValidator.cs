using BoneConnect.Dto;

namespace BoneConnect.Services.User.UserDeleteService.Abstraction;

public interface IUserDeleteServiceValidator
{
    Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user);
}