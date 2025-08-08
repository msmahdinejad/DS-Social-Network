using BoneConnect.Dto;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Services.User.UserInfoService.Abstraction;

namespace BoneConnect.Services.User.UserInfoService;

public class UserInfoServiceValidator : IUserInfoServiceValidator
{
    public async Task<ActionResponse<UserOutputInfoDto>> Validate(Models.Auth.User user)
    {
        if (user is null) return NotFoundResult();
        return await SuccessResult();
    }

    private Task<ActionResponse<UserOutputInfoDto>> SuccessResult()
    {
        return Task.FromResult(new ActionResponse<UserOutputInfoDto>
        {
            StatusCode = StatusCodeType.Success
        });
    }

    private ActionResponse<UserOutputInfoDto> NotFoundResult()
    {
        return new ActionResponse<UserOutputInfoDto>
        {
            StatusCode = StatusCodeType.NotFound
        };
    }
}