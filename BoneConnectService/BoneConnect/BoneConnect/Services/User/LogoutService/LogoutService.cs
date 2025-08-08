using BoneConnect.Services.User.LogoutService.Abstraction;

namespace BoneConnect.Services.User.LogoutService;

public class LogoutService : ILogoutService
{
    public void Logout(HttpResponse response)
    {
        response.Cookies.Delete("jwt");
    }
}