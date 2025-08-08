namespace BoneConnect.Services.AuthServices.LoginService.Abstraction;

public interface IPasswordHasher
{
    string HashPassword(string? input);
}