using BoneConnect.DataStructures.List;
using BoneConnect.Dto;
using BoneConnect.Models.Profile;

namespace BoneConnect.Services.Suggestion.Abstraction;

public interface ISuggestionService
{
    Task<ActionResponse<ArrayList<UserPreview>>> GetSuggestions(Models.Auth.User user);
}