using BoneConnect.DataStructures.List;
using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Enums;
using BoneConnect.Models.Profile;
using BoneConnect.Services.Suggestion.Abstraction;

namespace BoneConnect.Services.Suggestion;

public class SuggestionServiceValidator : ISuggestionServiceValidator
{
    public async Task<ActionResponse<ArrayList<UserPreview>>> Validate(Models.Auth.User user)
    {
        if (user is null) return NotFoundResult();
        return await SuccessResult();
    }

    private Task<ActionResponse<ArrayList<UserPreview>>> SuccessResult()
    {
        return Task.FromResult(new ActionResponse<ArrayList<UserPreview>>
        {
            StatusCode = StatusCodeType.Success
        });
    }

    private ActionResponse<ArrayList<UserPreview>> NotFoundResult()
    {
        return new ActionResponse<ArrayList<UserPreview>>
        {
            StatusCode = StatusCodeType.NotFound
        };
    }
}