using BoneConnect.Dto;
using BoneConnect.Dto.Auth;

namespace BoneConnect.Services.AuthServices.UserRegisterService.Abstraction;

public interface IUserRegisterServiceValidator
{
    Task<ActionResponse<MessageDto>> Validate(RegisterUserDto createUserDto);
}