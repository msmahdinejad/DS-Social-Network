using BoneConnect.Dto;
using BoneConnect.Dto.Auth;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.AuthServices.LoginService.Abstraction;
using BoneConnect.Services.CRUD.User.Abstraction;

namespace BoneConnect.Services.AuthServices.LoginService;

public class LoginService(
    IMessageResponseCreator messageResponseCreator,
    IUserReceiver userReceiver,
    ICookieSetter cookieSetter,
    IJwtTokenGenerator jwtTokenGenerator,
    IPasswordVerifier passwordVerifier)
    : ILoginService
{
    public async Task<ActionResponse<MessageDto>> LoginAsync(LoginDto loginModel, HttpResponse response)
    {
        var user = await userReceiver.ReceiveUserAsync(loginModel.Username);

        if (user == null || !passwordVerifier.VerifyPasswordHash(loginModel.Password, user.PasswordHash))
            return messageResponseCreator.Create(StatusCodeType.Unauthorized, Resources.LoginFailedMessage);

        var token = jwtTokenGenerator.GenerateJwtToken(user);
        cookieSetter.SetCookie(response, token);

        return messageResponseCreator.Create(StatusCodeType.Success, Resources.SuccessfulLoginMessage);
    }
}