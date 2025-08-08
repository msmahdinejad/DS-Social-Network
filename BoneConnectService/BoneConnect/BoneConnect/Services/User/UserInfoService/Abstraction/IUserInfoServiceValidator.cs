using BoneConnect.Dto;
using BoneConnect.Dto.User;

namespace BoneConnect.Services.User.UserInfoService.Abstraction;

public interface IUserInfoServiceValidator
{
    Task<ActionResponse<UserOutputInfoDto>> Validate(Models.Auth.User user);
}