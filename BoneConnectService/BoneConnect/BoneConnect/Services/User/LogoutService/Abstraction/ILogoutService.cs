namespace BoneConnect.Services.User.LogoutService.Abstraction;

public interface ILogoutService
{
    void Logout(HttpResponse response);
}