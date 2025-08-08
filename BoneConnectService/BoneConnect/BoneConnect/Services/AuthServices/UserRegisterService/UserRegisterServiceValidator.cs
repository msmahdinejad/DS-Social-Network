using BoneConnect.Context;
using BoneConnect.Dto;
using BoneConnect.Dto.Auth;
using BoneConnect.Enums;
using BoneConnect.Services.Abstraction;
using BoneConnect.Services.AuthServices.UserRegisterService.Abstraction;

namespace BoneConnect.Services.AuthServices.UserRegisterService;

public class UserRegisterServiceValidator(
    IMessageResponseCreator messageResponseCreator) : IUserRegisterServiceValidator
{
    public Task<ActionResponse<MessageDto>> Validate(RegisterUserDto registerUserDto)
    {
        var context = CustomDbContext.Instance;

        if (context.Users.Exists(registerUserDto.Username))
            return Task.FromResult(messageResponseCreator.Create(StatusCodeType.BadRequest,
                Resources.UsernameExistsMessage));

        if (context.Users.GetAllValues().Select(x => x.Email).ToList().Contains(registerUserDto.Email))
            return Task.FromResult(messageResponseCreator.Create(StatusCodeType.BadRequest,
                Resources.EmailExistsMessage));

        return Task.FromResult(messageResponseCreator.Create(StatusCodeType.Success, Resources.SucceddfulCreateUser));
    }
}