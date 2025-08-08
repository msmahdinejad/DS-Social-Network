using BoneConnect.Dto;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Services.AuthServices.LoginService.Abstraction;
using BoneConnect.Services.CRUD.User.Abstraction;
using BoneConnect.Services.User.UserUpdatePasswordService.Abstraction;

namespace BoneConnect.Services.User.UserUpdatePasswordService;

public class UserUpdatePasswordService(
    IUserUpdatePasswordServiceValidator validator, IPasswordHasher passwordHasher) : IUserUpdatePasswordService
{
    public async Task<ActionResponse<MessageDto>> UpdatePasswordAsync(Models.Auth.User user, UserPasswordInfoDto passwordInfoDto)
    {
        var validateResult = await validator.Validate(user, passwordInfoDto);
        if (validateResult.StatusCode != StatusCodeType.Success)
            return validateResult;

        await UpdatePassword(user, passwordInfoDto);

        return validateResult;
    }

    private Task UpdatePassword(Models.Auth.User user, UserPasswordInfoDto passwordInfoDto)
    {
        user.PasswordHash = passwordHasher.HashPassword(passwordInfoDto.NewPassword);
        return Task.CompletedTask;
        //await userUpdater.UpdateUserAsync(user.Username, user);
    }
}