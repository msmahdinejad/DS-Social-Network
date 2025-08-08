using BoneConnect.Dto;
using BoneConnect.Dto.User;

namespace BoneConnect.Services.User.UserUpdateInfoService.Abstraction;

public interface IUserUpdateInfoServiceValidator
{
    Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, UserUpdateInfoDto userUpdateInfoDto);
}