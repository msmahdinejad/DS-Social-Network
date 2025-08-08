using BoneConnect.Dto;
using UserUpdateInfoDto = BoneConnect.Dto.User.UserUpdateInfoDto;

namespace BoneConnect.Services.User.UserUpdateInfoService.Abstraction;

public interface IUserUpdateInfoService
{
    Task<ActionResponse<MessageDto>> UpdateUserAsync(Models.Auth.User user, UserUpdateInfoDto userUpdateInfoDto,
        HttpResponse response);
}