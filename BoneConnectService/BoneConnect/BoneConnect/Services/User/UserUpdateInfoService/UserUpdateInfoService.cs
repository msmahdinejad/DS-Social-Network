using BoneConnect.Dto;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Services.CRUD.User.Abstraction;
using BoneConnect.Services.User.LogoutService.Abstraction;
using BoneConnect.Services.User.UserUpdateInfoService.Abstraction;

namespace BoneConnect.Services.User.UserUpdateInfoService;

public class UserUpdateInfoService(
    ILogoutService logoutService,
    IUserUpdater userUpdater,
    IUserUpdateInfoServiceValidator validator) : IUserUpdateInfoService
{
    public async Task<ActionResponse<MessageDto>> UpdateUserAsync(Models.Auth.User user,
        UserUpdateInfoDto userUpdateInfoDto, HttpResponse response)
    {
        var validateResult = await validator.Validate(user, userUpdateInfoDto);
        if (validateResult.StatusCode != StatusCodeType.Success)
            return validateResult;

        await UpdateInfo(user, userUpdateInfoDto, response);

        return validateResult;
    }

    private async Task UpdateInfo(Models.Auth.User user, UserUpdateInfoDto userUpdateInfoDto, HttpResponse response)
    {
        var id = user.Username;

        user.Username = userUpdateInfoDto.Username;
        user.Email = userUpdateInfoDto.Email;
        user.FirstName = userUpdateInfoDto.FirstName;
        user.LastName = userUpdateInfoDto.LastName;
        user.ProfilePic = userUpdateInfoDto.ProfilePic;

        if (id != user.Username)
        {
            await userUpdater.UpdateUserAsync(id, user);
            logoutService.Logout(response);
        }
    }
}