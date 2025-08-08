using BoneConnect.Dto.Auth;

namespace BoneConnect.Services.AuthServices.UserRegisterService.Abstraction;

public interface IRegisterUserDtoMapper
{
    Models.Auth.User Map(RegisterUserDto createUserDto);
}