using BoneConnect.Services.CRUD.Post.Abstraction;
using BoneConnect.Services.CRUD.User.Abstraction;
using BoneConnect.Services.Post.PostCreateService.Abstraction;
using BoneConnect.Services.Post.PostDeleteService.Abstraction;
using BoneConnect.Services.Post.PostInfoService.Abstraction;
using BoneConnect.Services.Post.PostUpdateInfoService.Abstraction;
using BoneConnect.Services.Suggestion.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoneConnect.Controllers.Suggestion;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SuggestionController(
    IUserReceiver userReceiver,
    ISuggestionService suggestionService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSuggestions()
    {
        var user = await userReceiver.ReceiveUserAsync(User);
        var result = await suggestionService.GetSuggestions(user);
        return StatusCode((int)result.StatusCode, result.Data);
    }
}