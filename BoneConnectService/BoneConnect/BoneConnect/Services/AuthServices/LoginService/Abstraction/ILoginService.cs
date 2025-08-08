using BoneConnect.Dto;
using BoneConnect.Dto.Auth;

namespace BoneConnect.Services.AuthServices.LoginService.Abstraction;

public interface ILoginService
{
    Task<ActionResponse<MessageDto>> LoginAsync(LoginDto loginModel, HttpResponse response);
}