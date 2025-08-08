namespace BoneConnect.Services.AuthServices.LoginService.Abstraction;

public interface ICookieSetter
{
    void SetCookie(HttpResponse response, string token);
}