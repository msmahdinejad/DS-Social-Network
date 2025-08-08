using BoneConnect.Dto.Auth;
using BoneConnect.Services.AuthServices.LoginService.Abstraction;
using BoneConnect.Services.AuthServices.UserRegisterService.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace BoneConnect.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class AuthController(
    IUserRegisterService userRegisterService,
    ILoginService loginService
    ) : ControllerBase
{

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginModel)
    {
        var response = await loginService.LoginAsync(loginModel, Response);

        return StatusCode((int)response.StatusCode, response.Data);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserDto createUserDto)
    {
        var result = await userRegisterService.RegisterUser(createUserDto);
        return StatusCode((int)result.StatusCode, result.Data);
    }
}