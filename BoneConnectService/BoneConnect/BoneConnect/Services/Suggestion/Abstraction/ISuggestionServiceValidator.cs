using BoneConnect.DataStructures.List;
using BoneConnect.Dto;
using BoneConnect.Models.Profile;

namespace BoneConnect.Services.Suggestion.Abstraction;

public interface ISuggestionServiceValidator
{
    Task<ActionResponse<ArrayList<UserPreview>>> Validate(Models.Auth.User user);
}