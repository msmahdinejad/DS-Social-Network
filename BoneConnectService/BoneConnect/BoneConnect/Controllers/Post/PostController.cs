using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Dto.User;
using BoneConnect.Services.CRUD.Post.Abstraction;
using BoneConnect.Services.CRUD.User.Abstraction;
using BoneConnect.Services.Post.PostCreateService.Abstraction;
using BoneConnect.Services.Post.PostDeleteService.Abstraction;
using BoneConnect.Services.Post.PostInfoService.Abstraction;
using BoneConnect.Services.Post.PostUpdateInfoService.Abstraction;
using BoneConnect.Services.User.ConnectUserService.Abstraction;
using BoneConnect.Services.User.LogoutService.Abstraction;
using BoneConnect.Services.User.UserDeleteService.Abstraction;
using BoneConnect.Services.User.UserInfoService.Abstraction;
using BoneConnect.Services.User.UserUpdateInfoService.Abstraction;
using BoneConnect.Services.User.UserUpdatePasswordService.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoneConnect.Controllers.Post;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PostController(
    IUserReceiver userReceiver,
    IPostReceiver postReceiver,
    IPostInfoService postInfoService,
    IPostDeleteService postDeleteService,
    IPostUpdateInfoService postUpdateInfoService,
    IPostCreateService postCreateService)
    : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(string id)
    {
        var post = await postReceiver.ReceivePostAsync(id);
        var result = await postInfoService.GetPost(post);
        return StatusCode((int)result.StatusCode, result.Data);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(string id)
    {
        var user = await userReceiver.ReceiveUserAsync(User);
        var post = await postReceiver.ReceivePostAsync(id);
        var result = await postDeleteService.DeletePost(user, post);
        return StatusCode((int)result.StatusCode, result.Data);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(string id, PostUpdateInfoDto postUpdateInfoDto)
    {
        var user = await userReceiver.ReceiveUserAsync(User);
        var post = await postReceiver.ReceivePostAsync(id);
        var result = await postUpdateInfoService.UpdatePostAsync(user, post, postUpdateInfoDto);
        return StatusCode((int)result.StatusCode, result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(CreatePostDto createPostDto)
    {
        var user = await userReceiver.ReceiveUserAsync(User);
        var result = await postCreateService.CreatePost(user, createPostDto);
        return StatusCode((int)result.StatusCode, result.Data);
    }
}