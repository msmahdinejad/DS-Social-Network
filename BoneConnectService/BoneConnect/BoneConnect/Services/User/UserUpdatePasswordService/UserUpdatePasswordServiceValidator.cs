using BoneConnect.Dto;
using BoneConnect.Dto.User;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.AuthServices.LoginService.Abstraction;
using BoneConnect.Services.User.UserUpdatePasswordService.Abstraction;

namespace BoneConnect.Services.User.UserUpdatePasswordService;

public class UserUpdatePasswordServiceValidator(
    IPasswordVerifier passwordVerifier,
    IMessageResponseCreator messageResponseCreator) : IUserUpdatePasswordServiceValidator
{
    public Task<ActionResponse<MessageDto>> Validate(Models.Auth.User user, UserPasswordInfoDto passwordInfoDto)
    {
        if (user is null)
            return Task.FromResult(
                messageResponseCreator.Create(StatusCodeType.NotFound, Resources.UserNotFoundMessage));
        if (!passwordVerifier.VerifyPasswordHash(passwordInfoDto.OldPassword, user.PasswordHash))
            return Task.FromResult(messageResponseCreator.Create(StatusCodeType.BadRequest,
                Resources.WrongOldPasswordMessage));
        return Task.FromResult(messageResponseCreator.Create(StatusCodeType.Success,
            Resources.SuccessfulUpdateUserMessage));
    }
}