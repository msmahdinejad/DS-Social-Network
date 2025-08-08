using BoneConnect.Services.AuthServices.LoginService.Abstraction;

namespace BoneConnect.Services.AuthServices.LoginService;

public class PasswordVerifier(IPasswordHasher passwordHasher) : IPasswordVerifier
{
    public bool VerifyPasswordHash(string? password, string storedHash)
    {
        return passwordHasher.HashPassword(password) == storedHash;
    }
}