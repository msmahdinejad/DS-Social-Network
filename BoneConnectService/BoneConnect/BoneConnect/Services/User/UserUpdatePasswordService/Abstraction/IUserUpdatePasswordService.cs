using BoneConnect.Dto;
using UserPasswordInfoDto = BoneConnect.Dto.User.UserPasswordInfoDto;

namespace BoneConnect.Services.User.UserUpdatePasswordService.Abstraction;

public interface IUserUpdatePasswordService
{
    Task<ActionResponse<MessageDto>> UpdatePasswordAsync(Models.Auth.User user, UserPasswordInfoDto passwordInfoDto);
}