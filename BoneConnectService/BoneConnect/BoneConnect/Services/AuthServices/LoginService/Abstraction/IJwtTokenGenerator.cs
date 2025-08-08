namespace BoneConnect.Services.AuthServices.LoginService.Abstraction;

public interface IJwtTokenGenerator
{
    string GenerateJwtToken(Models.Auth.User user);
}