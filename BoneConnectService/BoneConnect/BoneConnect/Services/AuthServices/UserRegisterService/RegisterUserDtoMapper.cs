using BoneConnect.Dto.Auth;
using BoneConnect.Services.AuthServices.LoginService.Abstraction;
using BoneConnect.Services.AuthServices.UserRegisterService.Abstraction;

namespace BoneConnect.Services.AuthServices.UserRegisterService;

public class RegisterUserDtoMapper(IPasswordHasher passwordHasher) : IRegisterUserDtoMapper
{
    public Models.Auth.User Map(RegisterUserDto registerUserDto)
    {
        return new Models.Auth.User
        {
            Username = registerUserDto.Username,
            PasswordHash = passwordHasher.HashPassword(registerUserDto.Password),
            Email = registerUserDto.Email,
            FirstName = registerUserDto.FirstName,
            LastName = registerUserDto.LastName,
            ProfilePic = registerUserDto.ProfilePic
        };
    }
}