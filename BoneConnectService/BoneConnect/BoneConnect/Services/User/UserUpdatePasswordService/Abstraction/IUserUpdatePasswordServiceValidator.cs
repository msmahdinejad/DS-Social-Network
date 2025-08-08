using BoneConnect.Dto;
using BoneConnect.Dto.User;

namespace BoneConnect.Services.User.UserUpdatePasswordService.Abstraction;

public interface IUserUpdatePasswordServiceValidator
{
    Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, UserPasswordInfoDto passwordInfoDto);
}