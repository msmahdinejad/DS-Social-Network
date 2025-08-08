using BoneConnect.Dto;
using BoneConnect.Dto.Auth;

namespace BoneConnect.Services.AuthServices.UserRegisterService.Abstraction;

public interface IUserRegisterService
{
    Task<ActionResponse<MessageDto>> RegisterUser(RegisterUserDto createUserDto);
}