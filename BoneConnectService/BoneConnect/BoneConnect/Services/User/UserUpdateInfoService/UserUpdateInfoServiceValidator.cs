using BoneConnect.Context;
using BoneConnect.Dto;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.User.UserUpdateInfoService.Abstraction;

namespace BoneConnect.Services.User.UserUpdateInfoService;

public class UserUpdateInfoServiceValidator(
    IMessageResponseCreator messageResponseCreator) : IUserUpdateInfoServiceValidator
{
    public Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, UserUpdateInfoDto userUpdateInfoDto)
    {
        if (user == null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.UserNotFoundMessage));

        if (!IsUsernameUnique(user.Username, userUpdateInfoDto.Username))
            return Task.FromResult(messageResponseCreator.Create(StatusCodeType.BadRequest,
                Resources.UsernameExistsMessage));

        if (!IsEmailUnique(user.Email, userUpdateInfoDto.Email))
            return Task.FromResult(messageResponseCreator.Create(StatusCodeType.BadRequest,
                Resources.EmailExistsMessage));

        return Task.FromResult(messageResponseCreator.Create(StatusCodeType.Success,
            Resources.SuccessfulUpdateUserMessage));
    }

    private bool IsUsernameUnique(string currentValue, string newValue)
    {
        if (currentValue == newValue) return true;

        var context = CustomDbContext.Instance;
        return !context.Users.Exists(newValue);
    }

    private bool IsEmailUnique(string currentValue, string newValue)
    {
        if (currentValue == newValue) return true;

        var context = CustomDbContext.Instance;
        return context.Users.GetAllValues().All(u => u.Email != newValue);
    }
}