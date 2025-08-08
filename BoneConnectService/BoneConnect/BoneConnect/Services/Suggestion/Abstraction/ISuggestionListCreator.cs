using BoneConnect.DataStructures.List;
using BoneConnect.Models.Profile;

namespace BoneConnect.Services.Suggestion.Abstraction;

public interface ISuggestionListCreator
{
    Task<ArrayList<UserPreview>> Create(Models.Auth.User user, ArrayList<string> graphSuggestions, int topN);
}