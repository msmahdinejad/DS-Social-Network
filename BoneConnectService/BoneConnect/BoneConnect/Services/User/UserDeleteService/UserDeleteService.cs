using BoneConnect.Dto;
using BoneConnect.Enums;
using BoneConnect.Services.CRUD.User.Abstraction;
using BoneConnect.Services.User.LogoutService.Abstraction;
using BoneConnect.Services.User.UserDeleteService.Abstraction;

namespace BoneConnect.Services.User.UserDeleteService;

public class UserDeleteService(
    IUserDeleteServiceValidator validator,
    IUserDeleter userDeleter)
    : IUserDeleteService
{
    public async Task<ActionResponse<MessageDto>> DeleteUser(Models.Auth.User user)
    {
        var validateResult = await validator.Validate(user);
        if (validateResult.StatusCode != StatusCodeType.Success) return validateResult;

        await userDeleter.DeleteUserAsync(user);

        return validateResult;
    }
}