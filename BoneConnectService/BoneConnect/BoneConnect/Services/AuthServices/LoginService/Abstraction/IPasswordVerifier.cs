namespace BoneConnect.Services.AuthServices.LoginService.Abstraction;

public interface IPasswordVerifier
{
    bool VerifyPasswordHash(string? password, string storedHash);
}