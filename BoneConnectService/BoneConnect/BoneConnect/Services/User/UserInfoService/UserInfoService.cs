using BoneConnect.Dto;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Services.User.UserInfoService.Abstraction;

namespace BoneConnect.Services.User.UserInfoService;

public class UserInfoService(
    IUserInfoServiceValidator validator) : IUserInfoService
{
    public async Task<ActionResponse<UserOutputInfoDto>> GetUser(Models.Auth.User user)
    {
        var validateResult = await validator.Validate(user);
        if (validateResult.StatusCode != StatusCodeType.Success)
            return validateResult;

        validateResult.Data = new UserOutputInfoDto(user);

        return validateResult;
    }
}