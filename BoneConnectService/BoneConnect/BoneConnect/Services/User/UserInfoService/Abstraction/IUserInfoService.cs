using BoneConnect.Dto;
using UserOutputInfoDto = BoneConnect.Dto.User.UserOutputInfoDto;

namespace BoneConnect.Services.User.UserInfoService.Abstraction;

public interface IUserInfoService
{
    Task<ActionResponse<UserOutputInfoDto>> GetUser(Models.Auth.User user);
}