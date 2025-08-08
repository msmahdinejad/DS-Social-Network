using BoneConnect.Dto;
using BoneConnect.Dto.User;
using BoneConnect.Services.CRUD.User.Abstraction;
using BoneConnect.Services.User.ConnectUserService.Abstraction;
using BoneConnect.Services.User.LogoutService.Abstraction;
using BoneConnect.Services.User.UserDeleteService.Abstraction;
using BoneConnect.Services.User.UserInfoService.Abstraction;
using BoneConnect.Services.User.UserUpdateInfoService.Abstraction;
using BoneConnect.Services.User.UserUpdatePasswordService.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoneConnect.Controllers.User;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController(
    IUserInfoService userInfoService,
    IUserUpdateInfoService userUpdateInfoService,
    IUserUpdatePasswordService updatePasswordService,
    IUserReceiver userReceiver,
    IUserDeleteService userDeleteService,
    IConnectionUserService connectionUserService,
    ILogoutService logoutService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var user = await userReceiver.ReceiveUserAsync(User);
        var result = await userInfoService.GetUser(user);
        return StatusCode((int)result.StatusCode, result.Data);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var user = await userReceiver.ReceiveUserAsync(id);
        var result = await userInfoService.GetUser(user);
        return StatusCode((int)result.StatusCode, result.Data);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteUser()
    {
        var user = await userReceiver.ReceiveUserAsync(User);
        var result = await userDeleteService.DeleteUser(user);
        logoutService.Logout(Response);
        return StatusCode((int)result.StatusCode, result.Data);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UserUpdateInfoDto userUpdateInfoDto)
    {
        var user = await userReceiver.ReceiveUserAsync(User);
        var result = await userUpdateInfoService.UpdateUserAsync(user, userUpdateInfoDto, Response);
        return StatusCode((int)result.StatusCode, result.Data);
    }

    [HttpPatch("password")]
    public async Task<IActionResult> UpdatePassword(UserPasswordInfoDto passwordInfoDto)
    {
        var user = await userReceiver.ReceiveUserAsync(User);
        var result = await updatePasswordService.UpdatePasswordAsync(user, passwordInfoDto);
        return StatusCode((int)result.StatusCode, result.Data);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        logoutService.Logout(Response);
        return Ok(new MessageDto(Resources.SuccessfulLogoutMessage));
    }
    
    [HttpPost("connect/{id}")]
    public async Task<IActionResult> Connect(string id)
    {
        var currentUser = await userReceiver.ReceiveUserAsync(User);
        var secondUser = await userReceiver.ReceiveUserAsync(id);
        
        var result = await connectionUserService.Connection(currentUser, secondUser);
        return StatusCode((int)result.StatusCode, result.Data);
    }
    
    [HttpDelete("connect/{id}")]
    public async Task<IActionResult> RemoveConnection(string id)
    {
        var currentUser = await userReceiver.ReceiveUserAsync(User);
        var secondUser = await userReceiver.ReceiveUserAsync(id);
        
        var result = await connectionUserService.RemoveConnection(currentUser, secondUser);
        return StatusCode((int)result.StatusCode, result.Data);
    }
}